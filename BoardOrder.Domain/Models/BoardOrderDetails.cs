using GalaSoft.MvvmLight;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Security.Permissions;
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
		private ObservableCollection<BoardOrderItem> quote;


		public string ProjectName {
			get => this.projectName;
			set => this.ModifyOrder(nameof(this.ProjectName), ref projectName, value);
		}

		public string Zipcode {
			get => this.zipcode;
			set => this.ModifyOrder(nameof(this.Zipcode), ref zipcode, value);
		}

		public int BoardsQuantity {
			get => this.boardQuantity;
			set => this.ModifyOrder(nameof(this.BoardsQuantity), ref boardQuantity, value);
		}

		public double BoardThickness {
			get => this.boardThickness;
			set => this.ModifyOrder(nameof(this.BoardThickness), ref boardThickness, value);
		}

		public Material SelectedMaterial {
			get => this.selectedMaterial;
			set => this.ModifyOrderPreferences(nameof(this.SelectedMaterial), ref selectedMaterial, value);
		}

		public SurfaceFinish SelectedSurfaceFinish {
			get => this.selectedSurfaceFinish;
			set => this.ModifyOrderPreferences(nameof(this.SelectedSurfaceFinish), ref selectedSurfaceFinish, value);
		}

		public SolderMaskColor SelectedMaskColor {
			get => this.selectedMaskColor;
			set => this.ModifyOrderPreferences(nameof(this.SelectedMaskColor), ref selectedMaskColor, value);
		}

		public SilkscreenColor SelectedSilkscreenColor {
			get => this.selectedSilkscreenColor;
			set => this.ModifyOrderPreferences(nameof(this.SelectedSilkscreenColor), ref selectedSilkscreenColor, value);
		}

		public InnerLayerCopperWeight SelectedInnerLayersCopperWeight {
			get => this.selectedInnerLayersCopperWeight;
			set => this.ModifyOrderPreferences(nameof(this.SelectedInnerLayersCopperWeight), ref selectedInnerLayersCopperWeight, value);
		}

		public OuterLayerCopperWeight SelectedOuterLayersCopperWeight {
			get => this.selectedOuterLayersCopperWeight;
			set => this.ModifyOrderPreferences(nameof(this.SelectedOuterLayersCopperWeight), ref selectedOuterLayersCopperWeight, value);
		}

		public LeadFreeOption SelectedLeadFreeOption {
			get => this.selectedLeadFreeOption;
			set => this.ModifyOrderPreferences(nameof(this.SelectedLeadFreeOption), ref selectedLeadFreeOption, value);
		}

		public IpcClass SelectedIPCClass {
			get => this.selectedIPCClass;
			set => this.ModifyOrderPreferences(nameof(this.SelectedIPCClass), ref selectedIPCClass, value);
		}

		public ItarComplianceOption SelectedITARComplianceOption {
			get => this.selectedITARComplianceOption;
			set => this.ModifyOrderPreferences(nameof(this.SelectedITARComplianceOption), ref selectedITARComplianceOption, value);
		}

		public FluxType SelectedFluxType {
			get => this.selectedFluxType;
			set => this.ModifyOrderPreferences(nameof(this.SelectedFluxType), ref selectedFluxType, value);
		}

		public ControlledImpedance SelectedControlledImpedanceOption {
			get => this.selectedControlledImpedanceOption;
			set => this.ModifyOrderPreferences(nameof(this.SelectedControlledImpedanceOption), ref selectedControlledImpedanceOption, value);
		}

		public TentingForViasOption SelectedTentingForViasOption {
			get => this.selectedTentingForViasOption;
			set => this.ModifyOrderPreferences(nameof(this.SelectedTentingForViasOption), ref selectedTentingForViasOption, value);
		}

		public StackupOption SelectedStackup {
			get => this.selectedStackup;
			set => this.ModifyOrderPreferences(nameof(this.SelectedStackup), ref selectedStackup, value);
		}

		public string Error => string.Join(Environment.NewLine, typeof(BoardOrderDetails).GetProperties().Select(prop => this[prop.Name]).Where(err => !string.IsNullOrEmpty(err)));

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

		public ObservableCollection<BoardOrderItem> Quote {
			get => this.quote;
			set => this.quote = value;
		}

		private void ModifyOrder<T>(string propertyName, ref T field, T newValue) {
			base.Set(propertyName, ref field, newValue);
			RaisePropertyChanged(nameof(Error));
		}

		private void ModifyOrderPreferences<T>(string propertyName, ref T field, T newValue) where T : BoardOrderItem {
			if (Quote != null) {
				var index = this.Quote.IndexOf(field);
				this.Quote[index] = newValue;
			}
			this.ModifyOrder(propertyName, ref field, newValue);
		}
	}
}
