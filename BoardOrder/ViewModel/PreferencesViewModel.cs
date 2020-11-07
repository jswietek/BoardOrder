using BoardOrder.Domain.Models;
using BoardOrder.Domain.Services;
using BoardOrder.Messages;
using GalaSoft.MvvmLight;
using System;
using System.ComponentModel;

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

		private void HandleLoadingFinished(LoadingFinishedMessage _) {
			this.Order = this.boardOrdersManager.ResetOrder();
		}

		public IPreferencesOptions PreferencesOptions { get; }

		public BoardOrderDetails Order {
			get => this.boardOrderDetails;
			set {
				if(this.Order != null) {
					this.Order.PropertyChanged -= this.HanldePropertyChanged;
				}
				this.Set(ref this.boardOrderDetails, value);
				if (this.Order != null) {
					this.Order.PropertyChanged += this.HanldePropertyChanged;
				}
			}
		}

		private void HanldePropertyChanged(object sender, PropertyChangedEventArgs e) {
			object a = null;
		}
	}
}
