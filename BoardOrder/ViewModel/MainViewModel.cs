using BoardOrder.Domain.Services;
using BoardOrder.Messages;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Runtime.InteropServices;
using System.Windows.Input;

namespace BoardOrder.ViewModel {
	/// <summary>
	/// This class contains properties that the main View can data bind to.
	/// </summary>
	public class MainViewModel : ViewModelBase {
		private readonly IOptionsProvider optionsProvider;

		private bool isQuoteAvailable;
		private ICommand resetOrderCommand;
		private ICommand saveOrderCommand;

		/// <summary>
		/// Initializes a new instance of the MainViewModel class.
		/// </summary>
		public MainViewModel(IOptionsProvider optionsProvider) {
			this.optionsProvider = optionsProvider;
			this.optionsProvider.Fetching += HandleOptionsProviderFetching;

			this.ResetOrderCommand = new RelayCommand(this.RequestOrderReset);
			this.SaveOrderCommand = new RelayCommand(this.SaveOrder, this.CanSaveOrder);
			this.LoadedCommand = new RelayCommand(this.FetchData);
		}

		private bool CanSaveOrder() {
			return this.IsQuoteAvailable;
		}

		private void SaveOrder() {
			this.MessengerInstance.Send(new OrderDetailsSaveRequested());
		}

		private void RequestOrderReset() {
			this.IsQuoteAvailable = false;
		}

		public ICommand LoadedCommand { get; set; }

		public ICommand ResetOrderCommand { get; set; }

		public ICommand SaveOrderCommand { get; set; }

		public bool IsQuoteAvailable {
			get => this.isQuoteAvailable;
			set => this.Set(nameof(IsQuoteAvailable), ref this.isQuoteAvailable);
		}

		public override void Cleanup() {
			this.optionsProvider.Fetching -= HandleOptionsProviderFetching;
			base.Cleanup();
		}

		private async void FetchData() {
			await this.optionsProvider?.FetchOptions();
			this.MessengerInstance.Send(new LoadingFinishedMessage());
		}

		private void HandleOptionsProviderFetching(string message) {
			this.MessengerInstance.Send(new LoadingInitializedMessage(message));
		}
	}
}