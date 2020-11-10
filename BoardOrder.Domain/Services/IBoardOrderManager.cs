using BoardOrder.Domain.Models;
using System;
using System.Threading.Tasks;

namespace BoardOrder.Domain.Services {
	public interface IBoardOrderManager : IQuoteManager {
		event Action OrderReset;
		bool IsOrderValid { get; }
		BoardOrderDetails CurrentOrder { get; }
		BoardOrderDetails ResetOrder();
		Task<bool> SaveOrder();
	}
}