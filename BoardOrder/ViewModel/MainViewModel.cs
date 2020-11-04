using BoardOrder.Domain.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Windows.Input;

namespace BoardOrder.ViewModel {
	/// <summary>
	/// This class contains properties that the main View can data bind to.
	/// </summary>
	public class MainViewModel : ViewModelBase {
		private readonly IOptionsProvider optionsProvider;

		/// <summary>
		/// Initializes a new instance of the MainViewModel class.
		/// </summary>
		public MainViewModel(IOptionsProvider optionsProvider) {
			this.optionsProvider = optionsProvider;

			this.LoadedCommand = new RelayCommand(this.FetchData);
		}

		private async void FetchData() {
			await this.optionsProvider?.FetchOptions();
		}

		public ICommand LoadedCommand { get; set; }
	}
}