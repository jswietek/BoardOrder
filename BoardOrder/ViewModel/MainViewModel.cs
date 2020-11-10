using BoardOrder.Domain.Services;
using BoardOrder.Messages;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Input;

namespace BoardOrder.ViewModel {
	/// <summary>
	/// This class contains properties that the main View can data bind to.
	/// </summary>
	public class MainViewModel : ViewModelBase {
		private readonly IOptionsProvider optionsProvider;
		private readonly IBoardOrderManager boardOrderManager;

		/// <summary>
		/// Initializes a new instance of the MainViewModel class.
		/// </summary>
		public MainViewModel(IOptionsProvider optionsProvider, IBoardOrderManager boardOrderManager) {
			this.optionsProvider = optionsProvider;
			this.optionsProvider.Fetching += HandleOptionsProviderFetching;

			this.boardOrderManager = boardOrderManager;
			this.boardOrderManager.OrderModified += this.HandleOrderModified;
			this.boardOrderManager.OrderReset += this.HandleOrderReset;

			this.ResetOrderCommand = new RelayCommand(this.RequestOrderReset);
			this.SaveOrderCommand = new RelayCommand(this.SaveOrder, this.CanSaveOrder);
			this.LoadedCommand = new RelayCommand(this.FetchData);
			this.PlaceOrderCommand = new RelayCommand(this.PlaceOrder, this.CanPlaceOrder);

			this.MessengerInstance.Register<RestOrderConfirmationMessage>(this, this.ResetOrder);
		}

		public ICommand LoadedCommand { get; set; }

		public ICommand ResetOrderCommand { get; set; }

		public ICommand SaveOrderCommand { get; set; }

		public ICommand PlaceOrderCommand { get; set; }

		public bool IsQuoteAvailable => this.boardOrderManager.IsQuoteAvailable;

		public override void Cleanup() {
			this.optionsProvider.Fetching -= HandleOptionsProviderFetching;
			base.Cleanup();
		}

		private async void FetchData() {
			await this.optionsProvider?.FetchOptions();
			this.MessengerInstance.Send(new LoadingFinishedMessage(true));
		}

		private void HandleOptionsProviderFetching(string message) {
			this.MessengerInstance.Send(new LoadingInitializedMessage(message));
		}

		private void HandleOrderModified(object sender, PropertyChangedEventArgs e) {
			(SaveOrderCommand as RelayCommand)?.RaiseCanExecuteChanged();
			(PlaceOrderCommand as RelayCommand)?.RaiseCanExecuteChanged();
		}

		private bool CanSaveOrder() {
			return this.boardOrderManager.IsOrderValid;
		}

		private async void SaveOrder() {
			this.MessengerInstance.Send(new LoadingInitializedMessage("Calculating quote"));
			if (await this.boardOrderManager.SaveOrder()) {
				RaisePropertyChanged(nameof(this.IsQuoteAvailable));
				(PlaceOrderCommand as RelayCommand)?.RaiseCanExecuteChanged();
				this.MessengerInstance.Send(new OrderDetailsSaved());
			}

			this.MessengerInstance.Send(new LoadingFinishedMessage());
		}

		private bool CanPlaceOrder() {
			return this.boardOrderManager.IsOrderValid && this.boardOrderManager.IsQuoteAvailable;
		}

		private async void PlaceOrder() {
			this.MessengerInstance.Send(new LoadingInitializedMessage("Placing order..."));
			var placedOrderItem = await this.boardOrderManager.PlaceOrder();
			this.boardOrderManager.ResetOrder();
			this.MessengerInstance.Send(new OrderPlacedMessage(placedOrderItem));
			this.MessengerInstance.Send(new LoadingFinishedMessage(true));
		}

		private void RequestOrderReset() {
			this.MessengerInstance.Send(new RequestResetOrderMessage());
		}

		private void ResetOrder(RestOrderConfirmationMessage confirmationMessage) {
			if (!confirmationMessage.IsResetConfirmed) {
				return;
			}

			this.boardOrderManager.ResetOrder();
		}

		private void HandleOrderReset() {
			(PlaceOrderCommand as RelayCommand)?.RaiseCanExecuteChanged();
			RaisePropertyChanged(nameof(this.IsQuoteAvailable));
		}
	}
}