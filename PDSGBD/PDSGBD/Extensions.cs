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
        #region Constantes
        /// <summary>
        /// Définit le style de représentation des nombres réels
        /// </summary>
        private const System.Globalization.NumberStyles FloatStyle = System.Globalization.NumberStyles.AllowLeadingSign | System.Globalization.NumberStyles.AllowDecimalPoint;

        /// <summary>
        /// Définit la culture anglophone
        /// </summary>
        private static System.Globalization.CultureInfo EnglishCulture = System.Globalization.CultureInfo.GetCultureInfo("en-US");
        #endregion

        #region Conversion des valeurs réelles
        /// <summary>
        /// Tente de convertir ce texte en une valeur réelle (type double)
        /// </summary>
        /// <param name="text">Texte à convertir</param>
        /// <param name="value">Valeur convertie si possible, sinon la valeur par défaut spécifiée</param>
        /// <param name="defaultValue">Valeur par défaut à retourner en cas d'échec de conversion</param>
        /// <returns>Vrai si la conversion a pu être réalisée, sinon faux</returns>
        public static bool TryParse(this string text, out double value, double defaultValue = double.NaN)
        {
            if ((text != null) && double.TryParse(text.Trim().Replace(',', '.'), FloatStyle, EnglishCulture, out value)) return true;
            value = defaultValue;
            return false;
        }

        /// <summary>
        /// Tente de convertir ce texte en une valeur réelle (type float)
        /// </summary>
        /// <param name="text">Texte à convertir</param>
        /// <param name="value">Valeur convertie si possible, sinon la valeur par défaut spécifiée</param>
        /// <param name="defaultValue">Valeur par défaut à retourner en cas d'échec de conversion</param>
        /// <returns>Vrai si la conversion a pu être réalisée, sinon faux</returns>
        public static bool TryParse(this string text, out float value, float defaultValue = float.NaN)
        {
            if ((text != null) && float.TryParse(text.Trim().Replace(',', '.'), FloatStyle, EnglishCulture, out value)) return true;
            value = defaultValue;
            return false;
        }

        /// <summary>
        /// Tente de convertir ce texte en une valeur réelle (type decimal)
        /// </summary>
        /// <param name="text">Texte à convertir</param>
        /// <param name="value">Valeur convertie si possible, sinon la valeur par défaut spécifiée</param>
        /// <param name="defaultValue">Valeur par défaut à retourner en cas d'échec de conversion</param>
        /// <returns>Vrai si la conversion a pu être réalisée, sinon faux</returns>
        public static bool TryParse(this string text, out decimal value, decimal defaultValue = decimal.Zero)
        {
            if ((text != null) && decimal.TryParse(text.Trim().Replace(',', '.'), FloatStyle, EnglishCulture, out value)) return true;
            value = defaultValue;
            return false;
        }
        #endregion

        #region Conversion des valeurs entières
        /// <summary>
        /// Tente de convertir ce texte en une valeur entière (type sbyte)
        /// </summary>
        /// <param name="text">Texte à convertir</param>
        /// <param name="value">Valeur convertie si possible, sinon la valeur par défaut spécifiée</param>
        /// <param name="defaultValue">Valeur par défaut à retourner en cas d'échec de conversion</param>
        /// <returns>Vrai si la conversion a pu être réalisée, sinon faux</returns>
        public static bool TryParse(this string text, out sbyte value, sbyte defaultValue = 0)
        {
            if ((text != null) && sbyte.TryParse(text.Trim(), out value)) return true;
            value = defaultValue;
            return false;
        }

        /// <summary>
        /// Tente de convertir ce texte en une valeur entière (type byte)
        /// </summary>
        /// <param name="text">Texte à convertir</param>
        /// <param name="value">Valeur convertie si possible, sinon la valeur par défaut spécifiée</param>
        /// <param name="defaultValue">Valeur par défaut à retourner en cas d'échec de conversion</param>
        /// <returns>Vrai si la conversion a pu être réalisée, sinon faux</returns>
        public static bool TryParse(this string text, out byte value, byte defaultValue = 0)
        {
            if ((text != null) && byte.TryParse(text.Trim(), out value)) return true;
            value = defaultValue;
            return false;
        }

        /// <summary>
        /// Tente de convertir ce texte en une valeur entière (type short)
        /// </summary>
        /// <param name="text">Texte à convertir</param>
        /// <param name="value">Valeur convertie si possible, sinon la valeur par défaut spécifiée</param>
        /// <param name="defaultValue">Valeur par défaut à retourner en cas d'échec de conversion</param>
        /// <returns>Vrai si la conversion a pu être réalisée, sinon faux</returns>
        public static bool TryParse(this string text, out short value, short defaultValue = 0)
        {
            if ((text != null) && short.TryParse(text.Trim(), out value)) return true;
            value = defaultValue;
            return false;
        }

        /// <summary>
        /// Tente de convertir ce texte en une valeur entière (type ushort)
        /// </summary>
        /// <param name="text">Texte à convertir</param>
        /// <param name="value">Valeur convertie si possible, sinon la valeur par défaut spécifiée</param>
        /// <param name="defaultValue">Valeur par défaut à retourner en cas d'échec de conversion</param>
        /// <returns>Vrai si la conversion a pu être réalisée, sinon faux</returns>
        public static bool TryParse(this string text, out ushort value, ushort defaultValue = 0)
        {
            if ((text != null) && ushort.TryParse(text.Trim(), out value)) return true;
            value = defaultValue;
            return false;
        }

        /// <summary>
        /// Tente de convertir ce texte en une valeur entière (type int)
        /// </summary>
        /// <param name="text">Texte à convertir</param>
        /// <param name="value">Valeur convertie si possible, sinon la valeur par défaut spécifiée</param>
        /// <param name="defaultValue">Valeur par défaut à retourner en cas d'échec de conversion</param>
        /// <returns>Vrai si la conversion a pu être réalisée, sinon faux</returns>
        public static bool TryParse(this string text, out int value, int defaultValue = 0)
        {
            if ((text != null) && int.TryParse(text.Trim(), out value)) return true;
            value = defaultValue;
            return false;
        }

        /// <summary>
        /// Tente de convertir ce texte en une valeur entière (type uint)
        /// </summary>
        /// <param name="text">Texte à convertir</param>
        /// <param name="value">Valeur convertie si possible, sinon la valeur par défaut spécifiée</param>
        /// <param name="defaultValue">Valeur par défaut à retourner en cas d'échec de conversion</param>
        /// <returns>Vrai si la conversion a pu être réalisée, sinon faux</returns>
        public static bool TryParse(this string text, out uint value, uint defaultValue = 0)
        {
            if ((text != null) && uint.TryParse(text.Trim(), out value)) return true;
            value = defaultValue;
            return false;
        }

        /// <summary>
        /// Tente de convertir ce texte en une valeur entière (type long)
        /// </summary>
        /// <param name="text">Texte à convertir</param>
        /// <param name="value">Valeur convertie si possible, sinon la valeur par défaut spécifiée</param>
        /// <param name="defaultValue">Valeur par défaut à retourner en cas d'échec de conversion</param>
        /// <returns>Vrai si la conversion a pu être réalisée, sinon faux</returns>
        public static bool TryParse(this string text, out long value, long defaultValue = 0)
        {
            if ((text != null) && long.TryParse(text.Trim(), out value)) return true;
            value = defaultValue;
            return false;
        }

        /// <summary>
        /// Tente de convertir ce texte en une valeur entière (type ulong)
        /// </summary>
        /// <param name="text">Texte à convertir</param>
        /// <param name="value">Valeur convertie si possible, sinon la valeur par défaut spécifiée</param>
        /// <param name="defaultValue">Valeur par défaut à retourner en cas d'échec de conversion</param>
        /// <returns>Vrai si la conversion a pu être réalisée, sinon faux</returns>
        public static bool TryParse(this string text, out ulong value, ulong defaultValue = 0)
        {
            if ((text != null) && ulong.TryParse(text.Trim(), out value)) return true;
            value = defaultValue;
            return false;
        }
        #endregion
    }
}
