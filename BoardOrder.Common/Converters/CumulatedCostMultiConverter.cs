using System;
using System.Globalization;
using System.Windows.Data;

namespace BoardOrder.Common.Converters {
	public class CumulatedCostMultiConverter : IMultiValueConverter {
		public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture) {
			if (values.Length == 2 && values[0] is double cost && values[1] is int quantity) {
				return (cost * quantity).ToString();
			}
			return 0;
		}

		public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture) {
			throw new NotImplementedException();
		}
	}
}
