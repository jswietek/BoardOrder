using BoardOrder.Domain.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;

namespace BoardOrder.Common.Converters {
	public class QuoteToPercentageGridLengthMultiConverter : IMultiValueConverter {
		public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture) {
			if (values.Length == 3 && values[0] is IEnumerable<BoardOrderItem> items && values[1] is double totalCost && values[2] is int boardQuantity && parameter is CostType costType) {
				var percentage = this.CalculatePercentageCost(items.Where(item => item.CostType == costType), totalCost, boardQuantity);
				return new GridLength(percentage, GridUnitType.Star);
			}

			return null;
		}

		public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture) {
			//not used
			return null;
		}

		private int CalculatePercentageCost(IEnumerable<BoardOrderItem> items, double total, int quantity) {
			var sum = items.Sum(item => item.CostModifier) * quantity;
			return (int)(sum / total * 100);
		}
	}
}
