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
        /// les paramètres de connexion à un serveur MySQL pour un certain utilisateur, et en se "plaçant" dans une certaine base de données
        /// </summary>
        public class Settings
        {
            /// <summary>
            /// Nom de l'utilisateur MySQL à utiliser pour se connecter au serveur MySQL
            /// </summary>
            public string UserName { get; private set; }

            /// <summary>
            /// Contient le mot de passe (en clair) de l'utilisateur MySQL à utiliser pour se connecter au serveur MySQL
            /// </summary>
            private string m_Password;

            /// <summary>
            /// Mot de passe ("crypté") de l'utilisateur MySQL à utiliser pour se connecter au serveur MySQL
            /// </summary>
            public string Password => new string('*', m_Password.Length);

            /// <summary>
            /// Nom de la base de données à utiliser, une fois connecté au serveur MySQL
            /// </summary>
            public string DatabaseName { get; private set; }

            /// <summary>
            /// Adresse du serveur MySQL
            /// </summary>
            public string ServerAddress { get; private set; }

            /// <summary>
            /// Port de communication du serveur MySQL
            /// </summary>
            public ushort ServerPort { get; private set; }

            /// <summary>
            /// Permet de créer un nouvel objet de connexion au serveur MySQL avec les paramètres enregistrés
            /// </summary>
            /// <returns>Objet de connexion si tout se passe bien, sinon null</returns>
            public MySqlConnection CreateConnection()
            {
                try
                {
                    return new MySqlConnection($"server={ServerAddress};port={ServerPort};user={UserName};password={m_Password}");
                }
                catch (Exception error)
                {
                    System.Diagnostics.Debug.WriteLine($"\nError during creation of a new MySqlConnection object !\n{error.Message}\n");
                    return null;
                }
            }

            /// <summary>
            /// Permet de créer un nouvel objet d'exécution de requête pour indiquer que l'on désire utiliser la base de données spécifiée dans les paramètres enregistrés
            /// </summary>
            /// <param name="connection">Objet de connexion à utiliser pour l'exécution ultérieure de cette commande</param>
            /// <returns>Objet d'exécution de requête si tout se passe bien, sinon null</returns>
            public MySqlCommand CreateUseDatabaseCommand(MySqlConnection connection)
            {
                try
                {
                    if (connection == null) throw new NullReferenceException("Connection object must be defined !");
                    return new MySqlCommand($"USE `{DatabaseName}`;", connection);
                }
                catch (Exception error)
                {
                    System.Diagnostics.Debug.WriteLine($"\nError during creation of a new MySqlCommand object to \"use\" the database !\n{error.Message}\n");
                    return null;
                }
            }

            /// <summary>
            /// Permet d'instancier un objet définissant les paramètres de connexion à un serveur MySQL pour un certain utilisateur, et en se "plaçant" dans une certaine base de données
            /// </summary>
            /// <returns>Nouvel objet de type Settings si les paramètres de connexion semblent valides, sinon null</returns>
            public static Settings Create(string userName, string password, string databaseName, string serverAddress = "localhost", ushort serverPort = 3306)
            {
                if (string.IsNullOrWhiteSpace(userName) || userName.Contains(';') || userName.Contains('=')) return null;
                if (string.IsNullOrWhiteSpace(password) || password.Contains(';') || password.Contains('=')) return null;
                if (string.IsNullOrWhiteSpace(databaseName) || databaseName.Contains('`') || databaseName.Contains(';') || databaseName.Contains("--")) return null;
                if (!ServerAddressIsValid(serverAddress)) return null;
                if (serverPort < 1) return null;
                return new Settings(userName, password, databaseName, serverAddress, serverPort);
            }

            /// <summary>
            /// Constructeur qui permet d'initialiser les membres de ce nouvel objet
            /// </summary>
            /// <param name="userName">Nom d'utilisateur MySQL</param>
            /// <param name="password">Mot de passe de cet utilisateur</param>
            /// <param name="databaseName">Nom de la base de données</param>
            /// <param name="serverAddress">Adresse du serveur MySQL</param>
            /// <param name="serverPort">Port de communication au serveur MySQL</param>
            private Settings(string userName, string password, string databaseName, string serverAddress, ushort serverPort)
            {
                UserName = userName;
                m_Password = password;
                DatabaseName = databaseName;
                ServerAddress = serverAddress;
                ServerPort = serverPort;
            }

            /// <summary>
            /// Permet de vérifier la validité d'une adresse de serveur
            /// <para>Du moins en évitant d'accepter des situations où il est évident que ce n'est pas une adresse serveur, en terme de longueur et surtout en terme de caractère illicite</para>
            /// </summary>
            /// <param name="serverAddress">Adresse de serveur à tester</param>
            /// <returns>Vrai si l'adresse spécifiée semble valide, sinon faux</returns>
            private static bool ServerAddressIsValid(string serverAddress)
            {
                if (string.IsNullOrWhiteSpace(serverAddress)) return false;
                if (serverAddress.Contains(':'))
                {
                    // IPv6
                    if (serverAddress.Equals("::1/128")) return true; // équivalent du localhost
                    if (serverAddress.Length < 3) return false;
                    serverAddress = serverAddress.ToLower();
                    for (int i = 0; i < serverAddress.Length; i++)
                    {
                        if (!(((serverAddress[i] >= '0') && (serverAddress[i] <= '9'))
                             || ((serverAddress[i] >= 'a') && (serverAddress[i] <= 'f'))
                             || (serverAddress[i] == ':')))
                        {
                            return false;
                        }
                    }
                    return true;
                }
                else
                {
                    // IPv4, ou nom de machine sur réseau local, ou nom de machine sur un domaine
                    serverAddress = serverAddress.ToLower();
                    for (int i = 0; i < serverAddress.Length; i++)
                    {
                        if (!(((serverAddress[i] >= 'a') && (serverAddress[i] <= 'z'))
                             || ((serverAddress[i] >= '0') && (serverAddress[i] <= '9'))
                             || (serverAddress[i] == '.') || (serverAddress[i] == '_') || (serverAddress[i] == '-')))
                        {
                            return false;
                        }
                    }
                    return true;
                }
            }

            #region Réécriture des méthodes de la classe de base (Object)
            /// <summary>
            /// Permet de retourner une chaîne représentative de cet objet
            /// </summary>
            /// <returns>Chaîne représentative de cet objet</returns>
            public override string ToString()
            {
                return $"{{ UserName : {UserName} ; Password : {Password} ; DatabaseName : {DatabaseName} ; ServerAddress : {ServerAddress} ; ServerPort : {ServerPort} }}";
            }
            #endregion
        }
    }
}
