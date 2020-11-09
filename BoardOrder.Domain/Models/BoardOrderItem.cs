namespace BoardOrder.Domain.Models {
	public class BoardOrderItem {
		public BoardOrderItem(string value)
			: this(value, 0, 0) { }

		public BoardOrderItem(string value, double costModifier, double workdaysModifier) {
			this.Value = value;
			this.CostModifier = costModifier;
			this.WorkdaysModifier = workdaysModifier;
		}

		public BoardOrderItem(string name, string value, double costModifier, double workdaysModifier, CostType costType) {
			this.Name = name;
			this.Value = value;
			this.CostModifier = costModifier;
			this.WorkdaysModifier = workdaysModifier;
			this.CostType = costType;
		}

		public virtual string Name { get; }

		public string Value { get; }

		public double CostModifier { get; set; }

		public double WorkdaysModifier { get; set; }

		public virtual CostType CostType { get; }

		public override string ToString() {
			return this.Value;
		}
	}
}
