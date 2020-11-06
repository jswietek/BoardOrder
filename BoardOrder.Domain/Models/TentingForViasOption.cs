namespace BoardOrder.Domain.Models {
	public class TentingForViasOption : BoardOrderItem {
		public const string ParameterName = "Tenting For Vias";

		public TentingForViasOption(string value)
			: base(value) {
		}

		public TentingForViasOption(string value, double costModifier, double workdaysModifier)
			: base(value, costModifier, workdaysModifier) {
		}

		public override string Name => ParameterName;

		public override CostType CostType => CostType.Assembly;
	}
}
