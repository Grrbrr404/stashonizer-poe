using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stashonizer.Presentation.Converter
{
    using System.Globalization;
    using System.Windows.Data;

    /// <summary>
    /// Converts 0 to infinite symbol
    /// </summary>
    public class ZeroIntToSymbolConverter : IValueConverter
    {
        #region Implementation of IValueConverter

        /// <summary>
        /// Konvertiert einen Wert. 
        /// </summary>
        /// <returns>
        /// Ein konvertierter Wert.Wenn die Methode null zurückgibt, wird der gültige NULL-Wert verwendet.
        /// </returns>
        /// <param name="value">Der von der Bindungsquelle erzeugte Wert.</param><param name="targetType">Der Typ der Bindungsziel-Eigenschaft.</param><param name="parameter">Der zu verwendende Konverterparameter.</param><param name="culture">Die im Konverter zu verwendende Kultur.</param>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value.ToString() == "0" ? "\u221E" : value;
        }

        /// <summary>
        /// Konvertiert einen Wert. 
        /// </summary>
        /// <returns>
        /// Ein konvertierter Wert.Wenn die Methode null zurückgibt, wird der gültige NULL-Wert verwendet.
        /// </returns>
        /// <param name="value">Der Wert, der vom Bindungsziel erzeugt wird.</param><param name="targetType">Der Typ, in den konvertiert werden soll.</param><param name="parameter">Der zu verwendende Konverterparameter.</param><param name="culture">Die im Konverter zu verwendende Kultur.</param>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value.ToString() == "\u221E" ? 0 : value;
        }

        #endregion
    }
}
