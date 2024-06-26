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
            /// Motif
            /// </summary>
            string Motif { get; }

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


        }

        /// <summary>
        /// Instancie une Consultation Médicale en fonction des caractéristiques spécifiées
        /// </summary>
        /// <param name="id">Identifiant de la consultation en BD</param>
        /// <param name="motif">Motif de la consultation</param>
        /// <param name="rapport">Rapport de la consultation</param>
        /// <param name="prescription">Prescription de la consultation</param>
        /// <returns>Nouvelle entité Consultation si possible, sinon null</returns>
        public static IConsultation CreerConsultation(int id, string motif, string rapport, string prescription)
        {
            return new Consultation(id, motif, rapport, prescription);
        }

        /// <summary>
        /// Implémente le modèle d'entité d'une Consultation Médicale
        /// </summary>
        private class Consultation : EntiteBase, IConsultation
        {
            /// <summary>
            /// Motif
            /// </summary>
            public string Motif { get; private set; }

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

            public Consultation(int id, string motif, string rapport, string prescription)
                : base(id, $"Consultation Médicale le {DateTime.Now.ToString("d/MM/yyyy à H:mm:ss").Replace('-', '/')}")
            {
                Motif = motif;
                Rapport = rapport;
                Prescription = prescription;
            }
        }
    }

}
