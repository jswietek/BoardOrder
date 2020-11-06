using BoardOrder.Domain.Models;
using System.Collections.Generic;
using System.ComponentModel;

namespace BoardOrder.Domain.Services {
	public interface IBoardOrderManager {
		bool IsOrderValid { get; }
		event PropertyChangedEventHandler OrderModified;

		BoardOrderDetails ResetOrder();
		IEnumerable<BoardOrderItem> SaveOrder();
	}
}