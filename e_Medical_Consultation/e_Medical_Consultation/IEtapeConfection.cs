using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glacier
{
    /// <summary>
    /// Identifie de toute étape de la confection d'une crème glacée
    /// </summary>
    public enum EtapeConfection
    {
        /// <summary>
        /// Sélection du support (type et taille)
        /// </summary>
        SelectionSupport,
        /// <summary>
        /// Sélection des boules (quantités et parfums/catégories)
        /// </summary>
        SelectionBoules,
        /// <summary>
        /// Sélection de l'éventuel nappage si autorisé
        /// </summary>
        SelectionNappage,
        /// <summary>
        /// Sélection de l'éventuel saupoudrage, et de l'éventuel crème fraîche si autorisée
        /// </summary>
        SelectionSaupoudrage,
        /// <summary>
        /// Finalisation de la "commande" relative à cette confection de crème glacée
        /// </summary>
        Finalisation
    }

    /// <summary>
    /// Définit ce qui est commun à tout contrôle implémentant une étape de la confection d'une crème glacée
    /// </summary>
    public interface IEtapeConfection
    {
        /// <summary>
        /// Identifiant de cette étape de confection
        /// </summary>
        EtapeConfection Identifiant { get; }

        /// <summary>
        /// Indique le titre d'étape de confection correspondant à ce contrôle
        /// </summary>
        string Titre { get; }

        /// <summary>
        /// Indique si la sélection est actuellement valide
        /// </summary>
        bool SelectionValide { get; }

        /// <summary>
        /// Événement déclenché à chaque fois que l'état de validité de la sélection vient de changer
        /// </summary>
        event EventHandler ValiditeSelectionAChange;

        /// <summary>
        /// Indique le texte du bouton d'étape précedente, sinon null
        /// </summary>
        string TexteBoutonPrecedent { get; }

        /// <summary>
        /// Indique le texte du bouton d'étape suivante, sinon null
        /// </summary>
        string TexteBoutonSuivant { get; }

        /// <summary>
        /// Permet d'instancier la vue de l'étape précédant celle-ci
        /// </summary>
        /// <param name="api">Référence de l'API donnant accès au "support" des données actives de l'application</param>
        /// <param name="confection">Référence de l'entité représentant ce qui est en cours de confection</param>
        /// <returns>Nouveau contrôle utilisateur implémentant l'interface IEtapeConfection si possible, sinon null</returns>
        IEtapeConfection CreerEtapePrecedente(ApiConsultationMedicale api, Modeles.IConfection confection);

        /// <summary>
        /// Permet d'instancier la vue de l'étape suivant celle-ci
        /// </summary>
        /// <param name="api">Référence de l'API donnant accès au "support" des données actives de l'application</param>
        /// <param name="confection">Référence de l'entité représentant ce qui est en cours de confection</param>
        /// <returns>Nouveau contrôle utilisateur implémentant l'interface IEtapeConfection si possible, sinon null</returns>
        IEtapeConfection CreerEtapeSuivante(ApiConsultationMedicale api, Modeles.IConfection confection);

        /// <summary>
        /// Référence de l'entité représentant ce qui est en cours de confection
        /// </summary>
        Modeles.IConfection Confection { get; }
    }
}
