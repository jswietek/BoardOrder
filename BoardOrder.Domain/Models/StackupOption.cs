namespace BoardOrder.Domain.Models {
	public class StackupOption : BoardOrderItem {
		public const string ParameterName = "Stackup Option";

		public StackupOption(string value)
			: base(value) {
		}

		public StackupOption(string value, double costModifier, double workdaysModifier)
			: base(value, costModifier, workdaysModifier) {
		}

		public override string Name => ParameterName;

		public override CostType CostType => CostType.Assembly;
	}
}
