namespace BoardOrder.Domain.Models {
	public class SolderMaskColor : BoardOrderItem {
		public const string ParameterName = "Solder Mask Color";

		public SolderMaskColor(string value)
			: base(value) {
		}

		public SolderMaskColor(string value, double costModifier, double workdaysModifier)
			: base(value, costModifier, workdaysModifier) {
		}

		public override string Name => ParameterName;

		public override CostType CostType => CostType.Fabrication;
	}
}
