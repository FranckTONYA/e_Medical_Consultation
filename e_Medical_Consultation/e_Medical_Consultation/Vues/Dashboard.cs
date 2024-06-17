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
    public partial class Dashboard : UserControl, IEtapeConfection
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
        public EtapeConfection Identifiant => EtapeConfection.SelectionBoules;

        /// <summary>
        /// Indique le titre d'étape de confection correspondant à ce contrôle
        /// </summary>
        public string Titre => "Sélection de boule(s)";

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
        public string TexteBoutonPrecedent => "Retourner au choix du support";

        /// <summary>
        /// Indique le texte du bouton d'étape suivante, sinon null
        /// </summary>
        public string TexteBoutonSuivant => "Passer à la sélection du nappage";

        /// <summary>
        /// Permet d'instancier la vue de l'étape précédant celle-ci
        /// </summary>
        /// <param name="api">Référence de l'API donnant accès au "support" des données actives de l'application</param>
        /// <param name="confection">Référence de l'entité représentant ce qui est en cours de confection</param>
        /// <returns>Nouveau contrôle utilisateur implémentant l'interface IEtapeConfection si possible, sinon null</returns>
        public IEtapeConfection CreerEtapePrecedente(ApiConsultationMedicale api, Modeles.IConfection confection) => new SelectionSupport(api, confection);

        /// <summary>
        /// Permet d'instancier la vue de l'étape suivant celle-ci
        /// </summary>
        /// <param name="api">Référence de l'API donnant accès au "support" des données actives de l'application</param>
        /// <param name="confection">Référence de l'entité représentant ce qui est en cours de confection</param>
        /// <returns>Nouveau contrôle utilisateur implémentant l'interface IEtapeConfection si possible, sinon null</returns>
        public IEtapeConfection CreerEtapeSuivante(ApiConsultationMedicale api, Modeles.IConfection confection) => new Consultations(api, confection);

        /// <summary>
        /// Référence de l'entité représentant ce qui est en cours de confection
        /// </summary>
        public Modeles.IConfection Confection { get; }

        /// <summary>
        /// Boules sélectionnées
        /// </summary>
        public IEnumerable<Modeles.IBoule> Boules => Confection.Boules;

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="api">Référence de l'API donnant accès au "support" des données actives de l'application</param>
        /// <param name="confection">Référence de l'entité représentant ce qui est en cours de confection</param>
        public Dashboard(ApiConsultationMedicale api = null, Modeles.IConfection confection = null)
        {
            InitializeComponent();
            Api = api;
            Confection = confection;
            SelectionValide = false;
            RemplirListeCategories();
            RemplirListeParfums();
            comboCategorieParfum.SelectedIndexChanged += (s, e) =>
            {
                listParfum.SelectedIndex = -1;
                RemplirListeParfums();
            };
            listParfum.SelectedIndexChanged += (s, e) =>
            {
                MettreAJourEtat();
            };
            lvwBoules.SelectedIndexChanged += (s, e) =>
            {
                MettreAJourEtat();
            };
            listParfum.DoubleClick += (s, e) =>
            {
                AjouterBoule();
            };
            buttonAjouterBoule.Click += (s, e) =>
            {
                AjouterBoule();
            };
            lvwBoules.DoubleClick += (s, e) =>
            {
                RetirerBoule();
            };
            buttonRetirerBoule.Click += (s, e) =>
            {
                RetirerBoule();
            };
            RemplirListeBoules();
            if (comboCategorieParfum.Items.Count >= 1)
            {
                comboCategorieParfum.SelectedIndex = 0; // Arbitrairement, on sélectionne comme "filtre" des parfums, la première catégorie
            }
            else
            {
                MettreAJourEtat();
            }
            TesterValiditeDeCetteSelection();
        }

        /// <summary>
        /// Permet d'ajouter une boule selon le parfum sélectionné
        /// </summary>
        private void AjouterBoule()
        {
            if (listParfum.SelectedIndex < 0) return;
            var parfum = listParfum.SelectedItem as Modeles.IParfum;
            if (!Confection.AjouterBoule(parfum)) return;
            RemplirListeBoules();
            TesterValiditeDeCetteSelection();
        }

        /// <summary>
        /// Permet de retirer une boule selon la sélection de boule actuelle
        /// </summary>
        private void RetirerBoule()
        {
            if (lvwBoules.SelectedIndices.Count != 1) return;
            var boule = lvwBoules.SelectedItems[0].Tag as Modeles.IBoule;
            var parfum = boule.Parfum;
            if (!Confection.RetirerBoule(parfum)) return;
            RemplirListeBoules();
            TesterValiditeDeCetteSelection();
        }

        /// <summary>
        /// Permet de mettre à jour l'état de validité de cette étape de confection
        /// </summary>
        private void TesterValiditeDeCetteSelection()
        {
            bool selectionEstValide = (Confection.NombreBoules >= 1);
            if (selectionEstValide != SelectionValide)
            {
                SelectionValide = selectionEstValide;
                ValiditeSelectionAChange?.Invoke(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Permet de remplir/rafraichir la liste des catégories de parfums
        /// </summary>
        private void RemplirListeCategories()
        {
            var codeCategoriePrecedemmentSelectionnee = (comboCategorieParfum.SelectedIndex >= 0) ? (comboCategorieParfum.SelectedItem as Modeles.ICategorieParfum).Id : -1;
            comboCategorieParfum.Items.Clear();
            foreach (var categorieParfum in Api.EnumererCategoriesParfum())
            {
                comboCategorieParfum.Items.Add(categorieParfum);
            }
            var categorieAReselectionner = comboCategorieParfum.Items.OfType<Modeles.ICategorieParfum>().FirstOrDefault(categorie => categorie.Id.Equals(codeCategoriePrecedemmentSelectionnee));
            comboCategorieParfum.SelectedItem = categorieAReselectionner;
            RemplirListeParfums();
        }

        /// <summary>
        /// Permet de remplir/rafraichir la liste des parfums en fonction de la catégorie actuellement sélectionnée
        /// </summary>
        private void RemplirListeParfums()
        {
            var codeParfumPrecedemmentSelectionne = (listParfum.SelectedIndex >= 0) ? (listParfum.SelectedItem as Modeles.IParfum).Id : -1;
            listParfum.Items.Clear();
            var categorieParfum = comboCategorieParfum.SelectedItem as Modeles.ICategorieParfum;
            if (categorieParfum != null)
            {
                foreach (var parfum in Api.EnumererParfums(categorieParfum))
                {
                    listParfum.Items.Add(parfum);
                }
                var parfumAReselectionner = listParfum.Items.OfType<Modeles.ITailleSupport>().FirstOrDefault(parfum => parfum.Id.Equals(codeParfumPrecedemmentSelectionne));
                listParfum.SelectedItem = parfumAReselectionner;
            }
            MettreAJourEtat();
        }

        /// <summary>
        /// Permet de remplir/rafraichir la liste des boules actuellement sélectionnées
        /// </summary>
        private void RemplirListeBoules()
        {
            var elementSelectionne = lvwBoules.SelectedItems.OfType<ListViewItem>().FirstOrDefault();
            var boulePrecedemmentSelectionnee = (elementSelectionne != null) ? elementSelectionne.Tag as Modeles.IBoule : null;
            lvwBoules.Items.Clear();
            foreach (var boule in Confection.Boules)
            {
                var nouvelElement = lvwBoules.Items.Add($"{boule.Quantite}");
                nouvelElement.SubItems.Add(boule.Parfum.Denomination);
                nouvelElement.SubItems.Add(boule.Parfum.Categorie.Denomination);
                nouvelElement.Tag = boule;
            }
            lvwBoules.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            if (boulePrecedemmentSelectionnee != null)
            {
                for (int indice = 0; indice < lvwBoules.Items.Count; indice++)
                {
                    if ((lvwBoules.Items[indice].Tag as Modeles.IBoule).Parfum.Equals(boulePrecedemmentSelectionnee.Parfum))
                    {
                        lvwBoules.SelectedIndices.Add(indice);
                        break;
                    }
                }
            }
            MettreAJourEtat();
        }

        /// <summary>
        /// Met à jour l'état de validité de la sélection, et déclenche l'événement correspondant si nécessaire
        /// </summary>
        private void MettreAJourEtat()
        {
            var nombreBoules = Confection.NombreBoules;
            labelCompteurBoules.Text = $"{nombreBoules} / {Confection.MaximumBoules}";
            buttonAjouterBoule.Enabled = (nombreBoules < Confection.MaximumBoules) && (listParfum.SelectedIndex >= 0);
            buttonRetirerBoule.Enabled = (lvwBoules.SelectedIndices.Count == 1);
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
