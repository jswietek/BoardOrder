using GalaSoft.MvvmLight.Messaging;

namespace BoardOrder.Messages {
	public class RestOrderConfirmationMessage : MessageBase {
		public RestOrderConfirmationMessage(bool isResetConfirmed) {
			this.IsResetConfirmed = isResetConfirmed;
		}

		public bool IsResetConfirmed { get; }
	}
}
