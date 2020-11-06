using GalaSoft.MvvmLight;
using System.ComponentModel;
using System.Runtime.Remoting.Messaging;
using System.Text.RegularExpressions;



namespace BoardOrder.Domain.Models {
	public class BoardOrderDetails : ObservableObject, IDataErrorInfo {
		const string ZipCodeRegex = @"^[0-9]{5}(?:-[0-9]{4})?$";

		private string projectName;
		private string zipcode;
		private int boardQuantity;
		private double boardThickness;
		private Material selectedMaterial;
		private SurfaceFinish selectedSurfaceFinish;
		private SolderMaskColor selectedMaskColor;
		private SilkscreenColor selectedSilkscreenColor;
		private InnerLayerCopperWeight selectedInnerLayersCopperWeight;
		private OuterLayerCopperWeight selectedOuterLayersCopperWeight;
		private LeadFreeOption selectedLeadFreeOption;
		private IpcClass selectedIPCClass;
		private ItarComplianceOption selectedITARComplianceOption;
		private FluxType selectedFluxType;
		private ControlledImpedance selectedControlledImpedanceOption;
		private TentingForViasOption selectedTentingForViasOption;
		private StackupOption selectedStackup;

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

		public Material SelectedMaterial {
			get => this.selectedMaterial;
			set => this.Set(ref selectedMaterial, value);
		}

		public SurfaceFinish SelectedSurfaceFinish {
			get => this.selectedSurfaceFinish;
			set => this.Set(ref selectedSurfaceFinish, value);
		}

		public SolderMaskColor SelectedMaskColor {
			get => this.selectedMaskColor;
			set => this.Set(ref selectedMaskColor, value);
		}

		public SilkscreenColor SelectedSilkscreenColor {
			get => this.selectedSilkscreenColor;
			set => this.Set(ref selectedSilkscreenColor, value);
		}

		public InnerLayerCopperWeight SelectedInnerLayersCopperWeight {
			get => this.selectedInnerLayersCopperWeight;
			set => this.Set(ref selectedInnerLayersCopperWeight, value);
		}

		public OuterLayerCopperWeight SelectedOuterLayersCopperWeight {
			get => this.selectedOuterLayersCopperWeight;
			set => this.Set(ref selectedOuterLayersCopperWeight, value);
		}

		public LeadFreeOption SelectedLeadFreeOption {
			get => this.selectedLeadFreeOption;
			set => this.Set(ref selectedLeadFreeOption, value);
		}

		public IpcClass SelectedIPCClass {
			get => this.selectedIPCClass;
			set => this.Set(ref selectedIPCClass, value);
		}

		public ItarComplianceOption SelectedITARComplianceOption {
			get => this.selectedITARComplianceOption;
			set => this.Set(ref selectedITARComplianceOption, value);
		}

		public FluxType SelectedFluxType {
			get => this.selectedFluxType;
			set => this.Set(ref selectedFluxType, value);
		}

		public ControlledImpedance SelectedControlledImpedanceOption {
			get => this.selectedControlledImpedanceOption;
			set => this.Set(ref selectedControlledImpedanceOption, value);
		}

		public TentingForViasOption SelectedTentingForViasOption {
			get => this.selectedTentingForViasOption;
			set => this.Set(ref selectedTentingForViasOption, value);
		}

		public StackupOption SelectedStackup {
			get => this.selectedStackup;
			set => this.Set(ref selectedStackup, value);
		}

		public string this[string columnName] {
			get {
				switch (columnName) {
					case nameof(ProjectName):
						return string.IsNullOrEmpty(ProjectName) ? "Project name cannot be empty." : null;
					case nameof(Zipcode):
						return string.IsNullOrEmpty(Zipcode) || !Regex.IsMatch(Zipcode, ZipCodeRegex) ? "Invalid zip code. Please use 5- or 5+4- digit zipcode format" : null;
					case nameof(BoardsQuantity):
						return this.BoardsQuantity == 0 ? "Boards quantity must be greater than zero." : null;
					case nameof(BoardThickness):
						return BoardThickness < 0.5 || BoardThickness > 3 ? "Board thickness cannot be less than 0.5 and greater than 3 mm" : null;
					default:
						return null;
				}
			}
		}

		public string Error => null;
	}
}
