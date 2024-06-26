using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsultationMedicale
{
    public partial class Principal : Form
    {
        Connexion formulaireConnexion;
        public Panel PanelCentral;

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="api">Référence de l'API donnant accès aux données actives de l'application</param>
        public Principal(ApiConsultationMedicale api)
        {
            InitializeComponent();
            Load += new EventHandler(Principal_Load);

            formulaireConnexion = new Connexion(api);
            ConsultationMedicale.PanelCentral = panelCentral;
            ConsultationMedicale.DefinirApi(api);
            PanelCentral = panelCentral;
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            // Calculer la position pour centrer le formulaire en haut
            int screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
            int formWidth = Width;
            int left = (screenWidth - formWidth) / 2;
            Height = Screen.PrimaryScreen.WorkingArea.Height;

            // Positionner le formulaire en haut de l'écran
            this.Location = new Point(left, 0);
        }

        private void ConnexionAdmin(object sender, EventArgs e)
        {
            initialiserConnexion(ConsultationMedicale.Privilege.Administrateur); 
        }

        private void ConnexionMedecin(object sender, EventArgs e)
        {
            initialiserConnexion(ConsultationMedicale.Privilege.Medecin);
        }

        private void ConnexionPatient(object sender, EventArgs e)
        {
            initialiserConnexion(ConsultationMedicale.Privilege.Patient);
        }

        private void initialiserConnexion(ConsultationMedicale.Privilege privilege)
        {
            formulaireConnexion.DefinirPrivilege(privilege);
            ConsultationMedicale.AfficherFormDansPanelCentral(formulaireConnexion);
        }
    }
}
