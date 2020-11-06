using BoardOrder.Domain.Models;
using System.Collections.Generic;

namespace BoardOrder.Domain.Services {
	public interface IQuoteService {
		IEnumerable<BoardOrderItem> ExtractQuote(BoardOrderDetails orderDetails);
	}
}