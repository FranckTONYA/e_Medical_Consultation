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
        /// Titre "principal" de la confection d'une crème glacée
        /// </summary>
        public string Titre
        {
            get => m_Titre;
            set
            {
                value = string.IsNullOrWhiteSpace(value) ? string.Empty : value.Trim();
                if (value == m_Titre) return;
                m_Titre = value;
                MettreAJourTitre();
            }
        }

        /// <summary>
        /// Indique l'étape de confection acutelle
        /// </summary>
        public EtapeConfection EtapeActuelle => m_EtapeConfectionActuelle.Identifiant;

        #region Mémorise la référence du contrôle de l'étape actuelle de confection
        /// <summary>
        /// Référence du "UserControl" utilisé par l'étape actuelle de confection
        /// </summary>
        private UserControl m_ControleEtapeActuelle;

        /// <summary>
        /// Référence de l'objet implémentant IEtapeConfection (objet identique, excepté en terme de typage que celui référencé par m_ControleEtapeActuelle)
        /// </summary>
        private IEtapeConfection m_EtapeConfectionActuelle;
        #endregion

        /// <summary>
        /// Entité retenant les données de la confection en cours
        /// </summary>
        public Modeles.IConfection ConfectionEnCours { get; private set; }

        /// <summary>
        /// Permet de réinitialiser la confection
        /// </summary>
        public void InitialiserConfection()
        {
            ConfectionEnCours = Modeles.CreerConfection();
            PlacerControleEtape(new SelectionSupport(Api, ConfectionEnCours));
        }

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
            m_ControleEtapeActuelle = null;
            m_EtapeConfectionActuelle = null;
            buttonSuivant.Enabled = false;
            this.Paint += Confection_Paint;
        }

        /// <summary>
        /// Méthode appelée lors de la première demande de tracé de cette vue
        /// <para>Il s'agit d'une astuce qui permet d'exécuter un id après l'identifiant de(s) constructeur(s) mais avant l'affichage de cet élément de l'interface utilisateur !</para>
        /// </summary>
        /// <param name="sender">Émetteur de l'événement</param>
        /// <param name="ePaint">Décrit les informations relatives à cette événement</param>
        private void Confection_Paint(object sender, PaintEventArgs ePaint)
        {
            this.Paint -= Confection_Paint;
            if (Api == null) return;
            buttonPrecedent.Click += (s, e) =>
            {
                PlacerControleEtape(m_EtapeConfectionActuelle.CreerEtapePrecedente(Api, ConfectionEnCours));
            };
            buttonSuivant.Click += (s, e) =>
            {
                PlacerControleEtape(m_EtapeConfectionActuelle.CreerEtapeSuivante(Api, ConfectionEnCours));
            };
            buttonResume.Click += (s, e) =>
            {
                if (m_ControleEtapeActuelle.Visible)
                {
                    m_ControleEtapeActuelle.Visible = false;
                    tlpPrincipal.Controls.Remove(m_ControleEtapeActuelle);
                    var recapitulatif = new Connexion(Api, ConfectionEnCours, false);
                    recapitulatif.Dock = DockStyle.Fill;
                    tlpPrincipal.Controls.Add(recapitulatif, 1, 1);
                    tlpPrincipal.SetColumnSpan(recapitulatif, 5);
                    tlpPrincipal.SetColumnSpan(m_ControleEtapeActuelle, 5);
                    buttonPrecedent.Enabled = false;
                    buttonSuivant.Enabled = false;

                }
                else
                {
                    tlpPrincipal.Controls.Remove(tlpPrincipal.GetControlFromPosition(1, 1));
                    tlpPrincipal.Controls.Add(m_ControleEtapeActuelle, 1, 1);
                    tlpPrincipal.SetColumnSpan(m_ControleEtapeActuelle, 5);
                    m_ControleEtapeActuelle.Visible = true;
                    buttonPrecedent.Enabled = true;
                    buttonSuivant.Enabled = m_EtapeConfectionActuelle.SelectionValide;
                }
            };
            InitialiserConfection();
            this.Invalidate();
        }

        /// <summary>
        /// Permet de placer et intégrer le nouveau "UserControl" en fonction de l'étape de confection, et ce, correctement
        /// </summary>
        /// <param name="nouveauControle">Nouveau "UserControl" à utiliser <para>Ce "UserControl" doit implémenter IEtapeConfection</para></param>
        /// <returns>Vrai si le placement et l'intégration de ce nouveau contrôle ont réussi, sinon faux</returns>
        private bool PlacerControleEtape(IEtapeConfection nouveauControle)
        {
            if (!(nouveauControle is UserControl)) return false;
            tlpPrincipal.SuspendLayout();
            if (m_ControleEtapeActuelle != null) tlpPrincipal.Controls.Remove(m_ControleEtapeActuelle);
            m_ControleEtapeActuelle = nouveauControle as UserControl;
            m_EtapeConfectionActuelle = nouveauControle;
            tlpPrincipal.Controls.Add(m_ControleEtapeActuelle, 1, 1);
            tlpPrincipal.SetColumnSpan(m_ControleEtapeActuelle, 5);
            m_ControleEtapeActuelle.Margin = labelTitre.Margin;
            m_ControleEtapeActuelle.Dock = DockStyle.Fill;
            m_ControleEtapeActuelle.Enabled = true;
            m_ControleEtapeActuelle.Visible = true;
            m_EtapeConfectionActuelle.ValiditeSelectionAChange += (s, e) =>
            {
                buttonSuivant.Enabled = m_EtapeConfectionActuelle.SelectionValide;
            };
            buttonSuivant.Enabled = m_EtapeConfectionActuelle.SelectionValide;
            var aUneEtapePrecedente = !string.IsNullOrEmpty(m_EtapeConfectionActuelle.TexteBoutonPrecedent);
            var aUneEtapeSuivante = !string.IsNullOrEmpty(m_EtapeConfectionActuelle.TexteBoutonSuivant);
            if (aUneEtapePrecedente) buttonPrecedent.Text = m_EtapeConfectionActuelle.TexteBoutonPrecedent;
            if (aUneEtapeSuivante) buttonSuivant.Text = m_EtapeConfectionActuelle.TexteBoutonSuivant;
            buttonPrecedent.Visible = aUneEtapePrecedente;
            buttonResume.Visible = aUneEtapeSuivante;
            buttonSuivant.Visible = aUneEtapeSuivante;
            tlpPrincipal.ResumeLayout(true);
            MettreAJourTitre();
            if (m_ControleEtapeActuelle is Connexion)
            {
                (m_ControleEtapeActuelle as Connexion).ConfectionTerminee += (s, e) =>
                {
                    InitialiserConfection();
                };
            }
            return true;
        }

        /// <summary>
        /// Met à jour le texte du titre de cette confection
        /// </summary>
        private void MettreAJourTitre()
        {
            StringBuilder titre = new StringBuilder();
            if (!string.IsNullOrEmpty(m_Titre)) titre.Append(m_Titre);
            if (m_EtapeConfectionActuelle != null)
            {
                if (titre.Length > 0) titre.Append(" - ");
                titre.Append(m_EtapeConfectionActuelle.Titre);
            }
            labelTitre.Text = titre.ToString();
        }

        private void AfiicherConnexionMedecin(object sender, EventArgs e)
        {

        }

        private void AfficherConnexionAdmin(object sender, EventArgs e)
        {

        }

        private void AfficherConnexionPatient(object sender, EventArgs e)
        {

        }
    }
}
