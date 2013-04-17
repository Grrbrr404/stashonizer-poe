using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Data;

namespace Stashonizer.Presentation.Converter {
    class ListToVisibilityConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
            try {
                if (value == null) {
                    return Visibility.Collapsed;
                }

                if (value is IEnumerable<object>) {
                    var list = value as IEnumerable<object>;

                    if (list.Count() > 0) {
                        return Visibility.Visible;
                    }
                    else {
                        return Visibility.Collapsed;
                    }
                }
                else if (value is string) {
                    if (string.IsNullOrEmpty(value.ToString())) {
                        return Visibility.Collapsed;
                    }
                    else {
                        return Visibility.Visible;
                    }
                }

                return Visibility.Visible;
            } catch {
                throw new ArgumentException("Invalid argument");
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
            throw new NotImplementedException();
        }
    }
}
