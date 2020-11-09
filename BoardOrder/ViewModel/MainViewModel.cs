using BoardOrder.Common.Messages;
using BoardOrder.Domain.Services;
using BoardOrder.Messages;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Input;

namespace BoardOrder.ViewModel {
	/// <summary>
	/// This class contains properties that the main View can data bind to.
	/// </summary>
	public class MainViewModel : ViewModelBase {
		private readonly IOptionsProvider optionsProvider;
		private readonly IBoardOrderManager boardOrderManager;

		private bool isQuoteAvailable;

		/// <summary>
		/// Initializes a new instance of the MainViewModel class.
		/// </summary>
		public MainViewModel(IOptionsProvider optionsProvider, IBoardOrderManager boardOrderManager) {
			this.optionsProvider = optionsProvider;
			this.optionsProvider.Fetching += HandleOptionsProviderFetching;

			this.boardOrderManager = boardOrderManager;
			this.boardOrderManager.OrderModified += HandleOrderModified;

			this.ResetOrderCommand = new RelayCommand(this.RequestOrderReset);
			this.SaveOrderCommand = new RelayCommand(this.SaveOrder, this.CanSaveOrder);
			this.LoadedCommand = new RelayCommand(this.FetchData);
		}

		public ICommand LoadedCommand { get; set; }

		public ICommand ResetOrderCommand { get; set; }

		public ICommand SaveOrderCommand { get; set; }

		public bool IsQuoteAvailable {
			get => this.isQuoteAvailable;
			set => this.Set(ref this.isQuoteAvailable, value);
		}

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
		}

		private bool CanSaveOrder() {
			return this.boardOrderManager.IsOrderValid;
		}

		private async void SaveOrder() {
			this.MessengerInstance.Send(new LoadingInitializedMessage("Calculating quote"));
			if (await this.boardOrderManager.SaveOrder()) {
				this.IsQuoteAvailable = true;
				this.MessengerInstance.Send(new OrderDetailsSaved());
			}
			this.MessengerInstance.Send(new LoadingFinishedMessage());
		}

		private void RequestOrderReset() {
			this.boardOrderManager.ResetOrder();
			this.IsQuoteAvailable = false;
		}
	}
}