using BoardOrder.Domain.Models;
using System;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

namespace BoardOrder.Common.Converters {
	public class BoardOrderItemToTimeSummaryMultiConverter : IMultiValueConverter {
		public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture) {
			if (values.Count() == 2 && values[0] is BoardOrderItem orderItem && values[1] is int quantity) {
				var time = Math.Round(orderItem.WorkdaysModifier * quantity);
				return time > 0 ? time > 1  ? time + " days" :  time + " day" : string.Empty;
			}

			return string.Empty;
		}

		public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture) {
			//not used
			return null;
		}
	}
}
