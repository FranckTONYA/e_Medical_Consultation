using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySqlDateTime = MySql.Data.Types.MySqlDateTime;
using MySqlDecimal = MySql.Data.Types.MySqlDecimal;

namespace PDSGBD.MySql
{
    /// <summary>
    /// Permet la gestion d'une connexion à un serveur MySql avec des paramètres de connexion spécifiques, et de là, de manipuler une base de données spécifiée
    /// </summary>
    public partial class DB
    {
        /// <summary>
        /// Contient une partie de code SQL pouvant être injecté comme valeur d'une partie variable d'une requête (ou du code d'un autre objet SqlCode)
        /// </summary>
        public class SqlCode
        {
            /// <summary>
            /// Code Sql (après injection des valeurs des parties variables)
            /// </summary>
            public string Code { get; private set; }

            /// <summary>
            /// Permet de créer un nouvel objet contenant un code SQL (que l'on désire injecter ultérieurement dans une requête)
            /// </summary>
            /// <param name="codeSql">Portion d'une requête SQL</param>
            /// <param name="parameterValues">Valeurs des parties variables correspondant dans le texte de la requête aux parties variables indicées {0} {1} {2} ...</param>
            /// <returns>Objet de type SqlCode contenant le code SQL prêt à être injecté dans un autre SQL</returns>
            public static SqlCode Create(string codeSql, params object[] parameterValues)
            {
                try
                {
                    return new SqlCode(codeSql, parameterValues);
                }
                catch (Exception error)
                {
                    System.Diagnostics.Debug.WriteLine($"\nError during creation of SqlCode object :\n* code to prepare : {codeSql}{string.Join("", parameterValues.Select((v, i) => $"\n* parameter [{i}] : {v}"))}\n{error.Message}\n");
                    return null;
                }
            }

            /// <summary>
            /// Constructeur
            /// </summary>
            /// <param name="codeSql">Portion d'une requête SQL</param>
            /// <param name="parameterValues">Valeurs des parties variables correspondant dans le texte de la requête aux parties variables indicées {0} {1} {2} ...</param>
            /// <exception cref="Exception">Toute exception survenant pendant la phase d'injection des valeurs des parties variables</exception>
            private SqlCode(string codeSql, params object[] parameterValues)
            {
                Code = string.Format(codeSql, parameterValues.Select(v => ValueToSql(v)).ToArray());
            }

            #region Réécriture des méthodes de la classe de base (Object)
            /// <summary>
            /// Permet de retourner une chaîne représentative de cet objet
            /// </summary>
            /// <returns>Chaîne représentative de cet objet</returns>
            public override string ToString()
            {
                return Code;
            }
            #endregion
        }

        /// <summary>
        /// Tout type de requête prise en charge
        /// </summary>
        public enum QueryType
        {
            /// <summary>
            /// Type de requête non identifié, ou non pris en charge
            /// </summary>
            Unknown,
            #region Types de requêtes servant à la consultation
            /// <summary>
            /// Requête de consultation de type SELECT ...
            /// </summary>
            Select,
            /// <summary>
            /// Requête de consultation de type SHOW ...
            /// </summary>
            Show,
            /// <summary>
            /// Requête de consultation de type CALL procedure_stockée
            /// </summary>
            Call,
            #endregion
            #region Types de requêtes servant à la modification de données (ou de la structure)
            /// <summary>
            /// Requête d'action de type INSERT INTO table ...
            /// </summary>
            Insert,
            /// <summary>
            /// Requête d'action de type UPDATE table SET ...
            /// </summary>
            Update,
            /// <summary>
            /// Requête d'action de type DELETE FROM table ...
            /// </summary>
            Delete
            #endregion
        }

        /// <summary>
        /// Premier type de requête d'action que l'on trouve dans l'énumération QueryType
        /// <para>Avant ce type, il s'agit de types de requête de consultation (excepté le tout premier type qui est Unknown)</para>
        /// <para>A partir de ce type, il s'agit de types de requête d'action</para>
        /// </summary>
        public const QueryType FirstActionQueryType = QueryType.Insert;

        /// <summary>
        /// Permet d'identifier le type de requête et d'injecter en toute sécurité les valeurs spécifiées au sein de la requête spécifiée
        /// </summary>
        /// <param name="queryType">Type de requête qui a pu être identifiée (ou non) [OUT]</param>
        /// <param name="preparedQuery">Requête résultant de l'injection [OUT]</param>
        /// <param name="query">Requête SQL</param>
        /// <param name="parameterValues">Valeurs des parties variables correspondant dans le texte de la requête aux parties variables indicées {0} {1} {2} ...</param>
        /// <returns>Vrai si aucune erreur n'a été détectée lors de ce traitement d'identification et d'injection, sinon faux</returns>
        private static bool PrepareQuery(out QueryType queryType, out string preparedQuery, string query, params object[] parameterValues)
        {
            if (parameterValues == null) parameterValues = new object[0];
            queryType = QueryType.Unknown;
            preparedQuery = null;
            try
            {
                if (string.IsNullOrWhiteSpace(query)) throw new Exception("Query is null, empty or filled with space !");
                query = query.Trim();
                var firstKeyword = query.Split(new char[] { ' ', '\r', '\n', '\t', '(', '`' }, 2)[0].ToUpper();
                if (!Enum.TryParse(firstKeyword, true, out queryType) || (queryType == QueryType.Unknown)) throw new Exception("Query starts with an undefined keyword !");
                preparedQuery = string.Format(query, parameterValues.Select(v => ValueToSql(v)).ToArray());
                return true;
            }
            catch (Exception error)
            {
                System.Diagnostics.Debug.WriteLine($"\nError in PrepareQuery :\n* query to prepare : {query}{string.Join("", parameterValues.Select((v, i) => $"\n* parameter [{i}] : {v}"))}\n{error.Message}\n");
                return false;
            }
        }

        /// <summary>
        /// Permet de transformer si possible la valeur spécifiée en une chaîne de caractères injectable au sein d'une requête SQL (MySQL)
        /// </summary>
        /// <param name="value">Valeur à trnasformer</param>
        /// <returns>Chaîne représentant la valeur à injecter au sein d'une requête SQL (MySQL)</returns>
        /// <exception cref="NotImplementedException"></exception>
        private static string ValueToSql(object value)
        {
            if (value == null) return "NULL";
            if (value is sbyte) return value.ToString();
            if (value is byte) return value.ToString();
            if (value is short) return value.ToString();
            if (value is ushort) return value.ToString();
            if (value is int) return value.ToString();
            if (value is uint) return value.ToString();
            if (value is long) return value.ToString();
            if (value is ulong) return value.ToString();
            if (value is float) return ((float)value).ToString(EnglishCulture);
            if (value is double) return ((double)value).ToString(EnglishCulture);
            if (value is decimal) return ((decimal)value).ToString(EnglishCulture);
            if (value is MySqlDecimal)
            {
                var mysqlDecimalValue = (MySqlDecimal)value;
                if (mysqlDecimalValue.IsNull) return "NULL";
                return (mysqlDecimalValue.Value).ToString(EnglishCulture);
            }
            if (value is bool) return ((bool)value) ? "TRUE" : "FALSE";
            if ((value is char) || (value is string) || (value is StringBuilder)) return $"\"{value.ToString().Replace("\\", "\\\\").Replace("\"", "\\\"")}\"";
            if ((value is DateTime) || (value is MySqlDateTime))
            {
                DateTime datetimeValue;
                if (value is DateTime)
                {
                    datetimeValue = (DateTime)value;
                }
                else
                {
                    var mysqlDateTimeValue = (MySqlDateTime)value;
                    if (mysqlDateTimeValue.IsNull) return "NULL";
                    if (!mysqlDateTimeValue.IsValidDateTime) throw new NotSupportedException($"Valeur de type MySqlDateTime non prise en charge : {value} !");
                    datetimeValue = mysqlDateTimeValue.Value;
                }
                return $"\"{datetimeValue.Year:0000}-{datetimeValue.Month:00}-{datetimeValue.Day:00} {datetimeValue.Hour:00}:{datetimeValue.Minute:00}:{datetimeValue.Second:00}\"";
            }
            if (value is SqlCode) return value.ToString();
            throw new NotSupportedException($"Type de valeur non pris en charge : {value.GetType().FullName} !");
        }

        /// <summary>
        /// Tableau reprenant l'ensemble des types de valeurs acceptables lors de la consultation de champ, suite à l'exécution d'une requête de consultation
        /// </summary>
        private static Type[] DbValueTypes { get; } = new Type[]
        {
            typeof(sbyte),
            typeof(byte),
            typeof(short),
            typeof(ushort),
            typeof(int),
            typeof(uint),
            typeof(long),
            typeof(ulong),
            typeof(float),
            typeof(double),
            typeof(decimal),
            typeof(bool),
            typeof(char),
            typeof(string),
            typeof(DateTime)
        };

        /// <summary>
        /// Permet de vérifier si le type générique spécifié est un type acceptable pour une valeur résultant d'une consultation en MySQL
        /// </summary>
        /// <typeparam name="T">Type à tester</typeparam>
        /// <returns>Vrai si le type spécifié est un type de valeur acceptable, sinon faux</returns>
        private static bool IsDbValue<T>()
        {
            return IsDbValue(typeof(T));
        }

        /// <summary>
        /// Permet de vérifier si le type spécifié est un type acceptable pour une valeur résultant d'une consultation en MySQL
        /// </summary>
        /// <param name="type">Type à tester</param>
        /// <returns>Vrai si le type spécifié est un type de valeur acceptable, sinon faux</returns>
        private static bool IsDbValue(Type type)
        {
            if (type == null) return false;
            if (!type.Equals(typeof(string)))
            {
                if (!type.IsValueType) return false;
                if (type.IsEnum) return false;
            }
            return DbValueTypes.Any(t => t.Equals(type));
            /*
            foreach (var t in DbValueTypes)
            {
                if (type.Equals(t)) return true;
            }
            return false;
            */
        }

        /// <summary>
        /// Permet de vérifier si le type de la valeur spécifiée est un type acceptable pour une valeur résultant d'une consultation en MySQL
        /// </summary>
        /// <param name="type">Valeur dont on doit tester le type</param>
        /// <returns>Vrai si le type de la valeur spécifiée est un type de valeur acceptable, sinon faux</returns>
        private static bool IsDbValue(object value)
        {
            if (value == null) return false;
            return IsDbValue(value.GetType());
        }

        /// <summary>
        /// Tente de convertir la valeur "non typée" dans le type attendu
        /// </summary>
        /// <typeparam name="T">Type attendu pour la valeur spécifiée</typeparam>
        /// <param name="objectValue">Valeur "non typée" à convertir</param>
        /// <returns>Valeur convertie dans le type attendu</returns>
        /// <exception cref="Exception">Erreur de conversion</exception>
        private static T ConvertObjectValueToDbValue<T>(object objectValue)
        {
            if (objectValue == null)
            {
                if (!typeof(T).Equals(typeof(string))) throw new Exception($"Null value not valid for expected type : {typeof(T).FullName} !");
            }
            else if (objectValue is string)
            {
                if (!(typeof(T).Equals(typeof(string)) || (typeof(T).Equals(typeof(char)) && ((string)objectValue).Length == 1))) throw new Exception($"Invalid string value relative to expected type ({typeof(T).FullName}) : {objectValue} !");
            }
            else
            {
                if (!(objectValue is T)) throw new Exception($"Invalid value type relative to expected type : {objectValue.GetType().FullName} instead of {typeof(T).FullName} !");
            }
            if ((objectValue is string) && typeof(T).Equals(typeof(char)))
            {
                var stringValue = (string)objectValue;
                return (T)((object)stringValue.FirstOrDefault());
            }
            else
            {
                return (T)objectValue;
            }
        }
    }
}
