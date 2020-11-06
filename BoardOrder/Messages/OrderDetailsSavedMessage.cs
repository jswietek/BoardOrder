using BoardOrder.Domain.Models;

namespace BoardOrder.Common.Messages {
	public class OrderDetailsSaved {
		public OrderDetailsSaved(BoardOrderDetails orderDetails) {
			this.OrderDetails = orderDetails;
		}

		public BoardOrderDetails OrderDetails { get; }
	}
}
