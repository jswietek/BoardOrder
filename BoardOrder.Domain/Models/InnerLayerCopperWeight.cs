namespace BoardOrder.Domain.Models {
	public class InnerLayerCopperWeight : BoardOrderItem {
		public const string ParameterName = "Inner Layer Copper Weight";

		public InnerLayerCopperWeight(string value)
			: base(value) {
		}

		public InnerLayerCopperWeight(string value, double costModifier, double workdaysModifier)
			: base(value, costModifier, workdaysModifier) {
		}

		public override string Name => ParameterName;

		public override CostType CostType => CostType.Fabrication;
	}
}
