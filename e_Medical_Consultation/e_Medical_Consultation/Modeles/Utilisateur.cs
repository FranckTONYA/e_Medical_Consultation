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
            string DateNaissance { get; }

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
        public static IUtilisateur CreerUtilisateur()
        {
            return new Utilisateur();
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
            public string DateNaissance { get; private set; }

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


            public Utilisateur()
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
            }
        }
    }


    public enum ROLE
    {
        VISITEUR,
        PATIENT,
        MEDECIN,
        ADMINISTRATEUR,
    }
}
