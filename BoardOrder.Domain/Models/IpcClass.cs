namespace BoardOrder.Domain.Models {
	public class IpcClass : BoardOrderItem {
		public const string ParameterName = "IPC class";

		public IpcClass(string value)
			: base(value) {
		}

		public IpcClass(string value, double costModifier, double workdaysModifier)
			: base(value, costModifier, workdaysModifier) {
		}

		public override string Name => ParameterName;

		public override CostType CostType => CostType.Parts;
	}
}
