using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace BoardOrder.Common.Converters {
	public class PercantageToGridLengthConverter : IValueConverter {
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
			if (value is double percentage) {
				return new GridLength(percentage, GridUnitType.Star);
			}
			return new GridLength();
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
			//not used
			return null;
		}
	}
}
