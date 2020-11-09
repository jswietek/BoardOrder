using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace BoardOrder.Common.Converters {
	public class PercentageToVisibilityConverter : IValueConverter {
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
			if(value is double percentage && int.TryParse(parameter.ToString(), out var treshold)) {
				return percentage >= treshold ? Visibility.Visible : Visibility.Collapsed;
			}

			return Visibility.Collapsed;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
			//not used
			return null;
		}
	}
}
