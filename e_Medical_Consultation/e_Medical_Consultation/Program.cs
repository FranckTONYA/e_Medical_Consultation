using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Debug = System.Diagnostics.Debug;

namespace ConsultationMedicale.Controleurs
{
    /// <summary>
    /// Contient le point d'entrée de l'application, ainsi que l'accès aux "services globaux"
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Api de la Consultation Médicale (utilisée pour interroger le serveur)
        /// </summary>
        public static ApiConsultationMedicale Api { get; } = new ApiConsultationMedicale(PDSGBD.MySql.DB.Settings.Create("u_consultation", "YY836O3eew!Vy0OQ", "consultation"));

        /// <summary>
        /// Point d'entrée de l'application
        /// </summary>
        [STAThread]
        private static void Main()
        {
            TesterApi();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            TesterApi();
            Application.Run(new Principal(Api));
        }

        /// <summary>
        /// Code permettant de tester le bon fonctionnement de la partie client interrogeant le service de gestion des données, côté serveur
        /// </summary>
        private static void TesterApi()
        {
            Debug.WriteLine("\nLISTE DES UTILISATEURS\n");
            foreach (var utilisateur in Api.EnumererUtilisateurs())
            {
                Debug.WriteLine($"{utilisateur.Id} - {utilisateur.Denomination} - {utilisateur.Email} - {utilisateur.MotDePasse} - {utilisateur.Nom} - {utilisateur.Prenom} - {utilisateur.Token} - {utilisateur.Telephone} - {utilisateur.DateNaissance} - {utilisateur.Adresse}");
            }
        }
    }
}
