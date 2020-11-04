using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace BoardOrder.Common.Converters {
	public class BooleanNegationToVisibilityCollapsedConverter : IValueConverter {
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
			if (value is bool boolValue) {
				return boolValue ? Visibility.Collapsed : Visibility.Visible;
			}
			else {
				return Visibility.Visible;
			}
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
			if (value is Visibility visibility) {
				return visibility == Visibility.Visible ? false : true;
			}
			else {
				return false;
			}
		}
	}
}
