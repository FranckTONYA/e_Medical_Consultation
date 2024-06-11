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
        /// Définit une Consultation Médicale de l'application
        /// </summary>
        public interface IConsultation : IEntiteBase
        {
            /// <summary>
            /// Rapport
            /// </summary>
            string Rapport { get; }

            /// <summary>
            /// Prescription
            /// </summary>
            string Prescription { get; }

            /// <summary>
            /// Médecin exécutant
            /// </summary>
            IUtilisateur MedecinExecutant { get; }

            /// <summary>
            /// Dossier Patient
            /// </summary>
            IDossierPatient DossierPatient { get; }

            /// <summary>
            /// Les RendezVous du consultation
            /// </summary>
            IEnumerable<IRendezVous> LesRendezVous { get; }

            /// <summary>
            /// Permet de (re)définir le Médecin exécutant
            /// </summary>
            /// <param name="medecinExecutant">Médecin exécutant à attribuer à cette Consultation</param>
            /// <returns>Vrai si la modification de cette information a pu se faire, sinon faux</returns>
            bool DefinirMedecinExecutant(IUtilisateur medecinExecutant);

            /// <summary>
            /// Permet de (re)définir le Dossier Patient
            /// </summary>
            /// <param name="dossierPatient">Dossier Patient à attribuer à cette Consultation</param>
            /// <returns>Vrai si la modification de cette information a pu se faire, sinon faux</returns>
            bool DefinirDossierPatient(IDossierPatient dossierPatient);

            /// <summary>
            /// Permet d'ajouter un Rendez-Vous de consultation spécifiée
            /// </summary>
            /// <param name="RendezVous">Rendez-Vous de ce cette consultation </param>
            /// <returns>Vrai si l'ajout a pu se faire, sinon faux</returns>
            bool AjouterRendezVous(IRendezVous rendezVous);

            /// <summary>
            /// Permet de retirer un RendezVous de consultation spécifiée
            /// </summary>
            /// <param name="rendezVous">Rendez-Vous de la consultation à retirer</param>
            /// <returns>Vrai si le retrait a pu se faire, sinon faux</returns>
            bool RetirerRendezVous(IRendezVous rendezVous);

        }

        /// <summary>
        /// Instancie une Consultation Médicale en fonction des caractéristiques spécifiées
        /// </summary>
        /// <param name="id">Identifiant de la consultation en BD</param>
        /// <param name="prescription">Prescription de la consultation</param>
        /// <param name="rapport">Rapport de la consultation</param>
        /// <returns>Nouvelle entité Consultation si possible, sinon null</returns>
        public static IConsultation CreerConsultation(int id, string prescription, string rapport)
        {
            return new Consultation(id, prescription, rapport);
        }

        /// <summary>
        /// Implémente le modèle d'entité d'une Consultation Médicale
        /// </summary>
        private class Consultation : EntiteBase, IConsultation
        {

            /// <summary>
            /// Rapport
            /// </summary>
            public string Rapport { get; private set; }

            /// <summary>
            /// Prescription
            /// </summary>
            public string Prescription { get; private set; }

            /// <summary>
            /// Médecin exécutant la consultation
            /// </summary>
            public IUtilisateur MedecinExecutant { get; private set; }

            /// <summary>
            /// Dossier Patient
            /// </summary>
            public IDossierPatient DossierPatient { get; private set; }

            /// <summary>
            /// Liste des Rendez-Vous présents
            /// </summary>
            private List<IRendezVous> m_LesRendezVous;

            /// <summary>
            /// Rendez-Vous présents
            /// </summary>
            public IEnumerable<IRendezVous> LesRendezVous => m_LesRendezVous;


            /// <summary>
            /// Permet de (re)définir le Médecin exécutant la consultation
            /// </summary>
            /// <param name="medecinExecutant">Médecin exécutant à attribuer à cette Consultation</param>
            /// <returns>Vrai si la modification de cette information a pu se faire, sinon faux</returns>
            public bool DefinirMedecinExecutant(IUtilisateur medecinExecutant)
            {
                if ((medecinExecutant != null) && (!MedecinExecutant.Role.Nom.Equals("MEDECIN"))) return false;
                MedecinExecutant = medecinExecutant;
                return true;
            }

            /// <summary>
            /// Permet de (re)définir le Dossier Patient
            /// </summary>
            /// <param name="dossierPatient">Dossier Patient à attribuer à cette Consultation</param>
            /// <returns>Vrai si la modification de cette information a pu se faire, sinon faux</returns>
            public bool DefinirDossierPatient(IDossierPatient dossierPatient)
            {
                if (dossierPatient == null) return false;
                DossierPatient = dossierPatient;
                return true;
            }


            /// <summary>
            /// Permet d'ajouter un Rendez-Vous de la consultation spécifiée
            /// </summary>
            /// <param name="rendezVous">Rendez-Vous de cette consultation</param>
            /// <returns>Vrai si l'ajout a pu se faire, sinon faux</returns>
            public bool AjouterRendezVous(IRendezVous rendezVous)
            {
                if (rendezVous == null) return false;
                m_LesRendezVous.Add(rendezVous);
                return true;
            }

            /// <summary>
            /// Permet de retirer un Rendez-Vous de la consultation spécifiée
            /// </summary>
            /// <param name="rendezVous">Rendez-Vous de la consultation à retirer</param>
            /// <returns>Vrai si le retrait a pu se faire, sinon faux</returns>
            public bool RetirerRendezVous(IRendezVous rendezVous)
            {
                if (rendezVous == null) return false;
                var indiceRendezVous = m_LesRendezVous.FindIndex(rdv => rdv.Equals(rendezVous));
                if (indiceRendezVous == -1) return false;
                var rdvARetirer = m_LesRendezVous[indiceRendezVous];
                m_LesRendezVous.RemoveAt(indiceRendezVous);
                return true;

            }

            public Consultation(int id, string prescription, string rapport)
                : base(id, $"Consultation Médicale le {DateTime.Now.ToString("d/MM/yyyy à H:mm:ss").Replace('-', '/')}")
            {
                Prescription = prescription;
                Rapport = rapport;

            }
        }
    }

}
