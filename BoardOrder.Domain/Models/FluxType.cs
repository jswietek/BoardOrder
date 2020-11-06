namespace BoardOrder.Domain.Models {
	public class FluxType : BoardOrderItem {
		public const string ParameterName = "Flux Type";

		public FluxType(string value)
			: base(value) {
		}

		public FluxType(string value, double costModifier, double workdaysModifier)
			: base(value, costModifier, workdaysModifier) {
		}

		public override string Name => ParameterName;

		public override CostType CostType => CostType.Assembly;
	}
}
