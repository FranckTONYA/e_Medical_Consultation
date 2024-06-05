using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultationMedicale
{
    /// <summary>
    /// Contient les modèles d'entités de l'application
    /// </summary>
    public static partial class Modeles
    {
        /// <summary>
        /// Définit les propriétés et méthodes communes à tout type d'entité
        /// </summary>
        public interface IEntiteBase : IEquatable<IEntiteBase>
        {
            /// <summary>
            /// Indique si cette entité a été "nouvellement" créée dans l'application
            /// </summary>
            bool EstNouveau { get; }

            /// <summary>
            /// Permet de définir l'identifiant "final" de cette entité "nouvellement" créée dans l'application
            /// </summary>
            /// <param name="id">Identifiant à attribuer à cette entité</param>
            /// <returns>Vrai si la définition de l'identifiant "final" de cette entité "nouvellement" créée dans l'application a pu se faire, sinon faux</returns>
            bool DefinirCodePourNouveau(int id);

            /// <summary>
            /// Identifiant de cette entité
            /// </summary>
            int Id { get; }

            /// <summary>
            /// Dénomination de cette entité
            /// </summary>
            string Denomination { get; }
        }

        /// <summary>
        /// Teste les caractéristiques de base pour une entité
        /// </summary>
        /// <param name="id">Identifiant pour cette entité</param>
        /// <param name="denomination">Dénomination pour cette entité</param>
        /// <returns>Vrai si les caractéristiques de base pour créer cette entité sont valides, sinon faux</returns>
        private static bool TesterCaracteristiquesEntiteBase(ref int id, ref string denomination)
        {
            return TesterCodeEntiteBase(ref id) && TesterDenominationEntiteBase(ref denomination);
        }

        /// <summary>
        /// Teste l'identifiant pour une entité
        /// </summary>
        /// <param name="id">Identifiant pour cette entité</param>
        /// <returns>Vrai si les caractéristiques de base pour créer cette entité sont valides, sinon faux</returns>
        private static bool TesterCodeEntiteBase(ref int id)
        {
            if (id < EntiteBase.NouveauCode) return false;
            return true;
        }

        /// <summary>
        /// Teste la dénomination pour une entité
        /// </summary>
        /// <param name="denomination">Dénomination pour cette entité</param>
        /// <returns>Vrai si les caractéristiques de base pour créer cette entité sont valides, sinon faux</returns>
        private static bool TesterDenominationEntiteBase(ref string denomination)
        {
            if (string.IsNullOrWhiteSpace(denomination)) return false;
            denomination = denomination.Trim();
            return true;
        }

        /// <summary>
        /// Implémente la base de tout modèle d'entité
        /// </summary>
        private class EntiteBase : IEntiteBase
        {
            /// <summary>
            /// Identifiant pour toute nouvelle entité créée dans l'application
            /// </summary>
            public const int NouveauCode = 0;

            /// <summary>
            /// Indique si l'identifiant spécifié correspond à une nouvelle entité créée dans l'application
            /// </summary>
            /// <param name="id">Identifiant à vérifier</param>
            /// <returns>Vrai si l'identifiant spécifié précise une nouvelle entité créée dans l'application</returns>
            public static bool EstNouveauCode(int id) => string.Equals(id, NouveauCode);

            /// <summary>
            /// Indique si cette entité a été "nouvellement" créée dans l'application
            /// </summary>
            public bool EstNouveau => EstNouveauCode(Id);

            /// <summary>
            /// Permet de définir l'identifiant "final" de cette entité "nouvellement" créée dans l'application
            /// </summary>
            /// <param name="id">Identifiant à attribuer à cette entité</param>
            /// <returns>Vrai si la définition de l'identifiant "final" de cette entité "nouvellement" créée dans l'application a pu se faire, sinon faux</returns>
            public bool DefinirCodePourNouveau(int id)
            {
                if (!EstNouveau || !TesterCodeEntiteBase(ref id) || EstNouveauCode(id)) return false;
                Id = id;
                return true;
            }

            /// <summary>
            /// Identifiant de cette entité
            /// </summary>
            public virtual int Id { get; private set; }

            /// <summary>
            /// Dénomination de cette entité
            /// </summary>
            public string Denomination { get; private set; }

            /// <summary>
            /// Constructeur
            /// </summary>
            /// <param name="id">Identifiant de cette entité</param>
            /// <param name="denomination">Dénomination de cette entité</param>
            protected EntiteBase(int id, string denomination)
            {
                Id = id;
                Denomination = denomination;
            }

            /// <summary>
            /// Permet de tester l'égalité de cette entité avec l'autre qui est passée en paramètre
            /// <para>Ce test d'égalité se base sur la comparaison stricte de leur identifiant.</para>
            /// </summary>
            /// <param name="autre">Autre entité à laquelle on compare celle-ci</param>
            /// <returns>Résultat du test d'égalité de leur identifiant si possible, sinon faux</returns>
            public bool Equals(IEntiteBase autre)
            {
                return (autre != null) ? Id.Equals(autre.Id) : false;
            }

            /// <summary>
            /// Permet de tester l'égalité de cette entité avec ce qui est passé en paramètre
            /// <para>Si ce qui est passé en paramètre est une autre entité, alors ce test d'égalité se base sur la comparaison stricte de leur identifiant.</para>
            /// <para>Sinon si ce qui est passé en paramètre est de même nature qu'un id, alors ce test d'égalité se base sur la comparaison stricte de l'identifiant de cette entité avec l'identifiant spécifié.</para>
            /// <para>Dans tout autre cas, cette méthode retourne faux</para>
            /// </summary>
            /// <param name="obj">Ce qui doit être comparé à cette entité</param>
            /// <returns>Résultat du test d'égalité</returns>
            public override bool Equals(object obj)
            {
                if (obj is IEntiteBase)
                {
                    var autre = (IEntiteBase)obj;
                    return Equals(autre);
                }
                else if (obj is int)
                {
                    var autre = (int)obj;
                    return Id.Equals(autre);
                }
                return false;
            }

            /// <summary>
            /// Représente textuellement cette entité
            /// </summary>
            /// <returns>Texte représentant cette entité</returns>
            public override string ToString()
            {
                return Denomination;
            }
        }
    }
}
