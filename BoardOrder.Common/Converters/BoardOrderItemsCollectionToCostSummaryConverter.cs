using BoardOrder.Domain.Models;
using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

namespace BoardOrder.Common.Converters {
	public class BoardOrderItemsCollectionToCostSummaryConverter : IValueConverter {
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
			double costSum = 0;
			if (value is CollectionViewGroup collectionViewGroup && collectionViewGroup.ItemCount > 0) {
				costSum = (collectionViewGroup.Items.Where(item => item is BoardOrderItem).Sum(item => (item as BoardOrderItem).CostModifier));
			}
			else if (value is ObservableCollection<BoardOrderItem> collection && collection.Count > 0) {
				costSum = (collection.Sum(item => item.CostModifier));
			}

			return costSum > 0 ? costSum.ToString() + " $" : "-";
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
			//not used
			return null;
		}
	}
}
