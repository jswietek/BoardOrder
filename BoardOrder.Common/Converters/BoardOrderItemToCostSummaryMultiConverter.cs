using BoardOrder.Domain.Models;
using System;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

namespace BoardOrder.Common.Converters {
	public class BoardOrderItemToCostSummaryMultiConverter : IMultiValueConverter {
		public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture) {
			if (values.Count() == 2 && values[0] is BoardOrderItem orderItem && values[1] is int quantity) {
				var cost = orderItem.CostModifier * quantity;
				return cost > 0 ? cost + " $" : string.Empty;
			}

			return string.Empty;
		}

		public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture) {
			//not used
			return null;
		}
	}
}
