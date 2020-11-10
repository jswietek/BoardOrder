using BoardOrder.Domain.Models;
using System;
using System.Threading.Tasks;

namespace BoardOrder.Domain.Services {
	public interface IBoardOrderManager : IQuoteManager {
		event Action OrderReset;
		bool IsOrderValid { get; }
		BoardOrderDetails CurrentOrder { get; }
		void ResetOrder();
		Task<bool> SaveOrder();
		Task<PlacedOrderItem> PlaceOrder();
	}
}