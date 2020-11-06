namespace BoardOrder.Domain.Models {
	public class LeadFreeOption : BoardOrderItem {
		public const string ParameterName = "Lead Free Option";

		public LeadFreeOption(string value)
			: base(value) {
		}

		public LeadFreeOption(string value, double costModifier, double workdaysModifier)
			: base(value, costModifier, workdaysModifier) {
		}

		public override string Name => ParameterName;

		public override CostType CostType => CostType.Parts;
	}
}
