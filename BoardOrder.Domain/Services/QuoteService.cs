using BoardOrder.Domain.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace BoardOrder.Domain.Services {
	public class QuoteService : IQuoteService {
		public IEnumerable<BoardOrderItem> ExtractQuote(BoardOrderDetails orderDetails) {
			var props = orderDetails.GetType().GetProperties();
			var values = props.Where(prop => prop.PropertyType.IsAssignableFrom(typeof(BoardOrderItem)))
				.Select(p => p.GetValue(orderDetails)).Cast<BoardOrderItem>();

			return new ObservableCollection<BoardOrderItem>(values);
		}
	}
}
