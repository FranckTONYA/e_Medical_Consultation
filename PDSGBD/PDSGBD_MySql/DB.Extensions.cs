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
    public static class DBExtensions
    {
        /// <summary>
        /// Indique que ce type de requête est de type action
        /// </summary>
        /// <param name="queryType">Type de requête à tester</param>
        /// <returns>Vrai si ce type de requête est de type action, sinon faux</returns>
        public static bool IsUpdateQuery(this DB.QueryType queryType)
        {
            return (int)queryType >= (int)DB.FirstActionQueryType;
        }

        /// <summary>
        /// Indique que ce type de requête est de type consultation
        /// </summary>
        /// <param name="queryType">Type de requête à tester</param>
        /// <returns>Vrai si ce type de requête est de type consultation, sinon faux</returns>
        public static bool IsReadQuery(this DB.QueryType queryType)
        {
            return ((int)queryType > (int)DB.QueryType.Unknown) && ((int)queryType < (int)DB.FirstActionQueryType);
        }
    }
}
