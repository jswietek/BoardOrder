using GalaSoft.MvvmLight.Messaging;

namespace BoardOrder.Messages {
	public class LoadingFinishedMessage : MessageBase {
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
