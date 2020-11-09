using BoardOrder.Domain.Models;
using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

namespace BoardOrder.Common.Converters {
	public class BoardOrderItemsCollectionToCostSummaryConverter : IMultiValueConverter {
		public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture) {
			double costSum = 0;
			if (values.Length == 2 && values[1] is int boardsQuantity) {
				if (values[0] is CollectionViewGroup collectionViewGroup && collectionViewGroup.ItemCount > 0) {
					costSum = (collectionViewGroup.Items.Where(item => item is BoardOrderItem).Sum(item => (item as BoardOrderItem).CostModifier * boardsQuantity));
				}
				else if (values[0] is ObservableCollection<BoardOrderItem> collection && collection.Count > 0) {
					costSum = (collection.Sum(item => item.CostModifier * boardsQuantity));
				}
			}
			return costSum > 0 ? costSum.ToString() + " $" : "-";
		}

		public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture) {
			//not used
			return null;
		}
	}
}
