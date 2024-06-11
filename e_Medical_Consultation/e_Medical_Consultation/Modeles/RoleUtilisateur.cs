using PDSGBD;
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ConsultationMedicale.Modeles;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace ConsultationMedicale
{
    /// <summary>
    /// Contient les modèles d'entités de l'application
    /// </summary>
    public static partial class Modeles
    {
        /// <summary>
        /// Définit un Rôle Utilisateur dans l'application
        /// </summary>
        public interface IRoleUtilisateur : IEntiteBase
        {
            /// <summary>
            /// Nom
            /// </summary>
            string Nom { get; }

            /// <summary>
            /// Description
            /// </summary>
            string Description { get; }

        }

        /// <summary>
        /// Instancie un Rôle Utilisateur en fonction des caractéristiques spécifiées
        /// </summary>
        /// <returns>Nouvelle entité Rôle Utilisateur si possible, sinon null</returns>
        public static IRoleUtilisateur CreerRoleUtilisateur(int id, string nom, string description)
        {
            return new RoleUtilisateur(id, nom, description);
        }

        /// <summary>
        /// Implémente le modèle d'entité d'un Rôle Utilisateur
        /// </summary>
        private class RoleUtilisateur : EntiteBase, IRoleUtilisateur
        {

            /// <summary>
            /// Nom
            /// </summary>
            public string Nom { get; private set; }

            /// <summary>
            /// Description
            /// </summary>
            public string Description { get; private set; }


            public RoleUtilisateur(int id, string nom, string description)
                : base(id, nom)
            {
                Nom = nom;
                Description = description;
            }

            public RoleUtilisateur(string nom, string description)
                : base(EntiteBase.NouveauCode, nom)
            {
                Nom = nom;
                Description = description;
            }
        }
    }

}
