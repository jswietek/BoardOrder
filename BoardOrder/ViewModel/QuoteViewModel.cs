using BoardOrder.Common.Messages;
using BoardOrder.Domain.Models;
using BoardOrder.Domain.Services;
using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;

namespace BoardOrder.ViewModel {
	public class QuoteViewModel : ViewModelBase {
		private ObservableCollection<BoardOrderItem> quote;
		private readonly IQuoteManager quoteOrderManager;

		public QuoteViewModel(IQuoteManager quoteOrderManager) {
			this.quoteOrderManager = quoteOrderManager;

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
			this.Quote = this.quoteOrderManager.Quote;
		}
	}
}
