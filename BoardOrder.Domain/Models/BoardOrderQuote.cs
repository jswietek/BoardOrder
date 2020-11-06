using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardOrder.Domain.Models {
	public class BoardOrderQuote {
		public BoardOrderQuote() {
			OrderItems = new ObservableCollection<BoardOrderItem>();
		}

		public BoardOrderQuote(BoardOrderDetails boardOrderDetails) {
			OrderItems = this.ExtractQuote(boardOrderDetails);
		}

		private ObservableCollection<BoardOrderItem> ExtractQuote(BoardOrderDetails boardOrderDetails) {
			var props = boardOrderDetails.GetType().GetProperties();
			var values = props.Where(prop => prop.PropertyType.IsAssignableFrom(typeof(BoardOrderItem)))
				.Select(p => p.GetValue(boardOrderDetails)).Cast<BoardOrderItem>();

			return new ObservableCollection<BoardOrderItem>(values);
		}

		public ObservableCollection<BoardOrderItem> OrderItems { get; }
	}
}
