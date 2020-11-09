namespace BoardOrder.Messages {
	public class LoadingFinishedMessage {
		public LoadingFinishedMessage() {
			this.ShouldResetOrder = false;
		}

		public LoadingFinishedMessage(bool shouldResetOrder) {
			this.ShouldResetOrder = shouldResetOrder;
		}

		public bool ShouldResetOrder {
			get;
		}
	}
}
