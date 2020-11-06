using BoardOrder.Domain.Models;
using System.Collections;
using System.Collections.Generic;

namespace BoardOrder.Common.Messages {
	public class OrderDetailsSaved {
		public OrderDetailsSaved(IEnumerable<BoardOrderItem> orderQuote) {
			this.OrderQuote = orderQuote;
		}

		public IEnumerable<BoardOrderItem> OrderQuote { get; }
	}
}
