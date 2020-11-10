using BoardOrder.Domain.Models;
using BoardOrder.Domain.Services;
using BoardOrder.Messages;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;

namespace BoardOrder.ViewModel {
	public class PlacedOrdersViewModel : ViewModelBase {
		private readonly IBoardOrderManager orderManager;

		public PlacedOrdersViewModel(IBoardOrderManager orderManager) {
			this.orderManager = orderManager;
			this.orderManager.OrderModified += HandleOrderModified;
			this.orderManager.OrderReset += HandleOrderReset;

			this.PlacedOrders = new ObservableCollection<PlacedOrderItem>();
			this.PlacedOrders.CollectionChanged += HandlePlacedOrdersCollectionChanged;
			this.PlaceCurrentOrderCommand = new RelayCommand(this.PlaceOrder, CanPlaceOrder);

			this.MessengerInstance.Register<OrderDetailsSaved>(this, this.HandleOrderSet);
			this.MessengerInstance.Register<OrderPlacedMessage>(this, this.HandleOrderPlaced);
		}

		public ObservableCollection<PlacedOrderItem> PlacedOrders { get; set; }

		public RelayCommand PlaceCurrentOrderCommand { get; set; }

		public bool ArePlacedOrdersAvailable => PlacedOrders.Count > 0;

		private void HandleOrderReset() {
			this.PlaceCurrentOrderCommand.RaiseCanExecuteChanged();
		}

		private void HandleOrderModified(object sender, PropertyChangedEventArgs e) {
			this.PlaceCurrentOrderCommand.RaiseCanExecuteChanged();
		}

		private void HandleOrderSet(OrderDetailsSaved obj) {
			this.PlaceCurrentOrderCommand.RaiseCanExecuteChanged();
		}

		private bool CanPlaceOrder() {
			return this.orderManager.IsOrderValid && this.orderManager.IsQuoteAvailable;
		}

		private async void PlaceOrder() {
			var placedOrderItem = await this.orderManager.PlaceOrder();
			this.PlacedOrders.Add(placedOrderItem);
		}

		private void HandlePlacedOrdersCollectionChanged(object sender, NotifyCollectionChangedEventArgs e) {
			this.RaisePropertyChanged(nameof(this.ArePlacedOrdersAvailable));
		}

		private void HandleOrderPlaced(OrderPlacedMessage message) {
			this.PlacedOrders.Add(message.PlacedOrderItem);
		}
	}
}
