namespace BoardOrder.Domain {
	public class BoardOrderItem {
		public BoardOrderItem(string name)
			: this(name, 0, 0) { }

		public BoardOrderItem(string name, int costModifier, int workdaysModifier) {
			this.Name = Name;
			this.CostModifier = CostModifier;
			this.WorkdaysModifier = WorkdaysModifier;
		}

		public string Name { get; }

		public int CostModifier { get; }

		public int WorkdaysModifier { get; }
	}
}
