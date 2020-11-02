namespace BoardOrder.Domain {
	public class BoardOrderItem {
		public BoardOrderItem(string name)
			: this(name, 0, 0) { }

		public BoardOrderItem(string name, double costModifier, double workdaysModifier) {
			this.Name = name;
			this.CostModifier = costModifier;
			this.WorkdaysModifier = workdaysModifier;
		}

		public string Name { get; }

		public double CostModifier { get; }

		public double WorkdaysModifier { get; }

		public override string ToString() {
			return this.Name;
		}
	}
}
