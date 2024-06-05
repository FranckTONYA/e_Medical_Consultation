using System;
using System.Collections.Generic;
using System.Linq;
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
        #region Récupération d'une valeur "non typée" du premier champ du premier enregistrement résultant de l'exécution d'une requête de consultation
        /// <summary>
        /// Permet de récupérer de manière "non typée" la valeur du premier champ du premier enregistrement résultant de l'exécution d'une requête de consultation
        /// </summary>
        /// <param name="query">Requête SQL</param>
        /// <param name="parameterValues">Valeurs des parties variables correspondant dans le texte de la requête aux parties variables indicées {0} {1} {2} ...</param>
        /// <returns>Valeur du premier champ du premier enregistrement récupéré si possible, sinon null</returns>
        public object GetValue(string query, params object[] parameterValues)
        {
            return GetValueOrDefault(null, query, parameterValues);
        }

        /// <summary>
        /// Permet de récupérer de manière "non typée" la valeur du premier champ du premier enregistrement résultant de l'exécution d'une requête de consultation
        /// </summary>
        /// <param name="defaultValue">Valeur par défaut à retourner en cas d'échec de la récupération de cette valeur de champ</param>
        /// <param name="query">Requête SQL</param>
        /// <param name="parameterValues">Valeurs des parties variables correspondant dans le texte de la requête aux parties variables indicées {0} {1} {2} ...</param>
        /// <returns>Valeur du premier champ du premier enregistrement récupéré si possible, sinon la valeur par défaut spécifiée</returns>
        public object GetValueOrDefault(object defaultValue, string query, params object[] parameterValues)
        {
            return TryGetValue(out var value, query, parameterValues) ? value : defaultValue;
        }

        /// <summary>
        /// Tente de récupérer de manière "non typée" la valeur du premier champ du premier enregistrement résultant de l'exécution d'une requête de consultation
        /// </summary>
        /// <param name="value">Valeur du premier champ du premier enregistrement récupéré si possible, sinon null</param>
        /// <param name="query">Requête SQL</param>
        /// <param name="parameterValues">Valeurs des parties variables correspondant dans le texte de la requête aux parties variables indicées {0} {1} {2} ...</param>
        /// <returns>Vrai si la récupération de la valeur de champ a pu se faire correctement, sinon faux</returns>
        public bool TryGetValue(out object value, string query, params object[] parameterValues)
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
                    value = command.ExecuteScalar();
                    return true;
                }
            }
            catch (Exception error)
            {
                System.Diagnostics.Debug.WriteLine($"\nDB.TryGetValue fails :\n* query type : {queryType}\n* query to prepare : {query}{string.Join("", parameterValues.Select((v, i) => $"\n* parameter [{i}] : {v}"))}\n* prepared query : {preparedQuery}\n{error.Message}\n");
                value = null;
                return false;
            }
        }
        #endregion

        #region Récupération d'une valeur "typée" du premier champ du premier enregistrement résultant de l'exécution d'une requête de consultation
        /// <summary>
        /// Permet de récupérer de manière "typée" la valeur du premier champ du premier enregistrement résultant de l'exécution d'une requête de consultation
        /// </summary>
        /// <typeparam name="T">Type de la valeur attendue</typeparam>
        /// <param name="query">Requête SQL</param>
        /// <param name="parameterValues">Valeurs des parties variables correspondant dans le texte de la requête aux parties variables indicées {0} {1} {2} ...</param>
        /// <returns>Valeur du premier champ du premier enregistrement récupéré si possible, sinon null</returns>
        public T GetValue<T>(string query, params object[] parameterValues)
        {
            return GetValueOrDefault<T>(default(T), query, parameterValues);
        }

        /// <summary>
        /// Permet de récupérer de manière "typée" la valeur du premier champ du premier enregistrement résultant de l'exécution d'une requête de consultation
        /// </summary>
        /// <typeparam name="T">Type de la valeur attendue</typeparam>
        /// <param name="defaultValue">Valeur par défaut à retourner en cas d'échec de la récupération de cette valeur de champ</param>
        /// <param name="query">Requête SQL</param>
        /// <param name="parameterValues">Valeurs des parties variables correspondant dans le texte de la requête aux parties variables indicées {0} {1} {2} ...</param>
        /// <returns>Valeur du premier champ du premier enregistrement récupéré si possible, sinon la valeur par défaut spécifiée</returns>
        public T GetValueOrDefault<T>(T defaultValue, string query, params object[] parameterValues)
        {
            return TryGetValue<T>(out var value, query, parameterValues) ? value : defaultValue;
        }

        /// <summary>
        /// Tente de récupérer de manière "typée" la valeur du premier champ du premier enregistrement résultant de l'exécution d'une requête de consultation
        /// </summary>
        /// <typeparam name="T">Type de la valeur attendue</typeparam>
        /// <param name="value">Valeur du premier champ du premier enregistrement récupéré si possible, sinon null</param>
        /// <param name="query">Requête SQL</param>
        /// <param name="parameterValues">Valeurs des parties variables correspondant dans le texte de la requête aux parties variables indicées {0} {1} {2} ...</param>
        /// <returns>Vrai si la récupération de la valeur de champ a pu se faire correctement, sinon faux</returns>
        public bool TryGetValue<T>(out T value, string query, params object[] parameterValues)
        {
            QueryType queryType = QueryType.Unknown;
            string preparedQuery = null;
            try
            {
                if (!IsDbValue<T>()) throw new Exception($"Result type isn't a valid DB value type : {typeof(T).FullName} !");
                using (var newDb = new DB(this.CurrentSettings))
                {
                    if (!newDb.EnsureConnection()) throw new Exception("Connection failure !");
                    if (!PrepareQuery(out queryType, out preparedQuery, query, parameterValues)) throw new Exception("DB.PrepareQuery fails !");
                    if (!queryType.IsReadQuery()) throw new Exception("Query type not supported for DB.TryGetValue method !");
                    var command = new MySqlCommand(preparedQuery, newDb.m_Connection);
                    var objectValue = command.ExecuteScalar();
                    value = ConvertObjectValueToDbValue<T>(objectValue);
                    return true;
                }
            }
            catch (Exception error)
            {
                System.Diagnostics.Debug.WriteLine($"\nDB.TryGetValue<{typeof(T).Name}> fails :\n* query type : {queryType}\n* query to prepare : {query}{string.Join("", parameterValues.Select((v, i) => $"\n* parameter [{i}] : {v}"))}\n* prepared query : {preparedQuery}\n{error.Message}\n");
                value = default(T);
                return false;
            }
        }
        #endregion
    }
}
