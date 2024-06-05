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
    /// Contient les modèles d'entités dans l'application
    /// </summary>
    public static partial class Modeles
    {
        /// <summary>
        /// Définit l'Hopital de l'application
        /// </summary>
        public interface IHopital : IEntiteBase
        {
            /// <summary>
            /// Nom
            /// </summary>
            string Nom { get; }

            /// <summary>
            /// Adresse
            /// </summary>
            string Adresse { get; }

            /// <summary>
            /// Description
            /// </summary>
            string Description { get; }

            /// <summary>
            /// Utilisateurs de l'Hopital
            /// </summary>
            IEnumerable<IUtilisateur> Utilisateurs { get; }


            /// <summary>
            /// Permet d'ajouter un utilisateur à l'hopital spécifié
            /// </summary>
            /// <param name="utilisateur">Utilisateur de cet hopital </param>
            /// <returns>Vrai si l'ajout a pu se faire, sinon faux</returns>
            bool AjouterUtilisateur(IUtilisateur utilisateur);

            /// <summary>
            /// Permet de retirer un utilisateur à l'hopital spécifié
            /// </summary>
            /// <param name="utilisateur">Utilisateur de l'hopital à retirer</param>
            /// <returns>Vrai si le retrait a pu se faire, sinon faux</returns>
            bool RetirerUtilisateur(IUtilisateur utilisateur);

        }

        /// <summary>
        /// Instancie l'Hopital en fonction des caractéristiques spécifiées
        /// </summary>
        /// <returns>Nouvelle entité d'Hopital si possible, sinon null</returns>
        public static IHopital CreerHopital()
        {
            return new Hopital();
        }

        /// <summary>
        /// Implémente le modèle d'entité de l'Hopital
        /// </summary>
        private class Hopital : EntiteBase, IHopital
        {

            /// <summary>
            /// Nom
            /// </summary>
            public string Nom { get; private set; }

            /// <summary>
            /// Adresse
            /// </summary>
            public string Adresse { get; private set; }

            /// <summary>
            /// Description
            /// </summary>
            public string Description { get; private set; }


            /// <summary>
            /// Liste des Utilisateurs présents
            /// </summary>
            private List<IUtilisateur> m_Utilisateurs;

            /// <summary>
            /// Utilisateur présents
            /// </summary>
            public IEnumerable<IUtilisateur> Utilisateurs => m_Utilisateurs;


            /// <summary>
            /// Permet d'ajouter un utilisateur de l'Hopital spécifié
            /// </summary>
            /// <param name="utilisateur">Utilisateur de cet hopital</param>
            /// <returns>Vrai si l'ajout a pu se faire, sinon faux</returns>
            public bool AjouterUtilisateur(IUtilisateur utilisateur)
            {
                if (utilisateur == null) return false;
                m_Utilisateurs.Add(utilisateur);
                return true;
            }

            /// <summary>
            /// Permet de retirer un Utilisateur du l'hopital spécifié
            /// </summary>
            /// <param name="utilisateur">Utilisateur de l'hopital à retirer</param>
            /// <returns>Vrai si le retrait a pu se faire, sinon faux</returns>
            public bool RetirerUtilisateur(IUtilisateur utilisateur)
            {
                if (utilisateur == null) return false;
                var indiceUtilisateur = m_Utilisateurs.FindIndex(user => user.Equals(utilisateur));
                if (indiceUtilisateur == -1) return false;
                var UtilisateurARetirer = m_Utilisateurs[indiceUtilisateur];
                m_Utilisateurs.RemoveAt(indiceUtilisateur);
                return true;

            }


            /// <summary>
            /// Constructeur
            /// </summary>
            public Hopital()
                : base(EntiteBase.NouveauCode, $"Hopital le {DateTime.Now.ToString("d/MM/yyyy à H:mm:ss").Replace('-', '/')}")
            {
                Nom = null;
                Adresse = null;
                Description = null;
                m_Utilisateurs = new List<IUtilisateur>();
            }
        }
    }

}
