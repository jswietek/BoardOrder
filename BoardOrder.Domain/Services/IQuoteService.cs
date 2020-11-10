using BoardOrder.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BoardOrder.Domain.Services {
	public interface IQuoteService {
		Task<IEnumerable<BoardOrderItem>> ExtractQuote(BoardOrderDetails orderDetails);
		Task<IEnumerable<BoardOrderItem>> LoadBaseCosts();
		int CalculatePercentage(double sum, double total);
		double CalculateSumCost(IEnumerable<BoardOrderItem> items, int boardsQuantity);
		double CalculateSumTime(IEnumerable<BoardOrderItem> items, int boardsQuantity);
	}
}