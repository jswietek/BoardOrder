using BoardOrder.Domain.Services;
using BoardOrder.Messages;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Windows.Input;

namespace BoardOrder.ViewModel {
	/// <summary>
	/// This class contains properties that the main View can data bind to.
	/// </summary>
	public class MainViewModel : ViewModelBase {
		private readonly IOptionsProvider optionsProvider;
		private readonly IQuoteService quoteService;

		private bool isQuoteAvailable;

		/// <summary>
		/// Initializes a new instance of the MainViewModel class.
		/// </summary>
		public MainViewModel(IOptionsProvider optionsProvider, IQuoteService quoteService) {
			this.optionsProvider = optionsProvider;
			this.optionsProvider.Fetching += HandleOptionsProviderFetching;

			this.quoteService = quoteService;

			this.LoadedCommand = new RelayCommand(this.FetchData);
		}

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

		public ICommand LoadedCommand { get; set; }
	}
}