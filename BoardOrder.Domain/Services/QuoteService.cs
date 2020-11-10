using BoardOrder.Domain.DataAccess;
using BoardOrder.Domain.Models;
using System;
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

		public int CalculatePercentage(double sum, double total) {
			return (int)(sum / total * 100);
		}

		public double CalculateSumCost(IEnumerable<BoardOrderItem> items, int boardsQuantity) {
			return items?.Sum(item => item.CostModifier * boardsQuantity) ?? 0;
		}

		public double CalculateSumTime(IEnumerable<BoardOrderItem> items, int boardsQuantity) {
			return Math.Round(items?.Sum(item => item.WorkdaysModifier * boardsQuantity) ?? 0);
		}
	}
}
