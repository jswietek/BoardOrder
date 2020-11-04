namespace BoardOrder.Common.Messages {
	public class LoadingInitializedMessage {
		public LoadingInitializedMessage(string message) {
			this.Message = message;
		}

		public string Message { get; set; }
	}
}
