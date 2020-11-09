using BoardOrder.Domain.Models;
using System.ComponentModel;
using System.Threading.Tasks;

namespace BoardOrder.Domain.Services {
	public interface IBoardOrderManager {
		bool IsOrderValid { get; }
		event PropertyChangedEventHandler OrderModified;
		BoardOrderDetails ResetOrder();
		Task<bool> SaveOrder();
	}
}