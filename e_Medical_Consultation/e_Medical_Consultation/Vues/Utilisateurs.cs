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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

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
            Load += new EventHandler(Utilisateurs_Load);
        }

        private void Utilisateurs_Load(object sender, EventArgs e)
        {
            userPanel.Hide();
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
            motDePasseTextBox.Clear();
            ReinitialiserErreurs();
            nouveauButton.Show();
        }

        private void ChangeIndexListBox(object sender, EventArgs e)
        {
            if (nouveau)
            {
                nouveau = false;
                nouveauButton.Show();
               // motDePassePanel.Hide();
            }

            ReinitialiserErreurs();

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
            ReinitialiserErreurs();
            nomTextBox.Clear();
            prenomTextBox.Clear();
            emailTextBox.Clear();
            telephoneTextBox.Clear();
            dateTimePicker.Value = DateTime.Now;
            adresseTextBox.Clear();
            motDePasseTextBox.Clear();

            nouveau = true;
            nouveauButton.Hide();
            // motDePassePanel.Show();
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
                    string hashedPassword = PasswordHasher.HashPassword(motDePasseTextBox.Text);
                    utilisateurSelect = CreerUtilisateur(emailTextBox.Text, hashedPassword, nomTextBox.Text, prenomTextBox.Text, telephoneTextBox.Text, DateTime.Parse(dateTimePicker.Text), adresseTextBox.Text);
                }
                else
                {
                    utilisateurSelect.Nom = nomTextBox.Text;
                    utilisateurSelect.Prenom = prenomTextBox.Text;
                    utilisateurSelect.Email = emailTextBox.Text;
                    utilisateurSelect.Telephone = telephoneTextBox.Text;
                    utilisateurSelect.DateNaissance = DateTime.Parse(dateTimePicker.Text);
                    utilisateurSelect.Adresse = adresseTextBox.Text;
                    if (!string.IsNullOrWhiteSpace(motDePasseTextBox.Text))
                        utilisateurSelect.MotDePasse = PasswordHasher.HashPassword(motDePasseTextBox.Text); ;
                        
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

        /// <summary>
        /// Permet de valider le formulaire par rapport aux critéres des éléments à valider
        /// </summary>
        /// <returns>Vrai si tous les critéres sont respectés, sinon faux</returns>
        private bool ValiderForm()
        {
            ReinitialiserErreurs();

            // Utiliser une regex pour valider le format de l'adresse e-mail
            string patternEmail = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            // Définir l'expression régulière pour les chiffres uniquement
            string patternTel = @"^\d+$";

            if (nomTextBox.Text.Length <= 0)
            {
                nomErrorProvider.SetError(nomTextBox, "Le Nom doit avoir minimun 1 caractére !");
                return false;
            } 
            else if (prenomTextBox.Text.Length <= 0)
            {
                prenomErrorProvider.SetError(prenomTextBox, "Le Prénom doit avoir minimun 1 caractére !");
                return false;
            }
            else if (telephoneTextBox.Text.Length <= 0 || !Regex.IsMatch(telephoneTextBox.Text, patternTel))
            {
                telErrorProvider.SetError(telephoneTextBox, "Le Téléphone ne peut contenir que des chiffres et minimun 5 !");
                return false;
            }
            else if(emailTextBox.Text.Length <= 0 || !Regex.IsMatch(emailTextBox.Text, patternEmail))
            {
                emailErrorProvider.SetError(emailTextBox, "L'Email doit être au format comme exemple@gmail.com !");
                return false;
            }
            else if(adresseTextBox.Text.Length <= 0)
            {
                adresseErrorProvider.SetError(adresseTextBox, "L'Adresse doit avoir minimun 1 caractére !");
                return false;
            }
                

            if ((nouveau && motDePasseTextBox.Text.Length < 5) || (!nouveau && motDePasseTextBox.Text.Length > 0 && motDePasseTextBox.Text.Length < 5))
            {
                mdpErrorProvider.SetError(motDePasseTextBox, "Le Mot de passe doit avoir minimun 5 caractéres !");
                return false;
            }

            return true;
        }

        /// <summary>
        /// Permet de réinitialiser les controls d'erreurs des éléments à valider
        /// </summary>
        private void ReinitialiserErreurs()
        {
            nomErrorProvider.Clear();
            prenomErrorProvider.Clear();
            emailErrorProvider.Clear();
            telErrorProvider.Clear();
            adresseErrorProvider.Clear();
            mdpErrorProvider.Clear();
        }
    }
}
