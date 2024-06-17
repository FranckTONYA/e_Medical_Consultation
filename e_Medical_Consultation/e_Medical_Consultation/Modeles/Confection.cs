using PDSGBD;
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsultationMedicale
{
    /// <summary>
    /// Contient les modèles d'entités de l'application
    /// </summary>
    public static partial class Modeles
    {
        /// <summary>
        /// Définit une confection de crème glacée
        /// </summary>
        public interface IConfection : IEntiteBase
        {
            /// <summary>
            /// Type du support
            /// </summary>
            ITypeSupport TypeSupport { get; }

            /// <summary>
            /// Taille du support
            /// </summary>
            ITailleSupport TailleSupport { get; }

            /// <summary>
            /// Maximum de boules autorisé
            /// </summary>
            int MaximumBoules { get; }

            /// <summary>
            /// Indique si le nappage est autorisé
            /// </summary>
            bool NappageAutorise { get; }

            /// <summary>
            /// Indique si l'ajout de crème fraîche est autorisé
            /// </summary>
            bool CremeFraicheAutorisee { get; }

            /// <summary>
            /// Boules présentes
            /// </summary>
            IEnumerable<IBoule> Boules { get; }

            /// <summary>
            /// Nombre de boules présentes
            /// </summary>
            int NombreBoules { get; }

            /// <summary>
            /// Nappage réalisé (ou null en cas d'absence de nappage)
            /// </summary>
            INappage Nappage { get; }

            /// <summary>
            /// Indique si on a ajouté de la crème fraîche
            /// </summary>
            bool CremeFraiche { get; }

            /// <summary>
            /// Saupoudrage réalisé (ou null en cas d'absence de saupoudrage)
            /// </summary>
            ISaupoudrage Saupoudrage { get; }

            /// <summary>
            /// Permet de (re)définir le type et la taille de support
            /// <para>Attention : cette action réinitialise le reste des caractéristiques de la confection !</para>
            /// </summary>
            /// <param name="tailleSupport">Taille du support employé pour cette confection</param>
            /// <returns>Vrai si la modification de cette information a pu se faire, sinon faux</returns>
            bool DefinirSupport(ITailleSupport tailleSupport);

            /// <summary>
            /// Permet d'ajouter une (ou plusieurs) boules du parfum spécifié
            /// </summary>
            /// <param name="parfum">Parfum de cette boule (ou de ces boules)</param>
            /// <param name="quantite">Quantité de boules de ce parfum à ajouter</param>
            /// <returns>Vrai si l'ajout a pu se faire, sinon faux</returns>
            bool AjouterBoule(IParfum parfum, int quantite = 1);

            /// <summary>
            /// Permet de retirer une boule du parfum spécifié
            /// </summary>
            /// <param name="parfum">Parfum de la boule à retirer</param>
            /// <returns>Vrai si le retrait a pu se faire, sinon faux</returns>
            bool RetirerBoule(IParfum parfum);

            /// <summary>
            /// Permet de (re)définir le nappage
            /// </summary>
            /// <param name="nappage">Nappage à attribuer à cette confection</param>
            /// <returns>Vrai si la modification de cette information a pu se faire, sinon faux</returns>
            bool DefinirNappage(INappage nappage);

            /// <summary>
            /// Permet de (re)définir le fait d'ajouter ou non de la crème fraîche
            /// </summary>
            /// <param name="doitEtreAjoutee">Indique si on doit ajouter de la crème fraîche</param>
            /// <returns>Vrai si la modification de cette information a pu se faire, sinon faux</returns>
            bool DefinirCremeFraiche(bool doitEtreAjoutee);

            /// <summary>
            /// Permet de (re)définir le saupoudrage
            /// </summary>
            /// <param name="saupoudrage">Saupoudrage à attribuer à cette confection</param>
            /// <returns>Vrai si la modification de cette information a pu se faire, sinon faux</returns>
            bool DefinirSaupoudrage(ISaupoudrage saupoudrage);
        }

        /// <summary>
        /// Instancie une confection de crème glacée en fonction des caractéristiques spécifiées
        /// </summary>
        /// <returns>Nouvelle entité de confection de crème glacée si possible, sinon null</returns>
        public static IConfection CreerConfection()
        {
            return new Confection();
        }

        /// <summary>
        /// Implémente le modèle d'entité d'une confection de crème glacée
        /// </summary>
        private class Confection : EntiteBase, IConfection
        {
            /// <summary>
            /// Type du support
            /// </summary>
            public ITypeSupport TypeSupport => (TailleSupport != null) ? TailleSupport.Type : null;

            /// <summary>
            /// Taille du support
            /// </summary>
            public ITailleSupport TailleSupport { get; private set; }

            /// <summary>
            /// Maximum de boules autorisé
            /// </summary>
            public int MaximumBoules => (TailleSupport != null) ? TailleSupport.MaximumBoules : 0;

            /// <summary>
            /// Indique si le nappage est autorisé
            /// </summary>
            public bool NappageAutorise => (TailleSupport != null) ? TailleSupport.Type.AutoriseNappage : false;

            /// <summary>
            /// Indique si l'ajout de crème fraîche est autorisé
            /// </summary>
            public bool CremeFraicheAutorisee => (TailleSupport != null) ? TailleSupport.Type.AutoriseCremeFraiche : false;

            /// <summary>
            /// Liste des boules présentes
            /// </summary>
            private List<IBoule> m_Boules;

            /// <summary>
            /// Boules présentes
            /// </summary>
            public IEnumerable<IBoule> Boules => m_Boules;

            /// <summary>
            /// Nombre de boules présentes
            /// </summary>
            public int NombreBoules => m_Boules.Sum(boule => boule.Quantite);

            /// <summary>
            /// Nappage réalisé (ou null en cas d'absence de nappage)
            /// </summary>
            public INappage Nappage { get; private set; }

            /// <summary>
            /// Indique si on a ajouté de la crème fraîche
            /// </summary>
            public bool CremeFraiche { get; private set; }

            /// <summary>
            /// Saupoudrage réalisé (ou null en cas d'absence de saupoudrage)
            /// </summary>
            public ISaupoudrage Saupoudrage { get; private set; }

            /// <summary>
            /// Permet de (re)définir le type et la taille de support
            /// </summary>
            /// <param name="tailleSupport">Taille du support employé pour cette confection</param>
            /// <returns>Vrai si la modification de cette information a pu se faire, sinon faux</returns>
            public bool DefinirSupport(ITailleSupport tailleSupport)
            {
                TailleSupport = tailleSupport;
                if (TailleSupport == null)
                {
                    m_Boules.Clear();
                    Nappage = null;
                    CremeFraiche = false;
                    Saupoudrage = null;
                }
                else
                {
                    while (NombreBoules > MaximumBoules) RetirerBoule(m_Boules[m_Boules.Count - 1].Parfum);
                    if (!NappageAutorise) Nappage = null;
                    if (!CremeFraicheAutorisee) CremeFraiche = false;
                }
                return true;
            }

            /// <summary>
            /// Permet d'ajouter une (ou plusieurs) boules du parfum spécifié
            /// </summary>
            /// <param name="parfum">Parfum de cette boule (ou de ces boules)</param>
            /// <param name="quantite">Quantité de boules de ce parfum à ajouter</param>
            /// <returns>Vrai si l'ajout a pu se faire, sinon faux</returns>
            public bool AjouterBoule(IParfum parfum, int quantite = 1)
            {
                if (parfum == null) return false;
                var bouleParfum = m_Boules.FirstOrDefault(boule => boule.Parfum.Equals(parfum));
                if (bouleParfum == null)
                {
                    bouleParfum = CreerBoule(this, parfum, quantite);
                    if (bouleParfum == null) return false;
                    m_Boules.Add(bouleParfum);
                    return true;
                }
                else
                {
                    return bouleParfum.IncrementerQuantite(quantite);
                }
            }

            /// <summary>
            /// Permet de retirer une boule du parfum spécifié
            /// </summary>
            /// <param name="parfum">Parfum de la boule à retirer</param>
            /// <returns>Vrai si le retrait a pu se faire, sinon faux</returns>
            public bool RetirerBoule(IParfum parfum)
            {
                if (parfum == null) return false;
                var indiceBoule = m_Boules.FindIndex(boule => boule.Parfum.Equals(parfum));
                if (indiceBoule == -1) return false;
                var bouleParfum = m_Boules[indiceBoule];
                if (!bouleParfum.DecrementerQuantite()) return false;
                if (bouleParfum.Quantite >= 1) return true;
                m_Boules.RemoveAt(indiceBoule);
                return true;
                /*
                if (parfum == null) return false;
                var bouleParfum = m_Boules.FirstOrDefault(boule => boule.Parfum.Equals(parfum));
                if (bouleParfum == null) return false;
                if (!bouleParfum.DecrementerQuantite()) return false;
                if (bouleParfum.Quantite >= 1) return true;
                m_Boules.Remove(bouleParfum);
                return true;
                */
                /*
                // LE CODE CI-DESSOUS FONCTIONNE SANS DEVOIR IMPOSER D'UNICITE DE PARFUM DANS LA LISTE DES BOULES >>>
                if (parfum == null) return false;
                //return (m_Boules.RemoveAll(boule => boule.Parfum.Equals(parfum)) != 0); // Si on voulait supprimer d'office toutes les boules d'un parfum, quelque soit leur quantité
                foreach (var boule in m_Boules)
                {
                    if (boule.Parfum.Equals(parfum)) boule.DecrementerQuantite();
                }
                return (m_Boules.RemoveAll(boule => boule.Quantite == 0) != 0); // On ne supprime que les boules dont la quantité a été décrémentée jusque 0
                */
            }

            /// <summary>
            /// Permet de (re)définir le nappage
            /// </summary>
            /// <param name="nappage">Nappage à attribuer à cette confection</param>
            /// <returns>Vrai si la modification de cette information a pu se faire, sinon faux</returns>
            public bool DefinirNappage(INappage nappage)
            {
                if ((nappage != null) && ((TailleSupport == null) || (m_Boules.Count == 0) || !NappageAutorise)) return false;
                Nappage = nappage;
                return true;
            }

            /// <summary>
            /// Permet de (re)définir le fait d'ajouter ou non de la crème fraîche
            /// </summary>
            /// <param name="doitEtreAjoutee">Indique si on doit ajouter de la crème fraîche</param>
            /// <returns>Vrai si la modification de cette information a pu se faire, sinon faux</returns>
            public bool DefinirCremeFraiche(bool doitEtreAjoutee)
            {
                if (doitEtreAjoutee && ((TailleSupport == null) || (m_Boules.Count == 0) || !CremeFraicheAutorisee)) return false;
                CremeFraiche = doitEtreAjoutee;
                return true;
            }

            /// <summary>
            /// Permet de (re)définir le saupoudrage
            /// </summary>
            /// <param name="saupoudrage">Saupoudrage à attribuer à cette confection</param>
            /// <returns>Vrai si la modification de cette information a pu se faire, sinon faux</returns>
            public bool DefinirSaupoudrage(ISaupoudrage saupoudrage)
            {
                if ((saupoudrage != null) && ((TailleSupport == null) || (m_Boules.Count == 0))) return false;
                Saupoudrage = saupoudrage;
                return true;
            }

            /// <summary>
            /// Constructeur
            /// </summary>
            public Confection()
                : base(EntiteBase.NouveauCode, $"Confection le {DateTime.Now.ToString("d/MM/yyyy à H:mm:ss").Replace('-', '/')}")
            {
                TailleSupport = null;
                m_Boules = new List<IBoule>();
                Nappage = null;
                CremeFraiche = false;
                Saupoudrage = null;
            }
        }
    }
}
