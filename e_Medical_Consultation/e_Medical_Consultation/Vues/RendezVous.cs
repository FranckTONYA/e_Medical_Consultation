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
    public partial class RendezVous : UserControl, IEtapeConfection
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
        /// Identifiant de cette étape de confection
        /// </summary>
        public EtapeConfection Identifiant => EtapeConfection.SelectionSaupoudrage;

        /// <summary>
        /// Indique le titre d'étape de confection correspondant à ce contrôle
        /// </summary>
        public string Titre => "Sélection du saupoudrage";

        /// <summary>
        /// Indique si la sélection est actuellement valide
        /// </summary>
        public bool SelectionValide { get; private set; }

        /// <summary>
        /// Événement déclenché à chaque fois que l'état de validité de la sélection vient de changer
        /// </summary>
        public event EventHandler ValiditeSelectionAChange;

        /// <summary>
        /// Indique le texte du bouton d'étape précedente, sinon null
        /// </summary>
        public string TexteBoutonPrecedent => "Retourner à la sélection du nappage";

        /// <summary>
        /// Indique le texte du bouton d'étape suivante, sinon null
        /// </summary>
        public string TexteBoutonSuivant => "Passer au récapitulatif";

        /// <summary>
        /// Permet d'instancier la vue de l'étape précédant celle-ci
        /// </summary>
        /// <param name="api">Référence de l'API donnant accès au "support" des données actives de l'application</param>
        /// <returns>Nouveau contrôle utilisateur implémentant l'interface IEtapeConfection si possible, sinon null</returns>
        public IEtapeConfection CreerEtapePrecedente(ApiConsultationMedicale api, Modeles.IConfection confection) => new Consultations(api, confection);

        /// <summary>
        /// Permet d'instancier la vue de l'étape suivant celle-ci
        /// </summary>
        /// <param name="api">Référence de l'API donnant accès au "support" des données actives de l'application</param>
        /// <returns>Nouveau contrôle utilisateur implémentant l'interface IEtapeConfection si possible, sinon null</returns>
        public IEtapeConfection CreerEtapeSuivante(ApiConsultationMedicale api, Modeles.IConfection confection) => new Connexion(api,confection);

        /// <summary>
        /// Saupoudrage sélectionné (ou null)
        /// </summary>
        public Modeles.ISaupoudrage SaupoudrageSelectionne => (Confection != null) ? Confection.Saupoudrage : null;

        /// <summary>
        /// Référence de l'entité représentant ce qui est en cours de confection
        /// </summary>
        public Modeles.IConfection Confection { get; }

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="api">Référence de l'API donnant accès au "support" des données actives de l'application</param>
        /// <param name="confection">Référence de l'entité représentant ce qui est en cours de confection</param>
        public RendezVous(ApiConsultationMedicale api = null, Modeles.IConfection confection = null)
        {
            InitializeComponent();
            Api = api;
            Confection = confection;
            SelectionValide = true;
            groupSaupoudrage.OnCheckedItemChanged += (s, e) =>
            {
                if (groupSaupoudrage.CheckedItem is Modeles.ISaupoudrage)
                {
                    Confection.DefinirSaupoudrage(groupSaupoudrage.CheckedItem as Modeles.ISaupoudrage);
                }
                else
                {
                    Confection.DefinirSaupoudrage(null);
                }
            };
            RemplirListeSaupoudrages();
            groupSaupoudrage.CheckedItem = Confection.Saupoudrage;
            if (groupSaupoudrage.CheckedIndex < 0) groupSaupoudrage.CheckedIndex = 0;
            checkCremeFraiche.CheckedChanged += (s, e) =>
            {
                Confection.DefinirCremeFraiche(checkCremeFraiche.Checked);
            };
            checkCremeFraiche.Enabled = Confection.CremeFraicheAutorisee;
            checkCremeFraiche.Checked = Confection.CremeFraicheAutorisee && Confection.CremeFraiche;
        }

        /// <summary>
        /// Permet de remplir/rafraichir la liste des nappages
        /// </summary>
        private void RemplirListeSaupoudrages()
        {
            groupSaupoudrage.ClearItems();
            groupSaupoudrage.AddItem("Aucun saupoudrage");
            foreach (var saupoudrage in Api.EnumererSaupoudrages())
            {
                groupSaupoudrage.AddItem(saupoudrage);
            }
        }

        private void AfficherRDV(object sender, EventArgs e)
        {

        }
    }
}
