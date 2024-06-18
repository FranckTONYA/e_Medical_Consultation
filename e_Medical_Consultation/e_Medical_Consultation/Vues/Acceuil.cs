using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ConsultationMedicale
{
    /// <summary>
    /// Contrôle permettant de gérer la confection d'une crème glacée
    /// <para>Il s'agit d'une vue dans une architecture logicielle de type MVC</para>
    /// </summary>
    public partial class Accueil : UserControl
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
        /// Mémorise le titre "principal" de la confection d'une crème glacée
        /// </summary>
        private string m_Titre;


        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public Accueil()
            : this(null)
        {
        }

        /// <summary>
        /// Constructeur
        /// <para>Obligatoire pour le mode Design de Visual Studio</para>
        /// </summary>
        /// <param name="api">Référence de l'API donnant accès au "support" des données actives de l'application</param>
        public Accueil(ApiConsultationMedicale api)
        {
            InitializeComponent();
            Api = api;
        }

       

        private void AfficherConnexionAdmin(object sender, EventArgs e)
        {

        }

        private void AfficherConnexionPatient(object sender, EventArgs e)
        {

        }

        private void AfficherConnexionMedecin(object sender, EventArgs e)
        {

        }
    }
}
