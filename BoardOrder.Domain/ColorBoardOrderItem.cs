using System.Windows.Media;

namespace BoardOrder.Domain {
	public class ColorBoardOrderItem : BoardOrderItem {
		public ColorBoardOrderItem(Color color, string name, double costModifier, float workdaysModifier)
			: base(name, costModifier, workdaysModifier) {
			this.Color = color;
		}

		public ColorBoardOrderItem(Color color, string name)
			: base(name) {
			this.Color = color;
		}

		public Color Color { get; set; }
	}
}
