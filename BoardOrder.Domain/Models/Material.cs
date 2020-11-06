namespace BoardOrder.Domain.Models {
	public class Material : BoardOrderItem {
		public const string ParameterName = "Material";

		public Material(string value)
			: base(value) {
		}

		public Material(string value, double costModifier, double workdaysModifier)
			: base(value, costModifier, workdaysModifier) {
		}

		public override string Name => ParameterName;

		public override CostType CostType => CostType.Fabrication;
	}
}
