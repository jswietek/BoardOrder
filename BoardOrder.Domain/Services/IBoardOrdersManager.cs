using BoardOrder.Domain.Models;

namespace BoardOrder.Domain.Services {
	public interface IBoardOrdersManager {
		BoardOrderDetails GetEmptyOrder();
	}
}