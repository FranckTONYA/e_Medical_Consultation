using System;
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
    public partial class Connexion : UserControl, IEtapeConfection
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
        public EtapeConfection Identifiant => EtapeConfection.Finalisation;

        /// <summary>
        /// Indique le titre d'étape de confection correspondant à ce contrôle
        /// </summary>
        public string Titre => PourCommande ? "Finalisation de la confection" : "Récapitulatif de la confection";

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
        public string TexteBoutonPrecedent => "Retourner au choix de saupoudrage";

        /// <summary>
        /// Indique le texte du bouton d'étape suivante, sinon null
        /// </summary>
        public string TexteBoutonSuivant => null;

        /// <summary>
        /// Permet d'instancier la vue de l'étape précédant celle-ci
        /// </summary>
        /// <param name="api">Référence de l'API donnant accès au "support" des données actives de l'application</param>
        /// <returns>Nouveau contrôle utilisateur implémentant l'interface IEtapeConfection si possible, sinon null</returns>
        public IEtapeConfection CreerEtapePrecedente(ApiConsultationMedicale api, Modeles.IConfection confection) => new RendezVous(api, confection);

        /// <summary>
        /// Permet d'instancier la vue de l'étape suivant celle-ci
        /// </summary>
        /// <param name="api">Référence de l'API donnant accès au "support" des données actives de l'application</param>
        /// <returns>Nouveau contrôle utilisateur implémentant l'interface IEtapeConfection si possible, sinon null</returns>
        public IEtapeConfection CreerEtapeSuivante(ApiConsultationMedicale api, Modeles.IConfection confection) => null;

        /// <summary>
        /// Référence de l'entité représentant ce qui est en cours de confection
        /// </summary>
        public Modeles.IConfection Confection { get; }

        /// <summary>
        /// Indique si ce récapitulatif correspond à l'étape de finalisation de la confection, menant à la commande
        /// </summary>
        public bool PourCommande { get; }

        /// <summary>
        /// Événement déclenché pour signaler que la confection s'est terminée (à priori par sa commande ... ou l'échec de sa commande)
        /// </summary>
        public event EventHandler ConfectionTerminee;

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="api">Référence de l'API donnant accès au "support" des données actives de l'application</param>
        /// <param name="confection">Référence de l'entité représentant ce qui est en cours de confection</param>
        /// <param name="pourCommande">Indique si ce récapitulatif correspond à l'étape de finalisation de la confection, menant à la commande</param>
        public Connexion(ApiConsultationMedicale api = null, Modeles.IConfection confection = null, bool pourCommande = true)
        {
            InitializeComponent();
            Api = api;
            Confection = confection;
            SelectionValide = true;
            PourCommande = pourCommande;
            buttonCommander.Visible = PourCommande;
            if (PourCommande)
            {
                buttonCommander.Click += (s, e) =>
                {
                    System.Diagnostics.Debug.WriteLine("\nPASSER COMMANDE\n");
                    while (true)
                    {
                        if (Api.CommanderConfection(confection))
                        {
                            MessageBox.Show(
                                "Votre commande a bien été passée auprès de nos services ... et elle sera traîtée rapidement.",
                                $"{this.ParentForm.Text} - Commande envoyée",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                            break;
                        }
                        else
                        {
                            if (MessageBox.Show(
                                "Désolé, suite à une erreur indépendante de notre volonté, votre commande n'a pas pu être passée !\r\n\r\nIl s'agit peut-être d'un problème de communication avec notre serveur...\r\n\r\nVous pouvez soit réessayer, soit abandonner votre commande.",
                                $"{this.ParentForm.Text} - Erreur de commande",
                                MessageBoxButtons.RetryCancel,
                                MessageBoxIcon.Exclamation,
                                MessageBoxDefaultButton.Button1) == DialogResult.Cancel)
                            {
                                break;
                            }
                        }
                    }
                    ConfectionTerminee?.Invoke(this, EventArgs.Empty); // if (ConfectionTerminee != null) ConfectionTerminee(this, EventArgs.Empty);
                };
            }
            RemplirArbreConfection();
        }

        /// <summary>
        /// Permet de remplir l'arbre récupatitulatif de la confection
        /// </summary>
        private void RemplirArbreConfection()
        {
            var policeItalique = new Font(tvwConfection.Font, FontStyle.Italic);
            tvwConfection.Nodes.Clear();
            if (Confection == null) return;
            var noeudSupport = tvwConfection.Nodes.Add("Support");
            var noeud = noeudSupport.Nodes.Add($"Type : {(Confection.TypeSupport != null ? Confection.TypeSupport.Denomination : "indéterminé")}");
            if (Confection.TypeSupport == null) noeud.NodeFont = policeItalique;
            noeud = noeudSupport.Nodes.Add($"Taille : {(Confection.TailleSupport != null ? Confection.TailleSupport.Denomination : "indéterminée")}");
            if (Confection.TailleSupport == null) noeud.NodeFont = policeItalique;
            var noeudBoules = tvwConfection.Nodes.Add($"Boule{(Confection.NombreBoules >= 2 ? "s" : "")} {(Confection.MaximumBoules >= 1 ? $"[{Confection.NombreBoules}/{Confection.MaximumBoules}]" : "")}");
            if (Confection.NombreBoules == 0)
            {
                noeudBoules.Nodes.Add("Aucune").NodeFont = policeItalique;
            }
            else
            {
                foreach (var categorieParfum in Confection.Boules.Select(b => b.Parfum.Categorie).Distinct().OrderBy(c => c.Denomination))
                {
                    var noeudCategorie = noeudBoules.Nodes.Add($"De la catégorie \"{categorieParfum.Denomination}\"");
                    foreach (var boule in Confection.Boules.Where(b => b.Parfum.Categorie.Equals(categorieParfum)).OrderBy(b => b.Parfum.Denomination))
                    {
                        noeudCategorie.Nodes.Add(boule.ToString());
                    }
                }
            }
            var noeudNappage = tvwConfection.Nodes.Add("Nappage");
            if (Confection.Nappage == null)
            {
                noeudNappage.Nodes.Add(Confection.NappageAutorise ? "Aucun" : "Interdit").NodeFont = policeItalique;
            }
            else
            {
                noeudNappage.Nodes.Add(Confection.Nappage.Denomination);
            }
            var noeudSaupoudrage = tvwConfection.Nodes.Add("Saupoudrage");
            if (Confection.CremeFraiche == false)
            {
                if (!Confection.CremeFraicheAutorisee) noeudSaupoudrage.Nodes.Add("Crème fraîche interdite").NodeFont = policeItalique;
            }
            else
            {
                noeudSaupoudrage.Nodes.Add("Crème fraîche");
            }
            if (Confection.Saupoudrage == null)
            {
                noeudSaupoudrage.Nodes.Add("Aucun saupoudrage").NodeFont = policeItalique;
            }
            else
            {
                noeudSaupoudrage.Nodes.Add(Confection.Saupoudrage.Denomination);
            }
            #region Ouverture de toutes les branches
            noeudSupport.ExpandAll();
            noeudBoules.ExpandAll();
            noeudNappage.ExpandAll();
            noeudSaupoudrage.ExpandAll();
            #endregion
        }

        private void Connexion(object sender, EventArgs e)
        {

        }

        private void AfficherAccueil(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }
}
