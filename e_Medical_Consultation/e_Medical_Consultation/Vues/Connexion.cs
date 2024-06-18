using System;
using System.Collections;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ConsultationMedicale
{
    /// <summary>
    /// Contrôle permettant de gérer la sélection d'un nappage
    /// <para>Il s'agit d'une vue dans une architecture logicielle de type MVC</para>
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

        /// <summary>
        /// Panel central où afficher le contenu
        /// </summary>
        public Panel panelCentral { get; private set; }

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

        /// <summary>
        /// Permet de définir le panel central où afficher le contenu de ce formulaire
        /// </summary>
        /// <param name="panel">Référence du panel central où afficher le contenu</param>
        /// <returns>Vrai si cette définition a pu se faire, sinon faux</returns>
        public bool DefinirPanelCentral(Panel panel)
        {
            if ( panel == null) return false;
            panelCentral = panel;
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

            AfficherDashboard();

        }

        private bool VerificationFormulaire()
        {
            if (emailTextBox.Text.Length < 0 || passwordTextBox.Text.Length < 0 ) return false;
            return true;
        }

        private void AfficherDashboard()
        {
            panelCentral.Controls.Clear();
            panelCentral.Controls.Add(formulaireDashboard);

            // Calculer la position pour centrer le formulaire enfant dans le panel
            int x = (panelCentral.Width - formulaireDashboard.Width) / 2;
            int y = (panelCentral.Height - formulaireDashboard.Height) / 2;

            // Définir la position du formulaire enfant
            formulaireDashboard.Location = new Point(x, y);

            formulaireDashboard.Show();
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
