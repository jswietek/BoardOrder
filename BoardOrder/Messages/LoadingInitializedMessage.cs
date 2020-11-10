using GalaSoft.MvvmLight.Messaging;

namespace BoardOrder.Messages {
	public class LoadingInitializedMessage : MessageBase {
		public LoadingInitializedMessage(string message) {
			this.Message = message;
		}

		public string Message { get; set; }
	}
}
