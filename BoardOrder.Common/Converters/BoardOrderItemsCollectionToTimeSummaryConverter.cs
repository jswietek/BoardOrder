using BoardOrder.Domain.Models;
using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

namespace BoardOrder.Common.Converters {
	public class BoardOrderItemsCollectionToTimeSummaryConverter : IValueConverter {
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
			double days = 0;
			if (value is CollectionViewGroup collectionViewGroup && collectionViewGroup.ItemCount > 0) {
				days = (collectionViewGroup.Items.Where(item => item is BoardOrderItem).Sum(item => (item as BoardOrderItem).WorkdaysModifier));
			}
			else if (value is ObservableCollection<BoardOrderItem> collection && collection.Count > 0) {
				days = (collection.Sum(item => item.WorkdaysModifier));
			}

			var suffix = days > 1 ? " days" : " day";
			return days > 0 ? days.ToString() + suffix : "-";
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
			//not used
			return null;
		}
	}
}
