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
        /// Définit un Statut de Rendez-Vous dans l'application
        /// </summary>
        public interface IStatutRendezVous : IEntiteBase
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
        /// Instancie un Statut de Rendez-Vous en fonction des caractéristiques spécifiées
        /// </summary>
        /// <returns>Nouvelle entité StatutRendezVous si possible, sinon null</returns>
        public static IStatutRendezVous CreerStatutRendezVous()
        {
            return new StatutRendezVous();
        }

        /// <summary>
        /// Implémente le modèle d'entité d'un Statut de Rendez-Vous
        /// </summary>
        private class StatutRendezVous : EntiteBase, IStatutRendezVous
        {

            /// <summary>
            /// Nom
            /// </summary>
            public string Nom { get; private set; }

            /// <summary>
            /// Description
            /// </summary>
            public string Description { get; private set; }


            public StatutRendezVous()
                : base(EntiteBase.NouveauCode, $"Statut de Rendez-Vous le {DateTime.Now.ToString("d/MM/yyyy à H:mm:ss").Replace('-', '/')}")
            {
                Nom = null;
                Description = null;
            }
        }
    }

}
