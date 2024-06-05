using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Debug = System.Diagnostics.Debug;

namespace ConsultationMedicale
{
    /// <summary>
    /// Contient le point d'entrée de l'application, ainsi que l'accès aux "services globaux"
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Api de la Consultation Médicale (utilisée pour interroger le serveur)
        /// </summary>
        public static ApiConsultationMedicale Api { get; } = new ApiConsultationMedicale(PDSGBD.MySql.DB.Settings.Create("u_consultation", "tPe0YVS1rOBbwaFhAQ", "consultation"));

        /// <summary>
        /// Point d'entrée de l'application
        /// </summary>
        [STAThread]
        private static void Main()
        {
            TesterApi();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Principal(Api));
        }

        /// <summary>
        /// Code permettant de tester le bon fonctionnement de la partie client interrogeant le service de gestion des données, côté serveur
        /// </summary>
        private static void TesterApi()
        {
            Debug.WriteLine("\nLISTE DES TYPES DE SUPPORT\n");
            foreach (var typeSupport in Api.EnumererTypesSupport())
            {
                Debug.WriteLine($"{typeSupport.Id} - {typeSupport.Denomination} - {(typeSupport.AutoriseNappage ? "nappage autorisé" : "nappage interdit")} - {(typeSupport.AutoriseCremeFraiche ? "crème fraîche autorisée" : "crème fraîche interdite")}");
            }
            Debug.WriteLine("\nLISTE DES TYPES DE SUPPORT AVEC INFORMATIONS DES TAILLES");
            foreach (var typeSupport in Api.EnumererTypesSupport(true))
            {
                Debug.WriteLine($"\n{typeSupport.Id} - {typeSupport.Denomination} - {(typeSupport.AutoriseNappage ? "nappage autorisé" : "nappage interdit")} - {(typeSupport.AutoriseCremeFraiche ? "crème fraîche autorisée" : "crème fraîche interdite")} - {((typeSupport.Tailles.Count >= 2) ? $"{typeSupport.Tailles.Count} tailles disponibles" : "une seule taille disponible")} :");
                foreach (var tailleSupport in typeSupport.Tailles)
                {
                    Debug.WriteLine($"* {tailleSupport.Id} - {tailleSupport.Denomination} - {tailleSupport.MaximumBoules} boule(s) au maximum");
                }
            }
            Debug.WriteLine("\nLISTE DES CATÉGORIES DE PARFUM\n");
            foreach (var categorieParfum in Api.EnumererCategoriesParfum())
            {
                Debug.WriteLine($"{categorieParfum.Id} - {categorieParfum.Denomination}");
            }
            Debug.WriteLine("\nLISTE DES CATÉGORIES DE PARFUM AVEC INFORMATIONS DES PARFUMS");
            foreach (var categorieParfum in Api.EnumererCategoriesParfum(true))
            {
                Debug.WriteLine($"\n{categorieParfum.Id} - {categorieParfum.Denomination} - {((categorieParfum.Parfums.Count >= 2) ? $"{categorieParfum.Parfums.Count} parfums de glace disponibles" : "un seul parfum de glace disponible")} :");
                foreach (var parfum in categorieParfum.Parfums)
                {
                    Debug.WriteLine($"* {parfum.Id} - {parfum.Denomination}");
                }
            }
            Debug.WriteLine("\nLISTE DES NAPPAGES\n");
            foreach (var nappage in Api.EnumererNappages())
            {
                Debug.WriteLine($"{nappage.Id} - {nappage.Denomination}");
            }
            Debug.WriteLine("\nLISTE DES SAUPOUDRAGES\n");
            foreach (var saupoudrage in Api.EnumererSaupoudrages())
            {
                Debug.WriteLine($"{saupoudrage.Id} - {saupoudrage.Denomination}");
            }
        }
    }
}
