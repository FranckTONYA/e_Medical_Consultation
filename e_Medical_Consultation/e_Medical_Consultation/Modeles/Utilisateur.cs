using PDSGBD;
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace ConsultationMedicale
{
    /// <summary>
    /// Contient les modèles d'entités dans l'application
    /// </summary>
    public static partial class Modeles
    {
        /// <summary>
        /// Définit un Utilisateur de l'application
        /// </summary>
        public interface IUtilisateur : IEntiteBase
        {
            /// <summary>
            /// email
            /// </summary>
            string Email { get; }

            /// <summary>
            /// Mot de passe
            /// </summary>
            string MotDePasse { get; }

            /// <summary>
            /// Rôle de l'utilisateur
            /// </summary>
            IRoleUtilisateur Role { get; }

            /// <summary>
            /// Token d'authentification
            /// </summary>
            string Token { get; }

            /// <summary>
            /// Nom
            /// </summary>
            string Nom { get; }

            /// <summary>
            /// Prènom
            /// </summary>
            string Prenom { get; }

            /// <summary>
            /// Date de naissance
            /// </summary>
            DateTime DateNaissance { get; }

            /// <summary>
            /// Téléphone
            /// </summary>
            string Telephone { get; }

            /// <summary>
            /// Adresse
            /// </summary>
            string Adresse { get; }

            /// <summary>
            /// Permet de (re)définir le Rôle de l'Utilisateur
            /// </summary>
            /// <param name="role">Rôle à attribuer à cet Utilisateur</param>
            /// <returns>Vrai si la modification de cette information a pu se faire, sinon faux</returns>
            bool DefinirRole(IRoleUtilisateur role);
        }

        /// <summary>
        /// Instancie un Utilisateur en fonction des caractéristiques spécifiées
        /// </summary>
        /// <returns>Nouvelle entité d'utilisateur si possible, sinon null</returns>
        public static IUtilisateur CreerUtilisateur(int id, string email, string motDePasse, string token, string nom, string prenom, string telephone, DateTime dateNaissance, string adresse)
        {
            return new Utilisateur(id, email, motDePasse, token, nom, prenom, telephone, dateNaissance, adresse );
        }

        /// <summary>
        /// Implémente le modèle d'entité d'un Utilisateur
        /// </summary>
        private class Utilisateur : EntiteBase, IUtilisateur
        {

            /// <summary>
            /// Email
            /// </summary>
            public string Email { get; private set; }

            /// <summary>
            /// Mot de passe
            /// </summary>
            public string MotDePasse { get; private set; }

            /// <summary>
            /// Token de connexion
            /// </summary>
            public string Token { get; private set; }

            /// <summary>
            /// Rôle
            /// </summary>
            public IRoleUtilisateur Role { get; private set; }

            /// <summary>
            /// Nom
            /// </summary>
            public string Nom { get; private set; }

            /// <summary>
            /// Prénom
            /// </summary>
            public string Prenom { get; private set; }

            /// <summary>
            /// Téléphone
            /// </summary>
            public string Telephone { get; private set; }

            /// <summary>
            /// Date de naissance
            /// </summary>
            public DateTime DateNaissance { get; private set; }

            /// <summary>
            /// Adresse
            /// </summary>
            public string Adresse { get; private set; }

            /// <summary>
            /// Constructeur
            /// </summary>
            /// 


            /// <summary>
            /// Permet de (re)définir le Rôle de l'Utilisateur
            /// </summary>
            /// <param name="role">Rôle à attribuer à cet Utilisateur</param>
            /// <returns>Vrai si la modification de cette information a pu se faire, sinon faux</returns>
            public bool DefinirRole(IRoleUtilisateur role)
            {
                if (role == null) return false;
                Role = role;
                return true;
            }

            /// <summary>
            /// Constructeur
            /// </summary>
            /// <param name="id">Identifiant de ce type de support</param>
            /// <param name="email">Email</param>
            /// <param name="motDePasse">Mot de passe</param>
            /// <param name="token">Token de verification</param>
            /// <param name="role">Rôle de l'utilisateur</param>
            /// <param name="nom">Nom</param>
            /// <param name="prenom">Prènom</param>
            /// <param name="telephone">Téléphone</param>
            /// <param name="dateNaissance">Date de naissance</param>
            /// <param name="adresse">adresse</param>
            public Utilisateur(int id, string email, string motDePasse, string token, string nom, string prenom, string telephone, DateTime dateNaissance, string adresse)
                : base(id, nom)
            {
                Email = email;
                MotDePasse = motDePasse;
                Token = token;
                Nom = nom;
                Prenom = prenom;
                Telephone = telephone;
                DateNaissance = dateNaissance;
                Adresse = adresse;
            }

            /// <summary>
            /// Constructeur
            /// </summary>
            /// <param name="id">Identifiant de ce type de support</param>
            /// <param name="email">Email</param>
            /// <param name="motDePasse">Mot de passe</param>
            /// <param name="token">Token de verification</param>
            /// <param name="role">Rôle de l'utilisateur</param>
            /// <param name="nom">Nom</param>
            /// <param name="prenom">Prènom</param>
            /// <param name="telephone">Téléphone</param>
            /// <param name="dateNaissance">Date de naissance</param>
            /// <param name="adresse">adresse</param>
            public Utilisateur(string email, string motDePasse, string token, string nom, string prenom, string telephone, DateTime dateNaissance, string adresse)
                : base(0, $"Utilisateur le {DateTime.Now.ToString("d/MM/yyyy à H:mm:ss").Replace('-', '/')}")
            {
                Email = email;
                MotDePasse = motDePasse;
                Token = token;
                Nom = nom;
                Prenom = prenom;
                Telephone = telephone;
                DateNaissance = dateNaissance;
                Adresse = adresse;
            }


            /*            public Utilisateur()
                            : base(EntiteBase.NouveauCode, $"Utilisateur le {DateTime.Now.ToString("d/MM/yyyy à H:mm:ss").Replace('-', '/')}")
                        {
                            Email = null;
                            MotDePasse = null;
                            Token = null;
                            Role = null;
                            Nom = null;
                            Prenom = null;
                            Telephone = null;
                            DateNaissance = null;
                            Adresse = null;
                        }*/
        }
    }

}
