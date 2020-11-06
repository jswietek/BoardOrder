namespace BoardOrder.Domain.Models {
	public class SurfaceFinish : BoardOrderItem {
		public const string ParameterName = "Surface Finish";

		public SurfaceFinish(string value)
			: base(value) {
		}

		public SurfaceFinish(string value, double costModifier, double workdaysModifier)
			: base(value, costModifier, workdaysModifier) {
		}

		public override string Name => ParameterName;

		public override CostType CostType => CostType.Fabrication;
	}
}
