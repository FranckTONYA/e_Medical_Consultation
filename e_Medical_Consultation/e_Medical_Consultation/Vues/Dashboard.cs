using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsultationMedicale
{
    /// <summary>
    /// Contrôle permettant de gérer la sélection des boules
    /// <para>Il s'agit d'une vue dans une architecture logicielle de type MVC</para>
    /// </summary>
    public partial class Dashboard : UserControl
    {
        /// <summary>
        /// Api de l'application
        /// </summary>
        public ApiConsultationMedicale Api { get; private set; }

        /// <summary>
        /// Permet de définir "tardivement" la référence de l'Api des données actives de l'application
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
        /// Constructeur
        /// </summary>
        /// <param name="api">Référence de l'API donnant accès aux données actives de l'application</param>
        public Dashboard(ApiConsultationMedicale api = null)
        {
            InitializeComponent();
            Api = api;
        }

      
        private void AfficherConsultations(object sender, EventArgs e)
        {

        }

        private void AfficherLesRendezVous(object sender, EventArgs e)
        {

        }

        private void AfficherDossiersPatients(object sender, EventArgs e)
        {

        }

        private void AfficherUtilisateurs(object sender, EventArgs e)
        {

        }
    }
}
