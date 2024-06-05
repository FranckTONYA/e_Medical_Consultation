using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PDSGBD;
using PDSGBD.MySql;
using static ConsultationMedicale.Modeles;

namespace ConsultationMedicale
{
    /*
    Exemples de requêtes GET :
	    http://localhost/api_glacier/?action=enumerer&sujet=support
		    OK
		    BP	Baquet en plastique	O	O
		    CO	Cornet	N	O
		    GA	Gaufrette	N	N
		    PB	Panier en biscuit	O	O
	    http://localhost/api_glacier/?action=enumerer&sujet=support&type=CO
		    OK
		    BA	Baby	1
		    NO	Normal	3
		    GR	Grand	4
		    DO	Double	4
		    TR	Triple	7
	    http://localhost/api_glacier/?action=enumerer&sujet=parfum
		    OK
		    CL	Classique
		    AM	Avec morceau
		    AF	Au fruit
		    EX	Exotique
		    SP	Spécial
	    http://localhost/api_glacier/?action=enumerer&sujet=parfum&categorie=AM
		    OK
		    PR	Praliné
		    NO	Nougat
		    EO	Eclats d'orange confite
		    PI	Pistache
	    http://localhost/api_glacier/?action=enumerer&sujet=nappage
		    OK
		    CA	Caramel
		    GM	Grand-marnier
		    CF	Coulis de fraise
		    VO	Vodka
		    RH	Rhum
	    http://localhost/api_glacier/?action=enumerer&sujet=saupoudrage
		    OK
		    BR	Brésilienne
		    PC	Pépittes de chocolat
	    http://localhost/api_glacier/?action=commander&type=CO&taille=GR&boules[]=CL_CN&boules[]=CL_VA&boules[]=AM_PI&boules[]=EX_PA&saupoudrage=BR&creme_fraiche
		    OK
	    http://localhost/api_glacier/?action=commander&type=BP&taille=PE&boules[]=CL_CN&boules[]=CL_VA&boules[]=AF_FM&saupoudrage=BR&nappage=GM
		    OK
	    http://localhost/api_glacier/?action=enumerer&sujet=commande
		    OK
		    2024-03-27 20:27:38	CO	GR	X	V	BR	CL	CN	CL	VA	AM	PI	EX	PA
		    2024-03-27 20:29:45	BP	PE	GM	X	BR	CL	CN	CL	VA	AF	FM
    */

    /// <summary>
    /// Définit l'API de l'application Glacier (côté client)
    /// </summary>
    public class ApiConsultationMedicale
    {
        /// <summary>
        /// Indique si la dernière tentative d'interrogation réalisée a produit une erreur, ou non
        /// </summary>
        public bool ErreurRencontree => !string.IsNullOrEmpty(MessageErreur);

        /// <summary>
        /// Message d'erreur en relation avec la dernière tentative d'interrogation réalisée, sinon null
        /// </summary>
        public string MessageErreur { get; private set; }

        /// <summary>
        /// Connexion "principale" au serveur MySql
        /// </summary>
        private DB m_DB;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="dbSettings">Paramètres de connexion au serveur MySql</param>
        public ApiConsultationMedicale(DB.Settings dbSettings)
        {
            m_DB = new DB(dbSettings);
            MessageErreur = null;
        }

        /// <summary>
        /// Tente de récupérer les types de support
        /// </summary>
        /// <param name="completerAvecTailles">Indique si chaque type de support doit être complété avec sa liste des tailles disponibles</param>
        /// <returns>Énumération des types de support</returns>
        public IEnumerable<Modeles.ITypeSupport> EnumererTypesSupport(bool completerAvecTailles = false)
        {
            ReinitialiserErreur();
            if (completerAvecTailles)
            {
                Modeles.ITypeSupport typeSupport = null;
                foreach (var enreg in m_DB.GetRows(@"
                    SELECT
                        type_support.id AS typ_id,
                        type_support.nom AS typ_nom,
                        nappage_autorise,
                        creme_fraiche_autorisee,
                        taille_support.id AS tai_id,
                        taille_support.nom AS tai_nom,
                        maximum_boules
                    FROM
                        type_support LEFT JOIN taille_support ON type_support.id = taille_support.ref_type
                    ORDER BY
                        type_support.nom ASC,
                        taille_support.nom ASC"))
                {
                    var idType = enreg.GetValue<int>("typ_id");
                    if ((typeSupport == null) || !idType.Equals(typeSupport.Id))
                    {
                        if (typeSupport != null) yield return typeSupport;
                        typeSupport = Modeles.CreerTypeSupport(enreg.GetValue<int>("typ_id"), enreg.GetValue<string>("typ_nom"), enreg.GetValue<bool>("nappage_autorise"), enreg.GetValue<bool>("creme_fraiche_autorisee"));
                        if (!PasNullSinonErreur(typeSupport)) yield break;
                    }
                    typeSupport.AjouterTaille(Modeles.CreerTailleSupport(enreg.GetValue<int>("tai_id"), enreg.GetValue<string>("tai_nom"), enreg.GetValue<byte>("maximum_boules")));
                }
                if (typeSupport != null) yield return typeSupport;
            }
            else
            {
                foreach (var typeSupport in m_DB
                    .GetRows("SELECT id, nom, nappage_autorise, creme_fraiche_autorisee FROM type_support ORDER BY nom ASC")
                    .Select(enreg => Modeles.CreerTypeSupport(enreg.GetValue<int>("id"), enreg.GetValue<string>("nom"), enreg.GetValue<bool>("nappage_autorise"), enreg.GetValue<bool>("creme_fraiche_autorisee")))
                    .TakeWhile(entite => PasNullSinonErreur(entite)))
                {
                    yield return typeSupport;
                }
            }
        }

        /// <summary>
        /// Tente de récupérer les tailles du type de support spécifié
        /// </summary>
        /// <param name="typeSupport">Spécifie le type de support pour lequel récupérer ses tailles</param>
        /// <returns>Énumération des tailles du type de support spécifié</returns>
        public IEnumerable<Modeles.ITailleSupport> EnumererTaillesSupport(Modeles.ITypeSupport typeSupport)
        {
            ReinitialiserErreur();
            if (typeSupport == null)
            {
                MessageErreur = $"Type de support défini lors de la tentative d'énumération de tailles de support !";
                return new Modeles.ITailleSupport[0];
            }
            return m_DB
                .GetRows("SELECT id, nom, maximum_boules FROM taille_support WHERE ref_type = {0} ORDER BY nom ASC", typeSupport.Id)
                .Select(enreg => Modeles.CreerTailleSupport(enreg.GetValue<int>("id"), enreg.GetValue<string>("nom"), enreg.GetValue<byte>("maximum_boules")))
                .TakeWhile(entite => PasNullSinonErreur(entite));
        }

        /// <summary>
        /// Tente de récupérer les catégories de parfum de glace
        /// </summary>
        /// <param name="completerAvecParfums">Indique si chaque catégorie de parfum de glace doit être complétée avec sa liste des parfums de glace disponibles</param>
        /// <returns>Énumération des catégories de parfum de glace</returns>
        public IEnumerable<Modeles.ICategorieParfum> EnumererCategoriesParfum(bool completerAvecParfums = false)
        {
            ReinitialiserErreur();
            if (completerAvecParfums)
            {
                Modeles.ICategorieParfum categorie = null;
                foreach (var enreg in m_DB.GetRows(@"
                    SELECT
                        categorie_parfum.id AS cat_id,
                        categorie_parfum.nom AS cat_nom,
                        parfum.id AS par_id,
                        parfum.nom AS par_nom
                    FROM
                        categorie_parfum LEFT JOIN parfum ON categorie_parfum.id = parfum.ref_categorie
                    ORDER BY
                        categorie_parfum.nom ASC,
                        parfum.nom ASC"))
                {
                    var idCategorie = enreg.GetValue<int>("cat_id");
                    if ((categorie == null) || !idCategorie.Equals(categorie.Id))
                    {
                        if (categorie != null) yield return categorie;
                        categorie = Modeles.CreerCategorieParfum(idCategorie, enreg.GetValue<string>("cat_nom"));
                        if (!PasNullSinonErreur(categorie)) yield break;
                    }
                    categorie.AjouterParfum(Modeles.CreerParfum(enreg.GetValue<int>("par_id"), enreg.GetValue<string>("par_nom")));
                }
                if (categorie != null) yield return categorie;
            }
            else
            {
                foreach (var categorie in m_DB
                    .GetRows("SELECT id, nom FROM categorie_parfum ORDER BY nom ASC")
                    .Select(enreg => Modeles.CreerCategorieParfum(enreg.GetValue<int>("id"), enreg.GetValue<string>("nom")))
                    .TakeWhile(entite => PasNullSinonErreur(entite)))
                {
                    yield return categorie;
                }
            }
        }

        /// <summary>
        /// Tente de récupérer les parfums de glace de la catégorie spécifiée
        /// </summary>
        /// <param name="completerAvecTailles">Indique si chaque catégorie de parfum de glace doit être complété avec sa liste des parfums de glace disponibles</param>
        /// <returns>Énumération des parfums de glace de la catégorie spécifiée</returns>
        public IEnumerable<Modeles.IParfum> EnumererParfums(Modeles.ICategorieParfum categorieParfum)
        {
            ReinitialiserErreur();
            if (categorieParfum == null)
            {
                MessageErreur = $"Catégories de parfum de glace défini lors de la tentative d'énumération de parfums de glace de support !";
                return new Modeles.IParfum[0];
            }
            return m_DB
                .GetRows("SELECT id, nom FROM parfum WHERE ref_categorie = {0} ORDER BY nom ASC", categorieParfum.Id)
                .Select(enreg => Modeles.CreerParfum(enreg.GetValue<int>("id"), enreg.GetValue<string>("nom")))
                .TakeWhile(entite => PasNullSinonErreur(entite));
        }

        /// <summary>
        /// Tente de récupérer les nappages
        /// </summary>
        /// <returns>Énumération des nappages</returns>
        public IEnumerable<Modeles.INappage> EnumererNappages()
        {
            ReinitialiserErreur();
            return m_DB
                .GetRows("SELECT id, nom FROM nappage ORDER BY nom ASC")
                .Select(enreg => Modeles.CreerNappage(enreg.GetValue<int>("id"), enreg.GetValue<string>("nom")))
                .TakeWhile(entite => PasNullSinonErreur(entite));
        }

        /// <summary>
        /// Tente de récupérer les saupoudrages
        /// </summary>
        /// <returns>Énumération des saupoudrages</returns>
        public IEnumerable<Modeles.ISaupoudrage> EnumererSaupoudrages()
        {
            ReinitialiserErreur();
            return m_DB
                .GetRows("SELECT id, nom FROM saupoudrage ORDER BY nom ASC")
                .Select(enreg => Modeles.CreerSaupoudrage(enreg.GetValue<int>("id"), enreg.GetValue<string>("nom")))
                .TakeWhile(entite => PasNullSinonErreur(entite));
        }

        /// <summary>
        /// Tente de passer commande d'une confection
        /// </summary>
        /// <returns>Énumération des saupoudrages</returns>
        public bool CommanderConfection(Modeles.IConfection confection)
        {
            /*
            var clesValeurs = new List<string>();
            {
                clesValeurs.Add("action");
                clesValeurs.Add("commander");
            }
            {
                clesValeurs.Add("type");
                clesValeurs.Add(confection.TypeSupport.Code);
                clesValeurs.Add("taille");
                clesValeurs.Add(confection.TailleSupport.Code);
            }
            foreach (var boule in confection.Boules)
            {
                for (int i = 0; i < boule.Quantite; i++)
                {
                    clesValeurs.Add("boules[]");
                    clesValeurs.Add(boule.Parfum.Code);
                }
            }
            if (confection.Nappage != null)
            {
                clesValeurs.Add("nappage");
                clesValeurs.Add(confection.Nappage.Code);
            }
            if (confection.CremeFraiche)
            {
                clesValeurs.Add("creme_fraiche");
                clesValeurs.Add("");
            }
            if (confection.Saupoudrage != null)
            {
                clesValeurs.Add("saupoudrage");
                clesValeurs.Add(confection.Saupoudrage.Code);
            }
            QueryAndGetData(clesValeurs.ToArray()).FirstOrDefault();
            return !ErreurRencontree;
            */
            return false;
        }

        private void ReinitialiserErreur()
        {
            MessageErreur = null;
        }

        private bool PasNullSinonErreur<T>(T entite, string messageErreur = "Création de l'entité impossible !")
            where T : class
        {
            if (entite != null) return true;
            MessageErreur = messageErreur;
            return false;
        }
    }
}
