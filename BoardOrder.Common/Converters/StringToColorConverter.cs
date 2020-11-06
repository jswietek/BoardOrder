using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace BoardOrder.Common.Converters {
	public class StringToColorConverter : IValueConverter {
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
			if (value is string colorString && !string.IsNullOrEmpty(colorString)) {
				try {
					var color = (Color)ColorConverter.ConvertFromString(colorString);
					return color;
				}
				catch { }
			}
			return Colors.Red;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
			//not used
			return null;
		}
	}
}
