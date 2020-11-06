using BoardOrder.Common.Messages;
using BoardOrder.Domain.Models;
using BoardOrder.Domain.Services;
using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;

namespace BoardOrder.ViewModel {
	public class QuoteViewModel : ViewModelBase {
		private ObservableCollection<BoardOrderItem> quote;
		private BoardOrderDetails details;
		IQuoteService quoteService;

		public QuoteViewModel(IQuoteService quoteService) {
			this.quoteService = quoteService;
			this.MessengerInstance.Register<OrderDetailsSaved>(this, this.HandleOrderDetailsSaved);
		}

		public ObservableCollection<BoardOrderItem> Quote {
			get => this.quote;
			set => this.Set(nameof(Quote), ref this.quote);
		}

		public override void Cleanup() {
			this.MessengerInstance.Unregister<OrderDetailsSaved>(this, this.HandleOrderDetailsSaved);
			base.Cleanup();
		}

		private void HandleOrderDetailsSaved(OrderDetailsSaved message) {
			this.details = message.OrderDetails;
			if (this.details != null) {
				this.Quote = new ObservableCollection<BoardOrderItem>(this.quoteService.ExtractQuote(this.details));
			}
		}
	}
}
