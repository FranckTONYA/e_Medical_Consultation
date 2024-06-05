using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDSGBD
{
    /// <summary>
    /// Contient des fonctionnalités d'extensions
    /// </summary>
    public static partial class Extensions
    {
        public static bool DuplicateExists<T>(this T[] array)
        {
            if (array == null) return false;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (array[j].Equals(array[i])) return true;
                }
            }
            return false;
        }

        public static bool DuplicateExists<T>(IEnumerable<T> items)
        {
            if (items == null) return false;
            var list = new List<T>();
            foreach (var item in items)
            {
                if (list.Contains(item)) return true;
                list.Add(item);
            }
            list.Clear();
            return false;
        }

    }
}
