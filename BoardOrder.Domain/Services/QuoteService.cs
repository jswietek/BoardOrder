using BoardOrder.Domain.DataAccess;
using BoardOrder.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoardOrder.Domain.Services {
	public class QuoteService : IQuoteService {
		private readonly IPreferencesSettingsRepository settingsRepo;

		public QuoteService(IPreferencesSettingsRepository settingsRepo) {
			this.settingsRepo = settingsRepo;
		}

		public async Task<IEnumerable<BoardOrderItem>> ExtractQuote(BoardOrderDetails orderDetails) {
			var values = orderDetails.GetType().GetProperties().Where(prop => typeof(BoardOrderItem).IsAssignableFrom(prop.PropertyType));
			await Task.Delay(100).ConfigureAwait(false);
			var items = values.Select(p => p.GetValue(orderDetails)).Cast<BoardOrderItem>();
			return items;
		}

		public async Task<IEnumerable<BoardOrderItem>> LoadBaseCosts() {
			return await this.settingsRepo.GetBaseCostsAsync().ConfigureAwait(false);
		}
	}
}
