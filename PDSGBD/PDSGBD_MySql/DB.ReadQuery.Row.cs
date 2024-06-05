using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace PDSGBD.MySql
{
    /// <summary>
    /// Permet la gestion d'une connexion à un serveur MySql avec des paramètres de connexion spécifiques, et de là, de manipuler une base de données spécifiée
    /// </summary>
    public partial class DB
    {
        #region Interfaces et classes relatives au résultat de lecture d'enregistrement obtenu par exécution d'une requête de consultation
        /// <summary>
        /// Permet de consulter les données d'un enregistrement
        /// </summary>
        public interface IRow
        {
            /// <summary>
            /// Nombre de champs
            /// </summary>
            int Count { get; }

            /// <summary>
            /// Retourne le nom du champ spécifié par son indice
            /// </summary>
            /// <param name="index">Indice du champ</param>
            /// <returns>Nom du champ en fonction de son indice si possible, sinon null</returns>
            string GetFieldName(int index);

            /// <summary>
            /// Retourne la valeur du champ spécifié par son indice
            /// </summary>
            /// <param name="index">Indice du champ</param>
            /// <param name="defaultValue">Valeur par défaut à retourner si l'indice de champ est incorrect</param>
            /// <returns>Valeur du champ en fonction de son indice si possible, sinon null</returns>
            object GetValue(int index, object defaultValue = null);

            /// <summary>
            /// Retourne la valeur du champ spécifié par son nom
            /// </summary>
            /// <param name="name">Nom du champ</param>
            /// <param name="defaultValue">Valeur par défaut à retourner si le nom de champ est incorrect</param>
            /// <returns>Valeur du champ en fonction de son nom si possible, sinon null</returns>
            object GetValue(string name, object defaultValue = null);

            /// <summary>
            /// Retourne la valeur du champ spécifié par son indice
            /// </summary>
            /// <typeparam name="T">Type attendu pour la valeur spécifiée</typeparam>
            /// <param name="index">Indice du champ</param>
            /// <returns>Valeur du champ en fonction de son indice si possible, sinon null</returns>
            T GetValue<T>(int index, T defaultValue = default(T));

            /// <summary>
            /// Retourne la valeur du champ spécifié par son nom
            /// </summary>
            /// <typeparam name="T">Type attendu pour la valeur spécifiée</typeparam>
            /// <param name="name">Nom du champ</param>
            /// <returns>Valeur du champ en fonction de son nom si possible, sinon null</returns>
            T GetValue<T>(string name, T defaultValue = default(T));

            /// <summary>
            /// Retourne la valeur du champ spécifié par son indice
            /// </summary>
            /// <param name="index">Indice du champ</param>
            /// <returns>Valeur du champ en fonction de son indice si possible, sinon null</returns>
            bool TryGetValue(out object value, int index, object defaultValue = default(object));

            /// <summary>
            /// Retourne la valeur du champ spécifié par son nom
            /// </summary>
            /// <param name="name">Nom du champ</param>
            /// <returns>Valeur du champ en fonction de son nom si possible, sinon null</returns>
            bool TryGetValue(out object value, string name, object defaultValue = default(object));

            /// <summary>
            /// Retourne la valeur du champ spécifié par son indice
            /// </summary>
            /// <typeparam name="T">Type attendu pour la valeur spécifiée</typeparam>
            /// <param name="index">Indice du champ</param>
            /// <returns>Valeur du champ en fonction de son indice si possible, sinon null</returns>
            bool TryGetValue<T>(out T value, int index, T defaultValue = default(T));

            /// <summary>
            /// Retourne la valeur du champ spécifié par son nom
            /// </summary>
            /// <typeparam name="T">Type attendu pour la valeur spécifiée</typeparam>
            /// <param name="name">Nom du champ</param>
            /// <returns>Valeur du champ en fonction de son nom si possible, sinon null</returns>
            bool TryGetValue<T>(out T value, string name, T defaultValue = default(T));

            /// <summary>
            /// Valeur du champ spécifié par son indice
            /// </summary>
            /// <param name="index">Indice du champ</param>
            /// <returns>Valeur du champ en fonction de son indice si possible, sinon null</returns>
            object this[int index] { get; }

            /// <summary>
            /// Valeur du champ spécifié par son nom
            /// </summary>
            /// <param name="name">Nom du champ</param>
            /// <returns>Valeur du champ en fonction de son nom si possible, sinon null</returns>
            object this[string name] { get; }
        }

        /// <summary>
        /// Permet de consulter soit les données d'un enregistrement résultant de l'exécution d'une requête de consultation, soit l'information signalant une erreur d'exécution d'une requête de consultation
        /// </summary>
        public interface IRowGetResult : IRow
        {
            /// <summary>
            /// Indique si l'exécution de la requête de consultation a pu se faire correctement
            /// </summary>
            bool Success { get; }

            /// <summary>
            /// Indique si l'exécution de la requête de consultation n'a pas pu se faire correctement
            /// </summary>
            bool Failure { get; }

            /// <summary>
            /// Message d'erreur (en cas d'échec d'exécution de la requête de consultation)
            /// </summary>
            string ErrorMessage { get; }
        }

        /// <summary>
        /// Stocke l'information d'un enregistrement résultant de l'exécution d'une requête de consultation
        /// </summary>
        private class Row : IRow
        {
            /// <summary>
            /// Dictionnaire stockant les associations nom/valeur des champs
            /// </summary>
            private Dictionary<string, object> m_NameValues;

            /// <summary>
            /// Référence du tableau contenant les noms des champs
            /// </summary>
            private string[] m_Names;

            /// <summary>
            /// Référence du tableau contenant les valeurs des champs
            /// </summary>
            private object[] m_Values;

            /// <summary>
            /// Nombre de champs
            /// </summary>
            public int Count => (m_Names != null) ? m_Names.Length : 0;

            /// <summary>
            /// Retourne le nom du champ spécifié par son indice
            /// </summary>
            /// <param name="index">Indice du champ</param>
            /// <returns>Nom du champ en fonction de son indice si possible, sinon null</returns>
            public string GetFieldName(int index)
            {
                return ((m_Names != null) && (index >= 0) && (index < m_Names.Length)) ? m_Names[index] : null;
            }

            /// <summary>
            /// Retourne la valeur du champ spécifié par son indice
            /// </summary>
            /// <param name="index">Indice du champ</param>
            /// <param name="defaultValue">Valeur par défaut à retourner si l'indice de champ est incorrect</param>
            /// <returns>Valeur du champ en fonction de son indice si possible, sinon null</returns>
            public object GetValue(int index, object defaultValue = null)
            {
                return TryGetValue(out var value, index, defaultValue) ? value : defaultValue;
            }

            /// <summary>
            /// Retourne la valeur du champ spécifié par son nom
            /// </summary>
            /// <param name="name">Nom du champ</param>
            /// <param name="defaultValue">Valeur par défaut à retourner si le nom de champ est incorrect</param>
            /// <returns>Valeur du champ en fonction de son nom si possible, sinon null</returns>
            public object GetValue(string name, object defaultValue = null)
            {
                return TryGetValue(out var value, name, defaultValue) ? value : defaultValue;
            }

            /// <summary>
            /// Retourne la valeur du champ spécifié par son indice
            /// </summary>
            /// <typeparam name="T">Type attendu pour la valeur spécifiée</typeparam>
            /// <param name="index">Indice du champ</param>
            /// <returns>Valeur du champ en fonction de son indice si possible, sinon null</returns>
            public T GetValue<T>(int index, T defaultValue = default(T))
            {
                return TryGetValue<T>(out var value, index, defaultValue) ? value : defaultValue;
            }

            /// <summary>
            /// Retourne la valeur du champ spécifié par son nom
            /// </summary>
            /// <typeparam name="T">Type attendu pour la valeur spécifiée</typeparam>
            /// <param name="name">Nom du champ</param>
            /// <returns>Valeur du champ en fonction de son nom si possible, sinon null</returns>
            public T GetValue<T>(string name, T defaultValue = default(T))
            {
                return TryGetValue<T>(out var value, name, defaultValue) ? value : defaultValue;
            }

            /// <summary>
            /// Retourne la valeur du champ spécifié par son indice
            /// </summary>
            /// <param name="index">Indice du champ</param>
            /// <returns>Valeur du champ en fonction de son indice si possible, sinon null</returns>
            public bool TryGetValue(out object value, int index, object defaultValue = default(object))
            {
                try
                {
                    if (m_Values == null) throw new Exception("There isn't row data !");
                    if ((index < 0) || (index >= m_Values.Length)) throw new Exception($"Field index {index} isn't valid !");
                    value = m_Values[index];
                    return true;
                }
                catch (Exception error)
                {
                    System.Diagnostics.Debug.WriteLine($"\nRow.TryGetValue fails :\n{error.Message}\n");
                    value = defaultValue;
                    return false;
                }
            }

            /// <summary>
            /// Retourne la valeur du champ spécifié par son nom
            /// </summary>
            /// <param name="name">Nom du champ</param>
            /// <returns>Valeur du champ en fonction de son nom si possible, sinon null</returns>
            public bool TryGetValue(out object value, string name, object defaultValue = default(object))
            {
                try
                {
                    if (m_NameValues == null) throw new Exception("There isn't row data !");
                    if (!m_NameValues.TryGetValue(name, out value)) throw new Exception($"Field name '{name}' isn't valid !");
                    return true;
                }
                catch (Exception error)
                {
                    System.Diagnostics.Debug.WriteLine($"\nRow.TryGetValue fails :\n{error.Message}\n");
                    value = defaultValue;
                    return false;
                }
            }

            /// <summary>
            /// Retourne la valeur du champ spécifié par son indice
            /// </summary>
            /// <typeparam name="T">Type attendu pour la valeur spécifiée</typeparam>
            /// <param name="index">Indice du champ</param>
            /// <returns>Valeur du champ en fonction de son indice si possible, sinon null</returns>
            public bool TryGetValue<T>(out T value, int index, T defaultValue = default(T))
            {
                try
                {
                    if (!IsDbValue<T>()) throw new Exception($"Result type isn't a valid DB value type : {typeof(T).FullName} !");
                    if (m_Values == null) throw new Exception("There isn't row data !");
                    if ((index < 0) || (index >= m_Values.Length)) throw new Exception($"Field index {index} isn't valid !");
                    value = ConvertObjectValueToDbValue<T>(m_Values[index]);
                    return true;
                }
                catch (Exception error)
                {
                    System.Diagnostics.Debug.WriteLine($"\nRow.TryGetValue<{typeof(T).Name}> fails :\n{error.Message}\n");
                    value = defaultValue;
                    return false;
                }
            }

            /// <summary>
            /// Retourne la valeur du champ spécifié par son nom
            /// </summary>
            /// <typeparam name="T">Type attendu pour la valeur spécifiée</typeparam>
            /// <param name="name">Nom du champ</param>
            /// <returns>Valeur du champ en fonction de son nom si possible, sinon null</returns>
            public bool TryGetValue<T>(out T value, string name, T defaultValue = default(T))
            {
                try
                {
                    if (!IsDbValue<T>()) throw new Exception($"Result type isn't a valid DB value type : {typeof(T).FullName} !");
                    if (m_NameValues == null) throw new Exception("There isn't row data !");
                    if (!m_NameValues.TryGetValue(name, out var objectValue)) throw new Exception($"Field name '{name}' isn't valid !");
                    value = ConvertObjectValueToDbValue<T>(objectValue);
                    return true;
                }
                catch (Exception error)
                {
                    System.Diagnostics.Debug.WriteLine($"\nRow.TryGetValue<{typeof(T).Name}> fails :\n{error.Message}\n");
                    value = defaultValue;
                    return false;
                }
            }

            /// <summary>
            /// Valeur du champ spécifié par son indice
            /// </summary>
            /// <param name="index">Indice du champ</param>
            /// <returns>Valeur du champ en fonction de son indice si possible, sinon null</returns>
            public object this[int index] => GetValue(index);

            /// <summary>
            /// Valeur du champ spécifié par son nom
            /// </summary>
            /// <param name="name">Nom du champ</param>
            /// <returns>Valeur du champ en fonction de son nom si possible, sinon null</returns>
            public object this[string name] => GetValue(name);

            /// <summary>
            /// Permet d'instancier un objet définissant un enregistrement résultant de l'exécution d'une requête de consultation
            /// </summary>
            /// <param name="names">Tableau contenant les noms des champs</param>
            /// <param name="values">Tableau contenant les valeurs des champs</param>
            /// <returns>Nouvel objet de type Row si les paramètres définissant les noms et valeurs des champs sont valides, sinon null</returns>
            public static Row Create(string[] names, object[] values)
            {
                var row = new Row();
                return row.DefineRow(names, values) ? row : null;
            }

            /// <summary>
            /// Constructeur par défaut
            /// </summary>
            protected Row()
            {
                m_NameValues = null;
                m_Names = null;
                m_Values = null;
            }

            /// <summary>
            /// Méthode permettant de définir si possible, et une seule fois, les noms et valeurs des champs de cet enregistrement
            /// </summary>
            /// <param name="names">Tableau contenant les noms des champs</param>
            /// <param name="values">Tableau contenant les valeurs des champs</param>
            /// <returns>Vrai si la définition des champs de cet enregistrement a pu se faire, sinon faux</returns>
            protected bool DefineRow(string[] names, object[] values)
            {
                if (m_NameValues != null) return false;
                if ((names == null) || (values == null) || (names.Length == 0) || (names.Length != values.Length)) return false;
                if (names.DuplicateExists()) return false; //if (names.Distinct().Count() < names.Length) return false;
                m_Names = names;
                m_Values = values;
                m_NameValues = new Dictionary<string, object>();
                for (int i = 0; i < names.Length; i++) m_NameValues.Add(m_Names[i], m_Values[i]);
                return true;
            }

            /// <summary>
            /// Permet de mettre à jour les valeurs de champ de cet enregistrement
            /// </summary>
            /// <param name="values">Tableau contenant les nouvelles valeurs des champs</param>
            /// <returns>Vrai si la modification des valeurs des champs de cet enregistrement a pu se faire, sinon faux</returns>
            public bool UpdateValues(object[] values)
            {
                if ((values == null) || (m_Names == null) || (values.Length != m_Names.Length)) return false;
                for (int i = 0; i < m_Names.Length; i++)
                {
                    m_Values[i] = values[i];
                    m_NameValues[m_Names[i]] = values[i];
                }
                return true;
            }

            #region Réécriture des méthodes de la classe de base (Object)
            /// <summary>
            /// Permet de retourner une chaîne représentative de cet objet
            /// </summary>
            /// <returns>Chaîne représentative de cet objet</returns>
            public override string ToString()
            {
                return (m_NameValues != null)
                    ? $"{{ {string.Join(" ; ", m_NameValues.Select(kv => $"{kv.Key} : {ValueToSql(kv.Value)}"))} }}"
                    : $"None data !";
            }
            #endregion
        }

        /// <summary>
        /// Stocke un résultat d'exécution d'une requête de consultation, mais limité à un seul enregistrement (à la fois)
        /// </summary>
        private class RowGetResult : Row, IRowGetResult
        {
            /// <summary>
            /// Indique si l'exécution de la requête de consultation a pu se faire correctement
            /// </summary>
            public bool Success => (Count != 0);

            /// <summary>
            /// Indique si l'exécution de la requête de consultation n'a pas pu se faire correctement
            /// </summary>
            public bool Failure => (Count == 0);

            /// <summary>
            /// Message d'erreur (en cas d'échec d'exécution de la requête de consultation)
            /// </summary>
            public string ErrorMessage { get; private set; }

            /// <summary>
            /// Permet d'instancier un objet définissant un résultat d'exécution d'une requête de consultation
            /// </summary>
            /// <param name="names">Tableau contenant les noms des champs</param>
            /// <param name="values">Tableau contenant les valeurs des champs</param>
            /// <returns>Nouvel objet de type RowGetResult si les paramètres définissant les noms et valeurs des champs sont valides, sinon null</returns>
            public static new RowGetResult Create(string[] names, object[] values)
            {
                var result = new RowGetResult();
                return result.DefineRow(names, values) ? result : null;
            }

            /// <summary>
            /// Permet d'instancier un objet indiquant un échec d'exécution d'une requête de consultation
            /// </summary>
            /// <param name="errorMessage">Message décrivant l'erreur survenue</param>
            /// <returns>Nouvel objet de type RowGetResult définissant une erreur d'exécution d'une requête de consultation</returns>
            public static RowGetResult Create(string errorMessage)
            {
                if (string.IsNullOrWhiteSpace(errorMessage)) return null;
                var result = new RowGetResult();
                result.ErrorMessage = errorMessage.Trim();
                return result;
            }

            /// <summary>
            /// Constructeur par défaut
            /// </summary>
            private RowGetResult()
                : base()
            {
                ErrorMessage = null;
            }

            #region Réécriture des méthodes de la classe de base (Object)
            /// <summary>
            /// Permet de retourner une chaîne représentative de cet objet
            /// </summary>
            /// <returns>Chaîne représentative de cet objet</returns>
            public override string ToString()
            {
                return (Success) ? base.ToString() : $"{{ ErrorMessage : {ErrorMessage} }}";
            }
            #endregion
        }
        #endregion

        #region Méthodes de récupération d'enregistrement résultant de l'exécution d'une requête de consultation
        /// <summary>
        /// Permet d'exécuter une requête de consultation dans le but de récupérer le premier enregistrement en résultant
        /// </summary>
        /// <param name="query">Requête SQL</param>
        /// <param name="parameterValues">Valeurs des parties variables correspondant dans le texte de la requête aux parties variables indicées {0} {1} {2} ...</param>
        /// <returns>Résultat de requête de consultation fournissant soit un accès aux données relatives au premier enregistrement, soit un descriptif d'erreur d'exécution</returns>
        public IRowGetResult GetRow(string query, params object[] parameterValues)
        {
            QueryType queryType = QueryType.Unknown;
            string preparedQuery = null;
            try
            {
                using (var newDb = new DB(this.CurrentSettings))
                {
                    if (!newDb.EnsureConnection()) throw new Exception("Connection failure !");
                    if (!PrepareQuery(out queryType, out preparedQuery, query, parameterValues)) throw new Exception("DB.PrepareQuery fails !");
                    if (!queryType.IsReadQuery()) throw new Exception("Query type not supported for DB.TryGetValue method !");
                    var command = new MySqlCommand(preparedQuery, newDb.m_Connection);
                    using (var reader = command.ExecuteReader())
                    {
                        if (!reader.Read()) throw new Exception("This query returns none row !");
                        string[] names = new string[reader.FieldCount];
                        object[] values = new object[names.Length];
                        for (int i = 0; i < names.Length; i++) names[i] = reader.GetName(i);
                        reader.GetValues(values);
                        return RowGetResult.Create(names, values);
                    }
                }
            }
            catch (Exception error)
            {
                System.Diagnostics.Debug.WriteLine($"\nDB.GetRow fails :\n* query type : {queryType}\n* query to prepare : {query}{string.Join("", parameterValues.Select((v, i) => $"\n* parameter [{i}] : {v}"))}\n* prepared query : {preparedQuery}\n{error.Message}\n");
                return RowGetResult.Create(error.Message);
            }
        }

        /// <summary>
        /// Permet d'exécuter une requête de consultation dans le but de récupérer les enregistrements en résultant, les uns après les autres
        /// </summary>
        /// <param name="query">Requête SQL</param>
        /// <param name="parameterValues">Valeurs des parties variables correspondant dans le texte de la requête aux parties variables indicées {0} {1} {2} ...</param>
        /// <returns>Résultat de requête de consultation fournissant soit un accès aux données relatives au premier enregistrement, soit un descriptif d'erreur d'exécution</returns>
        public IEnumerable<IRow> GetRows(string query, params object[] parameterValues)
        {
            return GetRows(false, query, parameterValues);
        }

        /// <summary>
        /// Permet d'exécuter une requête de consultation dans le but de récupérer les enregistrements en résultant, les uns après les autres
        /// </summary>
        /// <param name="returnResultOnFailure">Indique si cette méthode doit retourner un résultat lors d'une erreur de connexion/injection/exécution/lecture, ou pas</param>
        /// <param name="query">Requête SQL</param>
        /// <param name="parameterValues">Valeurs des parties variables correspondant dans le texte de la requête aux parties variables indicées {0} {1} {2} ...</param>
        /// <returns>Résultat de requête de consultation fournissant soit un accès aux données relatives au premier enregistrement, soit un descriptif d'erreur d'exécution</returns>
        public IEnumerable<IRowGetResult> GetRows(bool returnResultOnFailure, string query, params object[] parameterValues)
        {
            GetRows_Result result = null;
            try
            {
                result = new GetRows_Result(this, returnResultOnFailure, query, parameterValues);
                foreach (var item in result) yield return item;
            }
            finally
            {
                if (result != null) result.Dispose();
            }
        }

        /// <summary>
        /// Classe utilitaire permettant d'instancier l'objet garantissant la libération des ressources utilisées lors de la consultation d'enregistrements via la méthode DB.GetRows
        /// </summary>
        private class GetRows_Result : IDisposable, IEnumerable<IRowGetResult>
        {
            /// <summary>
            /// Objet de connexion spécifique à cette consultation
            /// </summary>
            private DB m_Db;

            /// <summary>
            /// Objet de lecture d'enregistrements
            /// </summary>
            private MySqlDataReader m_Reader;

            /// <summary>
            /// Indique si cette méthode doit retourner un résultat lors d'une erreur de connexion/injection/exécution/lecture, ou pas
            /// </summary>
            private bool m_ReturnResultOnFailure;

            /// <summary>
            /// Requête SQL
            /// </summary>
            private string m_Query;

            /// <summary>
            /// Valeurs des parties variables correspondant dans le texte de la requête aux parties variables indicées {0} {1} {2} ...
            /// </summary>
            private object[] m_ParameterValues;

            /// <summary>
            /// Constructeur
            /// </summary>
            /// <param name="db">Objet de connexion servant à fournir les paramètres de connexion à l'objet interne de connexion utilisé pour cette consultation</param>
            /// <param name="returnResultOnFailure">Indique si cette méthode doit retourner un résultat lors d'une erreur de connexion/injection/exécution/lecture, ou pas</param>
            /// <param name="query">Requête SQL</param>
            /// <param name="parameterValues">Valeurs des parties variables correspondant dans le texte de la requête aux parties variables indicées {0} {1} {2} ...</param>
            public GetRows_Result(DB db, bool returnResultOnFailure, string query, params object[] parameterValues)
            {
                m_Db = new DB(db.CurrentSettings);
                m_Reader = null;
                m_ReturnResultOnFailure = returnResultOnFailure;
                m_Query = query;
                m_ParameterValues = parameterValues;
            }

            #region Implémentation de l'interface IEnumerable<IRowGetResult>
            IEnumerator IEnumerable.GetEnumerator()
            {
                return (this as IEnumerable<IRowGetResult>).GetEnumerator();
            }

            public IEnumerator<IRowGetResult> GetEnumerator()
            {
                if (m_Reader != null) yield break;
                QueryType queryType = QueryType.Unknown;
                string preparedQuery = null;
                string errorMessage = null;
                try
                {
                    if (!m_Db.EnsureConnection()) throw new Exception("Connection failure !");
                    if (!PrepareQuery(out queryType, out preparedQuery, m_Query, m_ParameterValues)) throw new Exception("DB.PrepareQuery fails !");
                    if (!queryType.IsReadQuery()) throw new Exception("Query type not supported for DB.TryGetValue method !");
                    var command = new MySqlCommand(preparedQuery, m_Db.m_Connection);
                    m_Reader = command.ExecuteReader();
                }
                catch (Exception error)
                {
                    System.Diagnostics.Debug.WriteLine($"\nDB.GetRows fails :\n* query type : {queryType}\n* query to prepare : {m_Query}{string.Join("", m_ParameterValues.Select((v, i) => $"\n* parameter [{i}] : {v}"))}\n* prepared query : {preparedQuery}\n{error.Message}\n");
                    errorMessage = error.Message;
                }
                if (m_Reader == null)
                {
                    if (m_ReturnResultOnFailure) yield return RowGetResult.Create(errorMessage);
                    yield break;
                }
                RowGetResult row = null;
                object[] values = null;
                while (true)
                {
                    try
                    {
                        if (!m_Reader.Read())
                        {
                            if (!m_Reader.NextResult()) yield break;
                            values = null;
                        }
                        else
                        {
                            if (values == null)
                            {
                                string[] names = new string[m_Reader.FieldCount];
                                values = new object[names.Length];
                                for (int i = 0; i < names.Length; i++) names[i] = m_Reader.GetName(i);
                                m_Reader.GetValues(values);
                                row = RowGetResult.Create(names, values);
                            }
                            else
                            {
                                m_Reader.GetValues(values);
                                row.UpdateValues(values);
                            }
                        }
                    }
                    catch (Exception error)
                    {
                        System.Diagnostics.Debug.WriteLine($"\nDB.GetRows fails :\n* query type : {queryType}\n* query to prepare : {m_Query}{string.Join("", m_ParameterValues.Select((v, i) => $"\n* parameter [{i}] : {v}"))}\n* prepared query : {preparedQuery}\n{error.Message}\n");
                        errorMessage = error.Message;
                        break;
                    }
                    if (row != null) yield return row;
                }
                if ((errorMessage != null) && m_ReturnResultOnFailure) yield return RowGetResult.Create(errorMessage);
            }
            #endregion

            #region Implémentation de l'interface IDisposable
            public void Dispose()
            {
                if (m_Reader != null)
                {
                    m_Reader.Close();
                    m_Reader = null;
                }
                if (m_Db != null)
                {
                    m_Db.Dispose();
                    m_Db = null;
                }
            }
            #endregion
        }
        #endregion
    }
}
