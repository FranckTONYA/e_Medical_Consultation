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
    /// <summary>
    /// Contrôle permettant de gérer la sélection d'un support (type et taille)
    /// <para>Il s'agit d'une vue dans une architecture logicielle de type MVC</para>
    /// </summary>
    public partial class SelectionSupport : UserControl, IEtapeConfection
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
        public EtapeConfection Identifiant => EtapeConfection.SelectionSupport;

        /// <summary>
        /// Indique le titre d'étape de confection correspondant à ce contrôle
        /// </summary>
        public string Titre => "Sélection du support";

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
        public string TexteBoutonPrecedent => null;

        /// <summary>
        /// Indique le texte du bouton d'étape suivante, sinon null
        /// </summary>
        public string TexteBoutonSuivant => "Passer à la sélection des boules";

        /// <summary>
        /// Permet d'instancier la vue de l'étape précédant celle-ci
        /// </summary>
        /// <param name="api">Référence de l'API donnant accès au "support" des données actives de l'application</param>
        /// <param name="confection">Référence de l'entité représentant ce qui est en cours de confection</param>
        /// <returns>Nouveau contrôle utilisateur implémentant l'interface IEtapeConfection si possible, sinon null</returns>
        public IEtapeConfection CreerEtapePrecedente(ApiConsultationMedicale api, Modeles.IConfection confection) => null;

        /// <summary>
        /// Permet d'instancier la vue de l'étape suivant celle-ci
        /// </summary>
        /// <param name="api">Référence de l'API donnant accès au "support" des données actives de l'application</param>
        /// <param name="confection">Référence de l'entité représentant ce qui est en cours de confection</param>
        /// <returns>Nouveau contrôle utilisateur implémentant l'interface IEtapeConfection si possible, sinon null</returns>
        public IEtapeConfection CreerEtapeSuivante(ApiConsultationMedicale api, Modeles.IConfection confection) => new Dashboard(api, confection);

        /// <summary>
        /// Référence de l'entité représentant ce qui est en cours de confection
        /// </summary>
        public Modeles.IConfection Confection { get; }

        /// <summary>
        /// Type du support sélectionné (ou null)
        /// </summary>
        public Modeles.ITypeSupport TypeSelectionne => (Confection != null) ? Confection.TypeSupport : null;

        /// <summary>
        /// Taille du support sélectionné (ou null)
        /// </summary>
        public Modeles.ITailleSupport TailleSelectionnee => (Confection != null) ? Confection.TailleSupport : null;

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="api">Référence de l'API donnant accès au "support" des données actives de l'application</param>
        /// <param name="confection">Référence de l'entité représentant ce qui est en cours de confection</param>
        public SelectionSupport(ApiConsultationMedicale api = null, Modeles.IConfection confection = null)
        {
            InitializeComponent();
            Api = api;
            Confection = confection;
            comboType.SelectedIndex = -1;
            SelectionValide = false;
            RemplirListeTypes();
            RemplirListeTailles();
            comboType.SelectedIndexChanged += (s, e) =>
            {
                comboTaille.SelectedIndex = -1;
                RemplirListeTailles();
            };
            comboTaille.SelectedIndexChanged += (s, e) =>
            {
                MettreAJourEtat();
            };
            comboType.SelectedItem = Confection.TypeSupport;
            comboTaille.SelectedItem = Confection.TailleSupport;
        }

        /// <summary>
        /// Permet de remplir/rafraichir la liste des types de support
        /// </summary>
        private void RemplirListeTypes()
        {
            var codeTypePrecedemmentSelectionne = (comboType.SelectedIndex >= 0) ? (comboType.SelectedItem as Modeles.ITypeSupport).Id : -1;
            comboType.Items.Clear();
            foreach (var typeSupport in Api.EnumererTypesSupport())
            {
                comboType.Items.Add(typeSupport);
            }
            var typeAReselectionner = comboType.Items.OfType<Modeles.ITypeSupport>().FirstOrDefault(type => type.Id.Equals(codeTypePrecedemmentSelectionne));
            comboType.SelectedItem = typeAReselectionner;
            if ((codeTypePrecedemmentSelectionne != null) && (comboType.SelectedItem == null)) comboTaille.SelectedIndex = -1;
            RemplirListeTailles();
        }

        /// <summary>
        /// Permet de remplir/rafraichir la liste des tailles de support en fonction du type actuellement sélectionné
        /// </summary>
        private void RemplirListeTailles()
        {
            var codeTaillePrecedemmentSelectionnee = (comboTaille.SelectedIndex >= 0) ? (comboTaille.SelectedItem as Modeles.ITailleSupport).Id : -1;
            comboTaille.Items.Clear();
            var typeSupport = comboType.SelectedItem as Modeles.ITypeSupport;
            if (typeSupport != null)
            {
                foreach (var tailleSupport in Api.EnumererTaillesSupport(typeSupport))
                {
                    comboTaille.Items.Add(tailleSupport);
                }
                var tailleAReselectionner = comboTaille.Items.OfType<Modeles.ITailleSupport>().FirstOrDefault(taille => taille.Id.Equals(codeTaillePrecedemmentSelectionnee));
                comboTaille.SelectedItem = tailleAReselectionner;
            }
            MettreAJourEtat();
        }

        /// <summary>
        /// Met à jour l'état de validité de la sélection, et déclenche l'événement correspondant si nécessaire
        /// </summary>
        private void MettreAJourEtat()
        {
            var typeSelectionne = comboType.SelectedItem as Modeles.ITypeSupport;
            var tailleSelectionnee = comboTaille.SelectedItem as Modeles.ITailleSupport;
            bool selectionEstValide = (comboTaille.SelectedIndex >= 0);
            if (selectionEstValide)
            {
                Confection.DefinirSupport(tailleSelectionnee);
            }
            if (selectionEstValide != SelectionValide)
            {
                SelectionValide = selectionEstValide;
                ValiditeSelectionAChange?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}
