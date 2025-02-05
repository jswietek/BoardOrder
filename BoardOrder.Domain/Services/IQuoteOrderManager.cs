﻿using BoardOrder.Domain.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace BoardOrder.Domain.Services {
	public interface IQuoteManager {
		event PropertyChangedEventHandler OrderModified;
		int BoardsQuantity { get; }
		bool IsQuoteAvailable { get; }
		ObservableCollection<BoardOrderItem> Quote { get; }
	}
}