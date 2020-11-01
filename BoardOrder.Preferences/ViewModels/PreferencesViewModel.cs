using BoardOrder.Common;
using BoardOrder.DataAccess;
using BoardOrder.Domain;

namespace BoardOrder.Preferences.ViewModels {
	public class PreferencesViewModel : ViewModelBase {

		private BoardOrderItem selectedMaterial;
		private BoardOrderItem selectedSurfaceFinish;
		private ColorBoardOrderItem selectedMaskColor;
		private ColorBoardOrderItem selectedSilkscreenColor;
		private BoardOrderItem selectedInnerLayersCopperWeight;
		private BoardOrderItem selectedOuterLayersCopperWeight;

		public PreferencesViewModel(/*IPreferencesSettingsRepository preferencesSettingsRepository*/) {
			this.OptionsViewModel = new PreferencesOptionsViewModel(new PredefinedPreferencesSettingsRepository());
		}

		public string ProjectName { get; set; }
		public string Zipcode { get; set; }
		public int BoardsQuantity { get; set; }
		public PreferencesOptionsViewModel OptionsViewModel { get; private set; }

		public BoardOrderItem SelectedMaterial {
			get {
				return this.selectedMaterial;
			}
			set {
				this.selectedMaterial = value;
				this.RaisePropertyChanged(nameof(SelectedMaterial));
			}
		}
		public BoardOrderItem SelectedSurfaceFinish {
			get {
				return this.selectedSurfaceFinish;
			}
			set {
				this.selectedSurfaceFinish = value;
				this.RaisePropertyChanged(nameof(SelectedMaterial));
			}
		}

		public ColorBoardOrderItem SelectedMaskColor {
			get {
				return this.selectedMaskColor;
			}
			set {
				this.selectedMaskColor = value;
				this.RaisePropertyChanged(nameof(SelectedMaterial));
			}
		}

		public ColorBoardOrderItem SelectedSilkscreenColor {
			get {
				return this.selectedSilkscreenColor;
			}
			set {
				this.selectedSilkscreenColor = value;
				this.RaisePropertyChanged(nameof(SelectedSilkscreenColor));
			}
		}
		public BoardOrderItem SelectedInnerLayersCopperWeight {
			get {
				return this.selectedInnerLayersCopperWeight;
			}
			set {
				this.selectedInnerLayersCopperWeight = value;
				this.RaisePropertyChanged(nameof(SelectedInnerLayersCopperWeight));
			}
		}

		public BoardOrderItem SelectedOuterLayersCopperWeight {
			get {
				return this.selectedOuterLayersCopperWeight;
			}
			set {
				this.selectedOuterLayersCopperWeight = value;
				this.RaisePropertyChanged(nameof(SelectedOuterLayersCopperWeight));
			}
		}
	}
}
