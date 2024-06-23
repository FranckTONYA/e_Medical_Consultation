using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ConsultationMedicale.Modeles;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ConsultationMedicale
{
    /// <summary>
    /// Contrôle permettant de gérer les utilisateurs de l'application
    /// <para>Il s'agit d'une vue dans une architecture logicielle de type MVC</para>
    /// </summary>
    public partial class Utilisateurs : UserControl
    {
        /// <summary>
        /// Api de Consultation, et donc "support" des données actives de l'application
        /// </summary>
        public ApiConsultationMedicale Api { get; private set; }

        /// <summary>
        /// Référence de l'utilisateur selectionné actuellement traités
        /// </summary>
        private IUtilisateur utilisateurSelect;

        /// <summary>
        /// Specifie si le formulaire traite un nouvel utilisateur ou pas
        /// </summary>
        private bool nouveau;

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="api">Référence de l'API donnant accès au "support" des données actives de l'application</param>
        public Utilisateurs(ApiConsultationMedicale api = null)
        {
            InitializeComponent();
            Api = api;
            this.Load += new System.EventHandler(this.Utilisateurs_Load);
        }

        private void Utilisateurs_Load(object sender, EventArgs e)
        {
            userPanel.Hide();
            motDePassePanel.Hide();
            AfficherDonnees();
        }

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

        private void AfficherDonnees()
        {
            IEnumerable IUtilisateurEnum;
            IUtilisateurEnum = Api.EnumererUtilisateurs();
            var listeUtilisateurs = new List<IUtilisateur>();
            foreach (IUtilisateur user in IUtilisateurEnum)
            {
                listeUtilisateurs.Add(user);
            }
            utilisateurListBox.DataSource = listeUtilisateurs;
            utilisateurListBox.DisplayMember = "Nom";
        }

        private void ChangeIndexListBox(object sender, EventArgs e)
        {
            if (nouveau)
            {
                nouveau = false;
                nouveauButton.Show();
                motDePassePanel.Hide();
            }

            utilisateurSelect = utilisateurListBox.SelectedItem as IUtilisateur;

            if (utilisateurSelect != null)
            {
                userPanel.Show();
                nomTextBox.Text = utilisateurSelect.Nom;
                prenomTextBox.Text = utilisateurSelect.Prenom;
                dateTimePicker.Text = utilisateurSelect.DateNaissance.ToString();
                telephoneTextBox.Text = utilisateurSelect.Telephone;
                emailTextBox.Text = utilisateurSelect.Email;
                adresseTextBox.Text = utilisateurSelect.Adresse;
                AfficherRoles(utilisateurSelect);
            }
        }

        private void AfficherRoles(IUtilisateur utilisateur)
        {
            IEnumerable IRoleEnum;
            IRoleEnum = Api.EnumererRoles();
            var listeRoles = new List<IRoleUtilisateur>();
            foreach (IRoleUtilisateur role in IRoleEnum)
            {
                listeRoles.Add(role);
            }
            roleComboBox.DataSource = listeRoles;
            roleComboBox.DisplayMember = "Nom";
            roleComboBox.ValueMember = "Nom";

            if (roleComboBox.SelectedValue != null)
            roleComboBox.SelectedValue = utilisateur.Role.Nom;
        }

        private void Enregistrer(object sender, EventArgs e)
        {
            bool result = SauvegarderUtilisateur();
            if (result)
            {
                utilisateurListBox.DataSource = null;
                AfficherDonnees();
            }
            else
            {
                //TO DO
            }
        }

        private void Supprimer(object sender, EventArgs e)
        {
            bool result = Api.SupprimerUtilisateur(utilisateurSelect);
            if (result)
            {
                utilisateurListBox.DataSource = null;
                AfficherDonnees();
            }
            else
            {
                //TO DO
            }
        }

        private void ReinitialiserFormulaire(object sender, EventArgs e)
        {
            nomTextBox.Clear();
            prenomTextBox.Clear();
            emailTextBox.Clear();
            telephoneTextBox.Clear();
            dateTimePicker.Value = DateTime.Now;
            adresseTextBox.Clear();
            motDePasseTextBox.Clear();

            nouveau = true;
            nouveauButton.Hide();
            motDePassePanel.Show();
        }

        /// <summary>
        /// Permet de sauvegarder un Utilisateur en Base de données
        /// </summary>
        /// <returns>Vrai si la sauvegarde a été correctement éffectuée, sinon faux</returns>
        private bool SauvegarderUtilisateur()
        {
            if (ValiderForm())
            {
                if (nouveau)
                {
                    utilisateurSelect = CreerUtilisateur(emailTextBox.Text, motDePasseTextBox.Text, nomTextBox.Text, prenomTextBox.Text, telephoneTextBox.Text, DateTime.Parse(dateTimePicker.Text), adresseTextBox.Text);
                }
                else
                {
                    utilisateurSelect.Nom = nomTextBox.Text;
                    utilisateurSelect.Prenom = prenomTextBox.Text;
                    utilisateurSelect.Email = emailTextBox.Text;
                    utilisateurSelect.Telephone = telephoneTextBox.Text;
                    utilisateurSelect.DateNaissance = DateTime.Parse(dateTimePicker.Text);
                    utilisateurSelect.Adresse = adresseTextBox.Text;
                }

                IRoleUtilisateur roleSelect = roleComboBox.SelectedItem as IRoleUtilisateur;
                utilisateurSelect.Role = roleSelect;
                return Api.SauvegarderUtilisateur(utilisateurSelect, nouveau);
            }
            else
            {
                return false;
            }
        }

        // TO DO
        private bool ValiderForm()
        {
            if (nouveau)
            {
                // TO DO
                return true;
            }
            else
            {
                return true;
            }
        }
    }
}
