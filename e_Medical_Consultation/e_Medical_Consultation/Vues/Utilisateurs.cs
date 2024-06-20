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

        public void AfficherDonnees()
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
            IUtilisateur selectedItem = utilisateurListBox.SelectedItem as IUtilisateur;

            if (selectedItem != null)
            {
                userPanel.Show();
                nomTextBox.Text = selectedItem.Nom;
                prenomTextBox.Text = selectedItem.Prenom;
                dateTextBox.Text = selectedItem.DateNaissance.ToString();
                telephoneTextBox.Text = selectedItem.Telephone;
                emailTextBox.Text = selectedItem.Email;
                adresseTextBox.Text = selectedItem.Adresse;
                AfficherRoles(selectedItem);
            }
        }

        public void AfficherRoles(IUtilisateur utilisateur)
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
    }
}
