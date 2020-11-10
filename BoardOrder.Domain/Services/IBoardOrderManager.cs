using BoardOrder.Domain.Models;
using System.Threading.Tasks;

namespace BoardOrder.Domain.Services {
	public interface IBoardOrderManager : IQuoteManager {
		bool IsOrderValid { get; }
		BoardOrderDetails ResetOrder();
		Task<bool> SaveOrder();
	}
}