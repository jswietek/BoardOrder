using System.Windows.Media;

namespace BoardOrder.Domain.Models {
	public class ColorBoardOrderItem : BoardOrderItem {
		public ColorBoardOrderItem(Color color, string name, double costModifier, float workdaysModifier, CostType type)
			: base(name, costModifier, workdaysModifier, type) {
			this.Color = color;
		}

		public ColorBoardOrderItem(Color color, string name, CostType type)
			: base(name, type) {
			this.Color = color;
		}

		public Color Color { get; set; }
	}
}
