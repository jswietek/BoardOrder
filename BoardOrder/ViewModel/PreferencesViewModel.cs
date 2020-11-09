using BoardOrder.Domain.Models;
using BoardOrder.Domain.Services;
using BoardOrder.Messages;
using GalaSoft.MvvmLight;

namespace BoardOrder.ViewModel {
	public class PreferencesViewModel : ViewModelBase {
		private readonly IBoardOrderManager boardOrdersManager;

		private BoardOrderDetails boardOrderDetails;

		public PreferencesViewModel(IPreferencesOptions preferencesOptions, IBoardOrderManager boardOrdersManager) {
			this.PreferencesOptions = preferencesOptions;
			this.boardOrdersManager = boardOrdersManager;

			this.MessengerInstance.Register<LoadingFinishedMessage>(this, HandleLoadingFinished);
			this.MessengerInstance.Register<OrderDetailsSaveRequested>(this, HandleOrderDetailsSaveRequested);
		}

		private void HandleOrderDetailsSaveRequested(OrderDetailsSaveRequested _) {

		}

		private void HandleLoadingFinished(LoadingFinishedMessage message) {
			if (message.ShouldResetOrder) {
				this.Order = this.boardOrdersManager.ResetOrder();
			}
		}

		public IPreferencesOptions PreferencesOptions { get; }

		public BoardOrderDetails Order {
			get => this.boardOrderDetails;
			set => this.Set(ref this.boardOrderDetails, value);
		}
	}
}
