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
        /// <summary>
        /// Définit (par contrat) ce que l'on attend d'un résultat d'exécution d'une requête d'action
        /// </summary>
        public interface IExecuteResult
        {
            /// <summary>
            /// Indique si l'exécution de la requête d'action a pu se faire correctement
            /// </summary>
            bool Success { get; }

            /// <summary>
            /// Indique si l'exécution de la requête d'action n'a pas pu se faire correctement
            /// </summary>
            bool Failure { get; }

            /// <summary>
            /// Nombre d'enregistrements affectés par l'exécution de la requête d'action
            /// </summary>
            int AffectedRowCount { get; }

            /// <summary>
            /// Identifiant (de type numéro automatique) généré par l'exécution de la requête d'action de type INSERT pour un et un seul enregistrement produit
            /// </summary>
            long LastInsertedId { get; }

            /// <summary>
            /// Message d'erreur (en cas d'échec d'exécution de la requête d'action)
            /// </summary>
            string ErrorMessage { get; }
        }

        /// <summary>
        /// Contient le descriptif d'un résultat d'exécution d'une requête d'action
        /// </summary>
        private class ExecuteResult : IExecuteResult
        {
            /// <summary>
            /// Indique si l'exécution de la requête d'action a pu se faire correctement
            /// </summary>
            public bool Success { get; private set; }

            /// <summary>
            /// Indique si l'exécution de la requête d'action n'a pas pu se faire correctement
            /// </summary>
            public bool Failure => !Success;

            /// <summary>
            /// Nombre d'enregistrements affectés par l'exécution de la requête d'action
            /// </summary>
            public int AffectedRowCount { get; private set; }

            /// <summary>
            /// Identifiant (de type numéro automatique) généré par l'exécution de la requête d'action de type INSERT pour un et un seul enregistrement produit
            /// </summary>
            public long LastInsertedId { get; private set; }

            /// <summary>
            /// Message d'erreur (en cas d'échec d'exécution de la requête d'action)
            /// </summary>
            public string ErrorMessage { get; private set; }

            /// <summary>
            /// Constructeur en cas de réussite d'exécution de la requête d'action
            /// </summary>
            /// <param name="affectedRowCount">Nombre d'enregistrements affectés</param>
            /// <param name="lastInsertedId">Identifiant numéro automatique en cas d'insertion d'un et un seul enregistrement</param>
            public ExecuteResult(int affectedRowCount, long lastInsertedId)
            {
                Success = true;
                AffectedRowCount = affectedRowCount;
                LastInsertedId = lastInsertedId;
                ErrorMessage = null;
            }

            /// <summary>
            /// Constructeur en cas d'échec d'exécution de la requête d'action
            /// </summary>
            /// <param name="errorMessage">Message d'erreur détaillant la raison de cet échec</param>
            public ExecuteResult(string errorMessage)
            {
                Success = false;
                AffectedRowCount = 0;
                LastInsertedId = 0;
                ErrorMessage = errorMessage;
            }

            #region Réécriture des méthodes de la classe de base (Object)
            /// <summary>
            /// Permet de retourner une chaîne représentative de cet objet
            /// </summary>
            /// <returns>Chaîne représentative de cet objet</returns>
            public override string ToString()
            {
                if (Success)
                    return $"{{ Success : {Success} ; AffectedRowCount : {AffectedRowCount} ; LastInsertedId : {LastInsertedId} }}";
                else
                    return $"{{ Success : {Success} ; ErrorMessage : {ErrorMessage} }}";
            }
            #endregion

        }

        /// <summary>
        /// Permet d'exécuter une requête d'action
        /// </summary>
        /// <param name="query">Requête SQL</param>
        /// <param name="parameterValues">Valeurs des parties variables correspondant dans le texte de la requête aux parties variables indicées {0} {1} {2} ...</param>
        /// <returns>Résultat d'exécution de la requête d'action</returns>
        public IExecuteResult Execute(string query, params object[] parameterValues)
        {
            QueryType queryType = QueryType.Unknown;
            string preparedQuery = null;
            try
            {
                if (!EnsureConnection()) throw new Exception("Connection failure !");
                if (!PrepareQuery(out queryType, out preparedQuery, query, parameterValues)) throw new Exception("DB.PrepareQuery fails !");
                if (!queryType.IsUpdateQuery()) throw new Exception("Query type not supported for DB.Execute method !");
                var command = new MySqlCommand(preparedQuery, m_Connection);
                int affectedRowCount = command.ExecuteNonQuery();
                long lastInsertedId = (queryType == QueryType.Insert) && (affectedRowCount == 1) ? command.LastInsertedId : 0;
                return new ExecuteResult(affectedRowCount, lastInsertedId);
            }
            catch (Exception error)
            {
                System.Diagnostics.Debug.WriteLine($"\nDB.Execute fails :\n* query type : {queryType}\n* query to prepare : {query}{string.Join("", parameterValues.Select((v, i) => $"\n* parameter [{i}] : {v}"))}\n* prepared query : {preparedQuery}\n{error.Message}\n");
                return new ExecuteResult(error.Message);
            }
        }
    }
}
