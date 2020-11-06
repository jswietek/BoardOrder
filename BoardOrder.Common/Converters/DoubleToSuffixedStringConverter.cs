using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Data;

namespace BoardOrder.Common.Converters {
	public class DoubleToSuffixedStringConverter : IValueConverter {
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
			if (value is double doubleValue && parameter is string suffix) {
				return $"{doubleValue} {suffix}";
			}

			return value;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
			return Double.Parse(Regex.Match(value.ToString(), @"[\d.]+").Value);
		}
	}
}
