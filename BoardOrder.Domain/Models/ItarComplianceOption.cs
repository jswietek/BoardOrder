namespace BoardOrder.Domain.Models {
	public class ItarComplianceOption : BoardOrderItem {
		public const string ParameterName = "ITAR Compliance";

		public ItarComplianceOption(string value)
			: base(value) {
		}

		public ItarComplianceOption(string value, double costModifier, double workdaysModifier)
			: base(value, costModifier, workdaysModifier) {
		}

		public override string Name => ParameterName;

		public override CostType CostType => CostType.Assembly;
	}
}
