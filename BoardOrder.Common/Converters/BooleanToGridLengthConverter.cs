using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace BoardOrder.Common.Converters {
	public class BooleanToGridLengthConverter : IValueConverter {
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
			{
				if (value is bool boolValue && boolValue) {
					return new GridLength(1, GridUnitType.Star);
				}

				return GridLength.Auto;
			}
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
			//not used
			return null;
		}
	}
}
