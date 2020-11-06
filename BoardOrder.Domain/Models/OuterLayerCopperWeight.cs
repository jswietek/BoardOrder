namespace BoardOrder.Domain.Models {
	public class OuterLayerCopperWeight : BoardOrderItem {
		public const string ParameterName = "Outer Layer Copper Weight";

		public OuterLayerCopperWeight(string value)
			: base(value) {
		}

		public OuterLayerCopperWeight(string value, double costModifier, double workdaysModifier)
			: base(value, costModifier, workdaysModifier) {
		}

		public override string Name => ParameterName;

		public override CostType CostType => CostType.Fabrication;
	}
}
