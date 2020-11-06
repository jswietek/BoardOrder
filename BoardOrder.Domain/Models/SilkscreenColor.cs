namespace BoardOrder.Domain.Models {
	public class SilkscreenColor : BoardOrderItem {
		public const string ParameterName = "Silkscreen Color";

		public SilkscreenColor(string value)
			: base(value) {
		}

		public SilkscreenColor(string value, double costModifier, double workdaysModifier)
			: base(value, costModifier, workdaysModifier) {
		}

		public override string Name => ParameterName;

		public override CostType CostType => CostType.Fabrication;
	}
}
