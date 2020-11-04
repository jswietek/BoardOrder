using BoardOrder.Domain.Models;
using BoardOrder.Domain.Services;
using GalaSoft.MvvmLight;

namespace BoardOrder.ViewModel {
	public class PreferencesViewModel : ViewModelBase {
		private readonly IOptionsProvider optionsProvider;

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
			this.OptionsProvider = optionsProvider;
		}

		public IOptionsProvider OptionsProvider { get; }

		public string ProjectName {
			get => this.projectName;
			set => this.Set(ref projectName, value);
		}

		public string Zipcode {
			get => this.zipcode;
			set => this.Set(ref zipcode, value);
		}

		public int BoardsQuantity {
			get => this.boardQuantity;
			set => this.Set(ref boardQuantity, value);
		}

		public double BoardThickness {
			get => this.boardThickness;
			set => this.Set(ref boardThickness, value);
		}

		public BoardOrderItem SelectedMaterial {
			get => this.selectedMaterial;
			set => this.Set(ref selectedMaterial, value);
		}

		public BoardOrderItem SelectedSurfaceFinish {
			get => this.selectedSurfaceFinish;
			set => this.Set(ref selectedSurfaceFinish, value);
		}

		public ColorBoardOrderItem SelectedMaskColor {
			get => this.selectedMaskColor;
			set => this.Set(ref selectedMaskColor, value);
		}

		public ColorBoardOrderItem SelectedSilkscreenColor {
			get => this.selectedSilkscreenColor;
			set => this.Set(ref selectedSilkscreenColor, value);
		}

		public BoardOrderItem SelectedInnerLayersCopperWeight {
			get => this.selectedInnerLayersCopperWeight;
			set => this.Set(ref selectedInnerLayersCopperWeight, value);
		}

		public BoardOrderItem SelectedOuterLayersCopperWeight {
			get => this.selectedOuterLayersCopperWeight;
			set => this.Set(ref selectedOuterLayersCopperWeight, value);
		}

		public BoardOrderItem SelectedLeadFreeOption {
			get => this.selectedLeadFreeOption;
			set => this.Set(ref selectedLeadFreeOption, value);
		}

		public BoardOrderItem SelectedIPCClass {
			get => this.selectedIPCClass;
			set => this.Set(ref selectedIPCClass, value);
		}

		public BoardOrderItem SelectedITARComplianceOption {
			get => this.selectedITARComplianceOption;
			set => this.Set(ref selectedITARComplianceOption, value);
		}

		public BoardOrderItem SelectedFluxType {
			get => this.selectedFluxType;
			set => this.Set(ref selectedFluxType, value);
		}

		public BoardOrderItem SelectedControlledImpedanceOption {
			get => this.selectedControlledImpedanceOption;
			set => this.Set(ref selectedControlledImpedanceOption, value);
		}

		public BoardOrderItem SelectedTentingForViasOption {
			get => this.selectedTentingForViasOption;
			set => this.Set(ref selectedTentingForViasOption, value);
		}

		public BoardOrderItem SelectedStackup {
			get => this.selectedStackup;
			set => this.Set(ref selectedStackup, value);
		}

		private void InitializeMembers() {
			this.ProjectName = string.Empty;
			this.Zipcode = string.Empty;
			this.BoardsQuantity = 0;
			this.BoardThickness = 1.0;
		}
	}
}
