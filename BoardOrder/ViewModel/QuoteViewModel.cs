using BoardOrder.Common.Messages;
using BoardOrder.Domain.Models;
using BoardOrder.Domain.Services;
using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;

namespace BoardOrder.ViewModel {
	public class QuoteViewModel : ViewModelBase {
		private ObservableCollection<BoardOrderItem> quote;

		public QuoteViewModel() {
			this.MessengerInstance.Register<OrderDetailsSaved>(this, this.HandleOrderDetailsSaved);
		}

		public ObservableCollection<BoardOrderItem> Quote {
			get => this.quote;
			set => this.Set(ref this.quote, value);
		}

		public override void Cleanup() {
			this.MessengerInstance.Unregister<OrderDetailsSaved>(this, this.HandleOrderDetailsSaved);
			base.Cleanup();
		}

		private void HandleOrderDetailsSaved(OrderDetailsSaved message) {
			this.Quote = message.OrderQuote != null ? new ObservableCollection<BoardOrderItem>(message.OrderQuote) : null;

		}
	}
}
