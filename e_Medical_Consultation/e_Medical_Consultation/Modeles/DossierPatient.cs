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
        /// Définit un Dossier Patient dans l'application
        /// </summary>
        public interface IDossierPatient : IEntiteBase
        {
            /// <summary>
            /// Description
            /// </summary>
            string Description { get; }

            /// <summary>
            /// Patient
            /// </summary>
            IUtilisateur Patient { get; }

            /// <summary>
            /// Consultations du patient
            /// </summary>
            IEnumerable<IConsultation> Consultations { get; }


            /// <summary>
            /// Permet de (re)définir le Patient du dossier médical
            /// </summary>
            /// <param name="patient">Patient à attribuer à ce Dossier médical</param>
            /// <returns>Vrai si la modification de cette information a pu se faire, sinon faux</returns>
            bool DefinirPatient(IUtilisateur patient);

            /// <summary>
            /// Permet d'ajouter une consutation du Patient spécifié
            /// </summary>
            /// <param name="consultation">Consultation de ce Patient </param>
            /// <returns>Vrai si l'ajout a pu se faire, sinon faux</returns>
            bool AjouterConsultation(IConsultation consultation);

            /// <summary>
            /// Permet de retirer une consultation du Patient spécifié
            /// </summary>
            /// <param name="consultation">Consultation du Patient à retirer</param>
            /// <returns>Vrai si le retrait a pu se faire, sinon faux</returns>
            bool RetirerConsultation(IConsultation consultation);

        }

        /// <summary>
        /// Instancie un Dossier Patient en fonction des caractéristiques spécifiées
        /// </summary>
        /// <returns>Nouvelle entité Dossier Patient si possible, sinon null</returns>
        public static IDossierPatient CreerDossierPatient()
        {
            return new DossierPatient();
        }

        /// <summary>
        /// Implémente le modèle d'entité d'un DossierPatient
        /// </summary>
        private class DossierPatient : EntiteBase, IDossierPatient
        {

            /// <summary>
            /// Description
            /// </summary>
            public string Description { get; private set; }

            /// <summary>
            /// Patient
            /// </summary>
            public IUtilisateur Patient { get; private set; }

            /// <summary>
            /// Liste des Consultations présentes
            /// </summary>
            private List<IConsultation> m_Consultations;

            /// <summary>
            /// Consultation présentes
            /// </summary>
            public IEnumerable<IConsultation> Consultations => m_Consultations;



            /// <summary>
            /// Permet de (re)définir le Patient du dossier médical
            /// </summary>
            /// <param name="patient">Patient à attribuer à ce Dossier Médical</param>
            /// <returns>Vrai si la modification de cette information a pu se faire, sinon faux</returns>
            public bool DefinirPatient(IUtilisateur patient)
            {
                if (patient == null) return false;
                Patient = patient;
                return true;
            }

            /// <summary>
            /// Permet d'ajouter une Consultation du Patient spécifié
            /// </summary>
            /// <param name="consultation">Consultation de ce Patient</param>
            /// <returns>Vrai si l'ajout a pu se faire, sinon faux</returns>
            public bool AjouterConsultation(IConsultation consultation)
            {
                if (consultation == null) return false;
                m_Consultations.Add(consultation);
                return true;
            }

            /// <summary>
            /// Permet de retirer une Consultation du Patient spécifié
            /// </summary>
            /// <param name="consultation">Consultation du Patient à retirer</param>
            /// <returns>Vrai si le retrait a pu se faire, sinon faux</returns>
            public bool RetirerConsultation(IConsultation consultation)
            {
                if (consultation == null) return false;
                var indiceConsultation = m_Consultations.FindIndex(consult => consult.Equals(consultation));
                if (indiceConsultation == -1) return false;
                var consultationARetirer = m_Consultations[indiceConsultation];
                m_Consultations.RemoveAt(indiceConsultation);
                return true;
                
            }


            public DossierPatient()
                : base(EntiteBase.NouveauCode, $"Dossier Patient le {DateTime.Now.ToString("d/MM/yyyy à H:mm:ss").Replace('-', '/')}")
            {
                Description = null;
                Patient = null; 
                m_Consultations = new List<IConsultation>();

            }
        }
    }

}
