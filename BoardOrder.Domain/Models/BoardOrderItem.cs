namespace BoardOrder.Domain.Models {
	public class BoardOrderItem {
		public BoardOrderItem(string name, CostType type)
			: this(name, 0, 0, type) { }

		public BoardOrderItem(string name, double costModifier, double workdaysModifier, CostType type) {
			this.Name = name;
			this.CostModifier = costModifier;
			this.WorkdaysModifier = workdaysModifier;
			this.CostType = type;
		}

		public string Name { get; }

		public double CostModifier { get; }

		public double WorkdaysModifier { get; }

		public CostType CostType { get; }

		public override string ToString() {
			return this.Name;
		}
	}
}
