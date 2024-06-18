using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ConsultationMedicale.Modeles;

namespace ConsultationMedicale
{
    /// <summary>
    /// Contrôle permettant de gérer la sélection d'un saupoudrage, et de crème fraîche
    /// <para>Il s'agit d'une vue dans une architecture logicielle de type MVC</para>
    /// </summary>
    public partial class RendezVous : UserControl
    {
        /// <summary>
        /// Api du Glacier, et donc "support" des données actives de l'application
        /// </summary>
        public ApiConsultationMedicale Api { get; private set; }

        /// <summary>
        /// Permet de définir "tardivement" la référence de l'Api du Glacier servant de "support" des données actives de l'application
        /// </summary>
        /// <param name="api">Référence de l'API donnant accès au "support" des données actives de l'application</param>
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
        /// <param name="api">Référence de l'API donnant accès au "support" des données actives de l'application</param>
        public RendezVous(ApiConsultationMedicale api = null)
        {
            InitializeComponent();
            Api = api;
          
        }

        private void AfficherRDV(object sender, EventArgs e)
        {

        }
    }
}
