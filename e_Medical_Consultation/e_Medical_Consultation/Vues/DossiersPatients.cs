using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ConsultationMedicale.Modeles;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ConsultationMedicale
{
    /// <summary>
    /// Contrôle permettant de gérer les dossiers patients dans l'application
    /// <para>Il s'agit d'une vue dans une architecture logicielle de type MVC</para>
    /// </summary>
    public partial class DossiersPatients : UserControl
    {
        /// <summary>
        /// Api de Consultation, et donc des données actives de l'application
        /// </summary>
        public ApiConsultationMedicale Api { get; private set; }


        /// <summary>
        /// Référence de dossier utilisateur selectionné actuellement
        /// </summary>
        private IDossierPatient dossierSelect;

        /// <summary>
        /// Permet de définir "tardivement" la référence de l'Api de Consultation servant de "support" des données actives de l'application
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
        public DossiersPatients(ApiConsultationMedicale api = null)
        {
            InitializeComponent();
            Api = api;
            Load += new EventHandler(DossiersPatients_Load);

        }

        private void DossiersPatients_Load(object sender, EventArgs e)
        {
            AfficherDonnees();
            patientTextBox.Enabled = false;
            nbreConsultTextBox.Enabled = false;
        }

        private void AfficherDonnees()
        {
            IEnumerable IDossierEnum;
            IDossierEnum = Api.EnumererDossiersPatients();
            var listeDossiers = new List<IDossierPatient>();
            foreach (IDossierPatient dossier in IDossierEnum)
            {
                listeDossiers.Add(dossier);
            }
            dossierListBox.DataSource = listeDossiers;
            // TO DO (Ajouter Denomination dans dossier lors de la récupération en BD)
            dossierListBox.DisplayMember = "Denomination";
            ReinitialiserErreurs();
        }

        private void ChangeIndexListBox(object sender, EventArgs e)
        {
            ReinitialiserErreurs();

            dossierSelect = dossierListBox.SelectedItem as IDossierPatient;

            if (dossierSelect != null)
            {
                dossierPanel.Show();
                patientTextBox.Text = $"{dossierSelect.Patient.Nom}  {dossierSelect.Patient.Prenom}";
                descriptionTextBox.Text = dossierSelect.Description;
                nbreConsultTextBox.Text = "0";
                if (dossierSelect.Consultations != null)
                    nbreConsultTextBox.Text = dossierSelect.Consultations.Count().ToString();
            }
        }

        private void Enregistrer(object sender, EventArgs e)
        {
            if (ValiderForm())
            {
                bool result = SauvegarderDossier();
                if (result)
                {
                    dossierListBox.DataSource = null;
                    AfficherDonnees();
                    MessageBox.Show("L'élément a bien été sauvegardé", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Probléme rencontré lors de l'enregistrement de l'élément", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Permet de sauvegarder un Dossier Utilisateur en Base de données
        /// </summary>
        /// <returns>Vrai si la sauvegarde a été correctement éffectuée, sinon faux</returns>
        private bool SauvegarderDossier()
        {
            dossierSelect.Description = descriptionTextBox.Text;

            return Api.SauvegarderDossier(dossierSelect);
        }

        /// <summary>
        /// Permet de valider le formulaire par rapport aux critéres des éléments à valider
        /// </summary>
        /// <returns>Vrai si tous les critéres sont respectés, sinon faux</returns>
        private bool ValiderForm()
        {
            ReinitialiserErreurs();

            return true;
        }

        /// <summary>
        /// Permet de réinitialiser les controls d'erreurs des éléments à valider
        /// </summary>
        private void ReinitialiserErreurs()
        {
            descriptionErrorProvider.Clear();
        }
    }

}
