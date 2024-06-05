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
    public partial class DB : IDisposable
    {
        #region Constantes
        /// <summary>
        /// Définit le style de représentation des nombres réels
        /// </summary>
        private const System.Globalization.NumberStyles FloatStyle = System.Globalization.NumberStyles.AllowLeadingSign | System.Globalization.NumberStyles.AllowDecimalPoint;

        /// <summary>
        /// Définit la culture anglophone
        /// </summary>
        private static System.Globalization.CultureInfo EnglishCulture = System.Globalization.CultureInfo.GetCultureInfo("en-US");
        #endregion

        /// <summary>
        /// Référence les paramètres de connexion à utiliser (ou utilisés actuellement)
        /// </summary>
        private Settings m_CurrentSettings;

        /// <summary>
        /// Paramètres de connexion à utiliser (ou utilisés actuellement)
        /// </summary>
        public Settings CurrentSettings
        {
            get => m_CurrentSettings;
            set
            {
                if (value == null) return;
                if (m_Connection != null) return;
                m_CurrentSettings = value;
            }
        }

        /// <summary>
        /// Référence l'objet de connexion au serveur MySQL en fonction des paramètres de connexion actuels
        /// </summary>
        private MySqlConnection m_Connection;

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public DB()
        {
            m_CurrentSettings = null;
            m_Connection = null;
        }

        /// <summary>
        /// Constructeur permettant de spécifier les paramètres de connexion à utiliser
        /// </summary>
        /// <param name="settings">Paramètres de connexion à utiliser</param>
        public DB(Settings settings)
            : this()
        {
            CurrentSettings = settings;
        }

        /// <summary>
        /// Permet de libérer les ressources de cet objet
        /// <para>Méthode faisant partie de l'interface IDisposable</para>
        /// </summary>
        public void Dispose()
        {
            PerformDisconnection();
        }

        /// <summary>
        /// Permet d'établir si nécessaire, et si possible, une connexion au serveur MySQL
        /// </summary>
        /// <returns>Vrai si une connexion est disponible, sinon faux</returns>
        private bool EnsureConnection()
        {
            if (m_Connection != null)
            {
                if (m_Connection.State == System.Data.ConnectionState.Open)
                {
                    return true;
                }
                PerformDisconnection();
            }
            m_Connection = m_CurrentSettings.CreateConnection();
            if (m_Connection == null) return false;
            try
            {
                m_Connection.Open();
            }
            catch (Exception error)
            {
                System.Diagnostics.Debug.WriteLine($"\nDB.EnsureConnection fails to connect with parameters {m_CurrentSettings} !\n{error.Message}\n");
                return false;
            }
            var command = m_CurrentSettings.CreateUseDatabaseCommand(m_Connection);
            if (command == null) return false;
            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception error)
            {
                System.Diagnostics.Debug.WriteLine($"\nDB.EnsureConnection fails to use database {m_CurrentSettings.DatabaseName} !\n{error.Message}\n");
                return false;
            }
            return true;
        }

        /// <summary>
        /// Permet de refermer l'objet de connexion au serveur MySQL en en libérant les ressources
        /// </summary>
        /// <returns>Vrai si l'objet de connexion a pu être libéré, sinon faux</returns>
        private bool PerformDisconnection()
        {
            if (m_Connection == null) return true;
            try
            {
                m_Connection.Dispose();
                m_Connection = null;
            }
            catch (Exception error)
            {
                System.Diagnostics.Debug.WriteLine($"\nDB.PerformDisconnection fails to dispose the connection !\n{error.Message}\n");
                m_Connection = null;
                return false;
            }
            return true;
        }
    }
}
