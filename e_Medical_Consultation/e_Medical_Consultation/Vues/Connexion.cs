using System;
using System.Collections;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ConsultationMedicale
{
    /// <summary>
    /// Contrôle permettant de gérer la connexion utilisateur dans l'application
    /// </summary>
    public partial class Connexion : UserControl
    {
        /// <summary>
        /// Api de l'application
        /// </summary>
        public ApiConsultationMedicale Api { get; private set; }

        /// <summary>
        /// Privilège avec lequel l'utilisateur souhaite se connecter
        /// </summary>
        public Privilege privilege { get; private set; }

        /// <summary>
        /// Entité retenant les données de l'utilisateur en cours
        /// </summary>
        public Modeles.IUtilisateur Utilisateur { get; private set; }


        Dashboard formulaireDashboard;


        /// <summary>
        /// Contructeur
        /// <param name="api">Référence de l'API donnant accès aux données actives de l'application</param>
        /// </summary>
        public Connexion(ApiConsultationMedicale api)
        {
            InitializeComponent();
            Api = api;
            formulaireDashboard = new Dashboard(api);
            passwordTextBox.PasswordChar = '*';
        }

        /// <summary>
        /// Permet de définir "tardivement" la référence de l'Api servant de données actives de l'application
        /// </summary>
        /// <param name="api">Référence de l'API donnant accès aux données actives de l'application</param>
        /// <returns>Vrai si cette initialisation "tardive" a pu se faire, sinon faux</returns>
        public bool DefinirApi(ApiConsultationMedicale api)
        {
            if ((Api != null) || (api == null)) return false;
            Api = api;
            return true;
        }

        /// <summary>
        /// Permet de définir le privilège avec lequel l'utilisateur souhaite se connecter
        /// </summary>
        /// <param name="priv">Référence du privilège que l'utilisateur souhaite avoir </param>
        /// <returns>Vrai si la définition a pu se faire, sinon faux</returns>
        public bool DefinirPrivilege(Privilege priv)
        {
            if (privilege == priv) return false;
            privilege = priv;
            return true;
        }

        private void AfficherAccueil(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void Login(object sender, EventArgs e)
        {
            if (!VerificationFormulaire())
            {
               
            }
            IEnumerable IUtilisateurEnum;
            IUtilisateurEnum = Api.EnumererUtilisateurParEmail(emailTextBox.Text);

            if (IUtilisateurEnum == null)
            {

            }

            Utilisateur = Api.EnumererUtilisateurParEmail(emailTextBox.Text).First();

            if (!Utilisateur.Role.Equals(privilege.ToString()))
            {

            }

            if (!Utilisateur.MotDePasse.Equals(passwordTextBox.Text)){

            }
            ConsultationMedicale.Utilisateur = Utilisateur;
            ConsultationMedicale.UtilisateurEstConnecter = true;
            ConsultationMedicale.AfficherFormDansPanelCentral(formulaireDashboard);

        }

        private bool VerificationFormulaire()
        {
            if (emailTextBox.Text.Length < 0 || passwordTextBox.Text.Length < 0 ) return false;
            return true;
        }

        public enum Privilege
        {
            Administrateur,
            Medecin,
            Patient,
            Visiteur
        }
    }
}
