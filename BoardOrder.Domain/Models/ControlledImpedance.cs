namespace BoardOrder.Domain.Models {
	public class ControlledImpedance : BoardOrderItem {
		public const string ParameterName = "Controlled Impedance";

		public ControlledImpedance(string value)
			: base(value) {
		}

		public ControlledImpedance(string value, double costModifier, double workdaysModifier)
			: base(value, costModifier, workdaysModifier) {
		}

		public override string Name => ParameterName;

		public override CostType CostType => CostType.Assembly;
	}
}
