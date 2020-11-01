using BoardOrder.Common;

namespace BoardOrder.Preferences.ViewModels {
	public class PreferencesViewModel : ViewModelBase {
		public string ProjectName { get; set; }
		public string Zipcode { get; set; }
		public string BoardsQuantity { get; set; }
	}
}
