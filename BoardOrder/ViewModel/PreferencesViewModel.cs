using BoardOrder.Common.Messages;
using BoardOrder.Domain.Models;
using BoardOrder.Domain.Services;
using GalaSoft.MvvmLight;

namespace BoardOrder.ViewModel {
	public class PreferencesViewModel : ViewModelBase {
		private readonly IBoardOrdersManager boardOrdersManager;

		private BoardOrderDetails boardOrderDetails;

		public PreferencesViewModel(IPreferencesOptions preferencesOptions, IBoardOrdersManager boardOrdersManager) {
			this.PreferencesOptions = preferencesOptions;
			this.boardOrdersManager = boardOrdersManager;

			this.MessengerInstance.Register<LoadingFinishedMessage>(this, OnLoadingFinished);
		}

		private void OnLoadingFinished(LoadingFinishedMessage _) {
			this.Order = this.boardOrdersManager.GetEmptyOrder();
		}

		public IPreferencesOptions PreferencesOptions { get; }

		public BoardOrderDetails Order {
			get => this.boardOrderDetails;
			set => this.Set(ref this.boardOrderDetails, value);
		}
	}
}
