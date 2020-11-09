using BoardOrder.Domain.Models;
using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

namespace BoardOrder.Common.Converters {
	public class BoardOrderItemsCollectionToTimeSummaryConverter : IMultiValueConverter {
		public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture) {
			double days = 0;
			if (values.Length == 2 && values[1] is int boardsQuantity) {
				if (values[0] is CollectionViewGroup collectionViewGroup && collectionViewGroup.ItemCount > 0) {
					days = Math.Round(collectionViewGroup.Items.Where(item => item is BoardOrderItem).Sum(item => (item as BoardOrderItem).WorkdaysModifier * boardsQuantity));
				}
				else if (values[0] is ObservableCollection<BoardOrderItem> collection && collection.Count > 0) {
					days = Math.Round(collection.Sum(item => item.WorkdaysModifier * boardsQuantity));
				}
			}
			var suffix = days > 1 ? " days" : " day";
			return days > 0 ? days.ToString() + suffix : "-";
		}

		public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture) {
			//not used
			return null;
		}
	}
}
