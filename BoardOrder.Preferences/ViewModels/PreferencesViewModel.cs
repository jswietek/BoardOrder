using BoardOrder.Common;
using BoardOrder.Domain.Models;
using BoardOrder.Domain.Services;

namespace BoardOrder.Preferences.ViewModels {
	public class PreferencesViewModel : ViewModelBase {

		private string projectName;
		private string zipcode;
		private int boardQuantity;
		private double boardThickness;
		private BoardOrderItem selectedMaterial;
		private BoardOrderItem selectedSurfaceFinish;
		private ColorBoardOrderItem selectedMaskColor;
		private ColorBoardOrderItem selectedSilkscreenColor;
		private BoardOrderItem selectedInnerLayersCopperWeight;
		private BoardOrderItem selectedOuterLayersCopperWeight;
		private BoardOrderItem selectedLeadFreeOption;
		private BoardOrderItem selectedIPCClass;
		private BoardOrderItem selectedITARComplianceOption;
		private BoardOrderItem selectedFluxType;
		private BoardOrderItem selectedControlledImpedanceOption;
		private BoardOrderItem selectedTentingForViasOption;
		private BoardOrderItem selectedStackup;

		public PreferencesViewModel(IOptionsProvider optionsProvider) {
			this.InitializeMembers();
		}

		public string ProjectName {
			get {
				return this.projectName;
			}
			set {
				this.projectName = value;
				this.RaisePropertyChanged(nameof(ProjectName));
			}
		}

		public string Zipcode {
			get {
				return this.zipcode;
			}
			set {
				this.zipcode = value;
				this.RaisePropertyChanged(nameof(Zipcode));
			}
		}

		public int BoardsQuantity {
			get {
				return this.boardQuantity;
			}
			set {
				this.boardQuantity = value;
				this.RaisePropertyChanged(nameof(BoardsQuantity));
			}
		}

		public double BoardThickness {
			get {
				return this.boardThickness;
			}
			set {
				this.boardThickness = value;
				this.RaisePropertyChanged(nameof(BoardThickness));
			}
		}

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

		public BoardOrderItem SelectedLeadFreeOption {
			get {
				return this.selectedLeadFreeOption;
			}
			set {
				this.selectedLeadFreeOption = value;
				this.RaisePropertyChanged(nameof(SelectedLeadFreeOption));
			}
		}

		public BoardOrderItem SelectedIPCClass {
			get {
				return this.selectedIPCClass;
			}
			set {
				this.selectedIPCClass = value;
				this.RaisePropertyChanged(nameof(SelectedIPCClass));
			}
		}

		public BoardOrderItem SelectedITARComplianceOption {
			get {
				return this.selectedITARComplianceOption;
			}
			set {
				this.selectedITARComplianceOption = value;
				this.RaisePropertyChanged(nameof(SelectedITARComplianceOption));
			}
		}

		public BoardOrderItem SelectedFluxType {
			get {
				return this.selectedFluxType;
			}
			set {
				this.selectedFluxType = value;
				this.RaisePropertyChanged(nameof(SelectedFluxType));
			}
		}

		public BoardOrderItem SelectedControlledImpedanceOption {
			get {
				return this.selectedControlledImpedanceOption;
			}
			set {
				this.selectedControlledImpedanceOption = value;
				this.RaisePropertyChanged(nameof(SelectedControlledImpedanceOption));
			}
		}

		public BoardOrderItem SelectedTentingForViasOption {
			get {
				return this.selectedTentingForViasOption;
			}
			set {
				this.selectedTentingForViasOption = value;
				this.RaisePropertyChanged(nameof(SelectedTentingForViasOption));
			}
		}

		public BoardOrderItem SelectedStackup {
			get {
				return this.selectedStackup;
			}
			set {
				this.selectedStackup = value;
				this.RaisePropertyChanged(nameof(SelectedStackup));
			}
		}

		private void InitializeMembers() {
			this.ProjectName = string.Empty;
			this.Zipcode = string.Empty;
			this.BoardsQuantity = 0;
			this.BoardThickness = 1.0;
		}
	}
}
