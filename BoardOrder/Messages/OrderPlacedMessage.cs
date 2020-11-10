using BoardOrder.Domain.Models;
using GalaSoft.MvvmLight.Messaging;

namespace BoardOrder.Messages {
	public class OrderPlacedMessage : MessageBase {
		public OrderPlacedMessage(PlacedOrderItem item) {
			this.PlacedOrderItem = item;
		}

		public PlacedOrderItem PlacedOrderItem { get; }
	}
}
