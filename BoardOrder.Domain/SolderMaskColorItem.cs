using System.Windows.Media;

namespace BoardOrder.Domain {
	public class SolderMaskColor : BoardOrderItem {
		public SolderMaskColor(Color color, string name, int costModifier, int workdaysModifier)
			: base(name, costModifier, workdaysModifier) {
			this.Color = color;
		}

		public SolderMaskColor(Color color, string name)
			: base(name) {
			this.Color = color;
		}

		public Color Color { get; set; }
	}
}
