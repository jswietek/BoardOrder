namespace BoardOrder.Domain.Models {
	public class PlacedOrderItem {
		public string ProjectName { get; set; }
		public double TotalCost { get; set; }
		public double TotalTime { get; set; }
		public string CurrentStatus { get; set; }
	}
}
