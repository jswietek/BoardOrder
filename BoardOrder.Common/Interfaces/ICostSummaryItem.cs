using BoardOrder.Domain.Models;

namespace BoardOrder.Common.Interfaces {
	public interface ICostSummaryItem {
		BoardOrderItem Item { get; }
		double PercentageTime { get; }
		double PercentageCost { get; }
		double CumulatedCost { get; }
		int CumulatedTime { get; }
	}
}
