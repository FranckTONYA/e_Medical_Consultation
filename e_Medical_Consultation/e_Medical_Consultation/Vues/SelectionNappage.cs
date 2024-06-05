using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Glacier.Modeles;

namespace Glacier
{
    /// <summary>
    /// Contrôle permettant de gérer la sélection d'un nappage
    /// <para>Il s'agit d'une vue dans une architecture logicielle de type MVC</para>
    /// </summary>
    public partial class SelectionNappage : UserControl, IEtapeConfection
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
        public EtapeConfection Identifiant => EtapeConfection.SelectionNappage;

        /// <summary>
        /// Indique le titre d'étape de confection correspondant à ce contrôle
        /// </summary>
        public string Titre => "Sélection du nappage";

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
        public string TexteBoutonPrecedent => "Retourner à la sélection des boules";

        /// <summary>
        /// Indique le texte du bouton d'étape suivante, sinon null
        /// </summary>
        public string TexteBoutonSuivant => "Passer au choix de saupoudrage";

        /// <summary>
        /// Permet d'instancier la vue de l'étape précédant celle-ci
        /// </summary>
        /// <param name="api">Référence de l'API donnant accès au "support" des données actives de l'application</param>
        /// <returns>Nouveau contrôle utilisateur implémentant l'interface IEtapeConfection si possible, sinon null</returns>
        public IEtapeConfection CreerEtapePrecedente(ApiConsultationMedicale api, Modeles.IConfection confection) => new SelectionBoules(api, confection);

        /// <summary>
        /// Permet d'instancier la vue de l'étape suivant celle-ci
        /// </summary>
        /// <param name="api">Référence de l'API donnant accès au "support" des données actives de l'application</param>
        /// <returns>Nouveau contrôle utilisateur implémentant l'interface IEtapeConfection si possible, sinon null</returns>
        public IEtapeConfection CreerEtapeSuivante(ApiConsultationMedicale api, Modeles.IConfection confection) => new SelectionSaupoudrage(api, confection);

        /// <summary>
        /// Nappage sélectionné (ou null)
        /// </summary>
        public Modeles.INappage NappageSelectionne => (Confection != null) ? Confection.Nappage : null;

        /// <summary>
        /// Référence de l'entité représentant ce qui est en cours de confection
        /// </summary>
        public Modeles.IConfection Confection { get; }

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="api">Référence de l'API donnant accès au "support" des données actives de l'application</param>
        /// <param name="confection">Référence de l'entité représentant ce qui est en cours de confection</param>
        public SelectionNappage(ApiConsultationMedicale api = null, Modeles.IConfection confection = null)
        {
            InitializeComponent();
            Api = api;
            Confection = confection;
            SelectionValide = true;
            groupNappage.OnCheckedItemChanged += (s, e) =>
            {
                if (groupNappage.CheckedItem is Modeles.INappage)
                {
                    Confection.DefinirNappage(groupNappage.CheckedItem as Modeles.INappage);
                }
                else
                {
                    Confection.DefinirNappage(null);
                }
            };
            RemplirListeNappages();
            groupNappage.CheckedItem = Confection.Nappage;
            if (groupNappage.CheckedIndex < 0) groupNappage.CheckedIndex = 0;
        }

        /// <summary>
        /// Permet de remplir/rafraichir la liste des nappages
        /// </summary>
        private void RemplirListeNappages()
        {
            var nappageAutorise = Confection.NappageAutorise;
            groupNappage.ClearItems();
            groupNappage.AddItem("Aucun nappage");
            foreach (var nappage in Api.EnumererNappages())
            {
                groupNappage.AddItem(nappage, nappageAutorise);
            }
            if (!nappageAutorise) groupNappage.CheckedIndex = 0;
        }
    }
}
