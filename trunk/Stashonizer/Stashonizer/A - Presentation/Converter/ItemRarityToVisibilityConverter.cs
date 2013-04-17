using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Stashonizer.Presentation.Converter {
  public class ItemRarityToVisibilityConverter : IValueConverter {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
      var rarity = (ItemRarity)value;
      if (parameter.ToString() == "single") {
        
        switch (rarity) {
          case ItemRarity.Rare:
            return Visibility.Collapsed;
            break;
          case ItemRarity.Unique:
            return Visibility.Collapsed;
            break;
          default:
            return Visibility.Visible;
        }
      }
      
      if (parameter.ToString() == "double") {
        switch (rarity) {
          case ItemRarity.Normal:
            return Visibility.Collapsed;
            break;
          case ItemRarity.Blue:
            return Visibility.Collapsed;
            break;
          case ItemRarity.Gem:
            return Visibility.Collapsed;
            break;
          case ItemRarity.Currency:
            return Visibility.Collapsed;
            break;
          case ItemRarity.Quest:
            return Visibility.Collapsed;
            break;
          default:
            return Visibility.Visible;
        }
      }

      throw new ArgumentOutOfRangeException("Undefined behavior");

    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
      throw new NotImplementedException();
    }
  }
}
