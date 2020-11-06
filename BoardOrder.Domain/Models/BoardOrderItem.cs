namespace BoardOrder.Domain.Models {
	public class BoardOrderItem {
		public BoardOrderItem(string value)
			: this(value, 0, 0) { }

		public BoardOrderItem(string value, double costModifier, double workdaysModifier) {
			this.Value = value;
			this.CostModifier = costModifier;
			this.WorkdaysModifier = workdaysModifier;
		}

		public virtual string Name { get; }

		public string Value { get; }

		public double CostModifier { get; }

		public double WorkdaysModifier { get; }

		public virtual CostType CostType { get; }

		public override string ToString() {
			return this.Value;
		}
	}
}
