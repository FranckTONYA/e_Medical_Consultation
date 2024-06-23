using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsultationMedicale
{
    /// <summary>
    /// Définit ce qui est commun à tout les formulaires de l'application
    /// </summary>
    public class ConsultationMedicale
    {
        /// <summary>
        /// Référence de l'utilisateur courant dans l'application
        /// </summary>
        public static Modeles.IUtilisateur Utilisateur { get; set; }

        /// <summary>
        /// Indique si l'utilisateur est connecté ou pas
        /// </summary>
        public static bool UtilisateurEstConnecter { get; set; } = false;

        /// <summary>
        /// Panel central de l'application où afficher des contenus enfants
        /// </summary>
        public static Panel PanelCentral { get; set; }

        /// <summary>
        /// Api de l'application
        /// </summary>
        public static ApiConsultationMedicale Api { get; private set; }


        /// <summary>
        /// Permet de définir "tardivement" la référence de l'Api servant de données actives de l'application
        /// </summary>
        /// <param name="api">Référence de l'API donnant accès aux données actives de l'application</param>
        /// <returns>Vrai si cette initialisation "tardive" a pu se faire, sinon faux</returns>
        public static bool DefinirApi(ApiConsultationMedicale api)
        {
            if ((Api != null) || (api == null)) return false;
            Api = api;
            return true;
        }

        /// <summary>
        /// Permet d'afficher le contenu d'un formulaire dans le panel central de l'application
        /// </summary>
        /// <param name="formulaire">Référence du formulaire à afficher dans le panel central de l'application</param>
        public static void AfficherFormDansPanelCentral(UserControl formulaire)
        {
            PanelCentral.Controls.Clear();
            PanelCentral.Controls.Add(formulaire);

            // Calculer la position pour centrer le formulaire enfant dans le panel
            int x = (PanelCentral.Width - formulaire.Width) / 2;
            int y = 0;

            // Définir la position du formulaire enfant
            formulaire.Location = new Point(x, y);

            formulaire.Show();
        }

        /// <summary>
        /// Permet d'afficher le contenu d'un formulaire dans un panel parent fournit
        /// </summary>
        /// <param name="panelParent">Référence du panel parent où afficher le contenu</param>
        /// <param name="formulaire">Référence du formulaire à afficher dans le panel parent</param>
        public static void AfficherFormDansPanelParent(Panel panelParent, UserControl formulaire)
        {
            panelParent.Controls.Clear();
            panelParent.Controls.Add(formulaire);
            formulaire.Show();

            
        }


        public static void AfficherAccueil(UserControl userControl)
        {
            Form formParent = userControl.FindForm();

            if (formParent != null && formParent is Principal)
            {
                Principal formPrincipal = (Principal)formParent;
                Principal nouveauForm = new Principal(Api);
                Panel PanelCentral = nouveauForm.PanelCentral;
                formPrincipal.Controls.Clear();
                formPrincipal.Controls.Add(PanelCentral);
            }

        }


    }
}
