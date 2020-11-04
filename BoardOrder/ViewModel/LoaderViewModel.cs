using BoardOrder.Common.Messages;
using GalaSoft.MvvmLight;

namespace BoardOrder.ViewModel {
	public class LoaderViewModel : ViewModelBase {
		private bool isFetchingData;
		private string loaderMessage;

		public LoaderViewModel() {
			this.MessengerInstance.Register<LoadingInitializedMessage>(this, OnLoadingInitialized);
			this.MessengerInstance.Register<LoadingFinishedMessage>(this, OnLoadingFinished);
		}

		public bool IsFetchingData {
			get => this.isFetchingData;
			set => this.Set(ref this.isFetchingData, value);
		}

		public string LoaderMessage {
			get => this.loaderMessage;
			set => this.Set(ref this.loaderMessage, value);
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
