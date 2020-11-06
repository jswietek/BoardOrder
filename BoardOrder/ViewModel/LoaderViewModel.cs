using BoardOrder.Messages;
using GalaSoft.MvvmLight;

namespace BoardOrder.ViewModel {
	public class LoaderViewModel : ViewModelBase {
		private bool isFetchingData;
		private string loaderMessage;

		public LoaderViewModel() {
			this.MessengerInstance.Register<LoadingInitializedMessage>(this, this.OnLoadingInitialized);
			this.MessengerInstance.Register<LoadingFinishedMessage>(this, this.OnLoadingFinished);
		}

		public bool IsFetchingData {
			get => this.isFetchingData;
			set => this.Set(ref this.isFetchingData, value);
		}

		public string LoaderMessage {
			get => this.loaderMessage;
			set => this.Set(ref this.loaderMessage, value);
		}

		public override void Cleanup() {
			this.MessengerInstance.Unregister<LoadingInitializedMessage>(this, this.OnLoadingInitialized);
			this.MessengerInstance.Unregister<LoadingFinishedMessage>(this, this.OnLoadingFinished);
		}

		private void OnLoadingInitialized(LoadingInitializedMessage loadingInitializedMessage) {
			IsFetchingData = true;
			LoaderMessage = loadingInitializedMessage.Message;
		}

		private void OnLoadingFinished(LoadingFinishedMessage _) {
			IsFetchingData = false;
		}
	}
}
