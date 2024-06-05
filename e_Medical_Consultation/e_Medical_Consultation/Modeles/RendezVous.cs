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
        /// Définit un Rendez-Vous Médical dans l'application
        /// </summary>
        public interface IRendezVous : IEntiteBase
        {
            /// <summary>
            /// Description
            /// </summary>
            string Description { get; }

            /// <summary>
            /// Date
            /// </summary>
            DateTime Date { get; }

            /// <summary>
            /// Durée
            /// </summary>
            int Duree { get; }

            /// <summary>
            /// Statut
            /// </summary>
            STATUT Statut { get; }

            /// <summary>
            /// Consultation liéé au Rendez-Vous
            /// </summary>
            IConsultation Consultation { get; }

            /// <summary>
            /// Permet de (re)définir la Consultation liéé au Rendez-Vous
            /// </summary>
            /// <param name="consultation">Consultation liéé à ce rendez-vous </param>
            /// <returns>Vrai si la modification de cette information a pu se faire, sinon faux</returns>
            bool DefinirConsultation(IConsultation consultation);

        }

        /// <summary>
        /// Instancie unµ Rendez-Vous Médicale en fonction des caractéristiques spécifiées
        /// </summary>
        /// <returns>Nouvelle entité Rendez-Vous si possible, sinon null</returns>
        public static IRendezVous CreerRendezVous()
        {
            return new RendezVous();
        }

        /// <summary>
        /// Implémente le modèle d'entité d'un Rendez-Vous Médicale
        /// </summary>
        private class RendezVous : EntiteBase, IRendezVous
        {

            /// <summary>
            /// Description
            /// </summary>
            public string Description { get; private set; }

            /// <summary>
            /// Date
            /// </summary>
            public DateTime Date { get; private set; }

            /// <summary>
            /// Durée
            /// </summary>
            public int Duree { get; private set; }

            /// <summary>
            /// Statut
            /// </summary>
            public STATUT Statut { get; private set; }

            /// <summary>
            /// Consultation
            /// </summary>
            public IConsultation Consultation { get; private set; }

            /// <summary>
            /// Permet de (re)définir la Consultation
            /// </summary>
            /// <param name="consultation">Consultation liéé à ce rendez-vous</param>
            /// <returns>Vrai si la modification de cette information a pu se faire, sinon faux</returns>
            public bool DefinirConsultation(IConsultation consultation)
            {
                if (consultation == null) return false;
                Consultation = consultation;
                return true;
            }


            public RendezVous()
                : base(EntiteBase.NouveauCode, $"Rendez-Vous Médicale le {DateTime.Now.ToString("d/MM/yyyy à H:mm:ss").Replace('-', '/')}")
            {
                Description = null;
                Date = DateTime.MinValue;
                Duree = 0;
                Statut = STATUT.EN_ATTENTE;
                Consultation = null;

            }
        }
    }


    public enum STATUT
    {
        EN_ATTENTE,
        CONFIRMATION,
        REFUS,
    }
}
