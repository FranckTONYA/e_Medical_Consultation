using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDSGBD
{
    /// <summary>
    /// Définit une collection uniquement consultable d'éléments du type spécifié
    /// </summary>
    /// <typeparam name="T">Type des éléments de cette collection</typeparam>
    public interface IReadableCollection<T> : IEnumerable<T>
    {
        /// <summary>
        /// Nombre d'éléments de cette collection
        /// </summary>
        int Count { get; }

        /// <summary>
        /// Accès à un élément de cette collection en fonction de son indice
        /// </summary>
        /// <param name="index">Indice de l'élément à récupérer</param>
        /// <returns>Élément à l'indice spécifié si possible, sinon valeur par défaut pour ce type d'élément</returns>
        T this[int index] { get; }
    }

    /// <summary>
    /// Implémente une collection uniquement consultable d'éléments du type spécifié
    /// </summary>
    /// <typeparam name="T">Type des éléments de cette collection</typeparam>
    public class ReadableCollection<T> : IReadableCollection<T>
    {
        /// <summary>
        /// Liste stockant les éléments de cette collection
        /// </summary>
        private List<T> m_Items;

        /// <summary>
        /// Nombre d'éléments de cette collection
        /// </summary>
        public int Count => m_Items.Count;

        /// <summary>
        /// Accès à un élément de cette collection en fonction de son indice
        /// </summary>
        /// <param name="index">Indice de l'élément à récupérer</param>
        /// <returns>Élément à l'indice spécifié si possible, sinon valeur par défaut pour ce type d'élément</returns>
        public T this[int index] => ((index >= 0) && (index < m_Items.Count)) ? m_Items[index] : default(T);

        #region Implémentation de l'interface IEnumerable<T> à partir du conteneur m_Items (de type List<T>)
        public IEnumerator<T> GetEnumerator() => m_Items.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => m_Items.GetEnumerator();
        #endregion

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public ReadableCollection()
        {
            m_Items = new List<T>();
        }

        /// <summary>
        /// Constructeur spécifique
        /// </summary>
        /// <param name="items">Ensemble d'éléments à ajouter à cette collection</param>
        public ReadableCollection(IEnumerable<T> items)
        {
            m_Items = new List<T>();
            AddRange(items);
        }

        /// <summary>
        /// Constructeur spécifique
        /// </summary>
        /// <param name="firstItem">Premier élément à ajouter à cette collection</param>
        /// <param name="otherItems">Éventuel ensemble d'autres éléments à ajouter à cette collection</param>
        public ReadableCollection(T firstItem, params T[] otherItems)
        {
            m_Items = new List<T>();
            Add(firstItem);
            AddRange(otherItems);
        }

        /// <summary>
        /// Ajoute un élément à cette collection
        /// </summary>
        /// <param name="item">Élément à ajouter</param>
        public void Add(T item)
        {
            m_Items.Add(item);
        }

        /// <summary>
        /// Ajoute un ensemble d'éléments à cette collection
        /// </summary>
        /// <param name="items">Ensemble d'éléments à ajouter à cette collection</param>
        public void AddRange(IEnumerable<T> items)
        {
            if (items != null) m_Items.AddRange(items);
        }
    }
}
