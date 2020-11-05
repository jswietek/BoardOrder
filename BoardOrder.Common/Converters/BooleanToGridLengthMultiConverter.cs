using System;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;

namespace BoardOrder.Common.Converters {
	public class BooleanToGridLengthMultiConverter : IMultiValueConverter {
		public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture) {
			if (values.Any(v => v is bool boolValue && boolValue)) {
				return GridLength.Auto;
			}

			return new GridLength(1, GridUnitType.Star);
		}

		public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture) {
			//not used
			return null;
		}
	}
}
