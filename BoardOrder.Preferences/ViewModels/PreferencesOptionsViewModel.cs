using BoardOrder.DataAccess;
using BoardOrder.Domain;
using System.Collections.Generic;

namespace BoardOrder.Preferences.ViewModels {
	public class PreferencesOptionsViewModel {
		private readonly IPreferencesSettingsRepository preferencesSettingsRepository;

		private IEnumerable<BoardOrderItem> materials;

		private IEnumerable<BoardOrderItem> surfaceFinishes;

		private IEnumerable<ColorBoardOrderItem> solderMaskColors;

		private IEnumerable<ColorBoardOrderItem> silkscreenColors;

		private IEnumerable<BoardOrderItem> innerLayersCopperWeights;

		private IEnumerable<BoardOrderItem> outerLayersCopperWeights;

		private IEnumerable<BoardOrderItem> leadFreeOptions;

		private IEnumerable<BoardOrderItem> ipcClasses;

		private IEnumerable<BoardOrderItem> itarComplianceOptions;

		private IEnumerable<BoardOrderItem> fluxTypes;

		private IEnumerable<BoardOrderItem> controlledImpedanceOptions;

		private IEnumerable<BoardOrderItem> tentingForViasOptions;

		private IEnumerable<BoardOrderItem> stackupOptions;

		public PreferencesOptionsViewModel(IPreferencesSettingsRepository preferencesSettingsRepository) {
			this.preferencesSettingsRepository = preferencesSettingsRepository;
		}

		public IEnumerable<BoardOrderItem> Materials {
			get {
				if (this.materials == null) {
					this.materials = this.preferencesSettingsRepository.GetMaterials();
				}

				return this.materials;
			}
		}

		public IEnumerable<BoardOrderItem> SurfaceFinishes {
			get {
				if (this.surfaceFinishes == null) {
					this.surfaceFinishes = this.preferencesSettingsRepository.GetSurfaceFinishes();
				}

				return this.surfaceFinishes;
			}
		}

		public IEnumerable<ColorBoardOrderItem> SolderMaskColors {
			get {
				if (this.solderMaskColors == null) {
					this.solderMaskColors = this.preferencesSettingsRepository.GetSolderMaskColors();
				}

				return this.solderMaskColors;
			}
		}

		public IEnumerable<ColorBoardOrderItem> SilkscreenColors {
			get {
				if (this.silkscreenColors == null) {
					this.silkscreenColors = this.preferencesSettingsRepository.GetSilkscreenColors();
				}

				return this.silkscreenColors;
			}
		}

		public IEnumerable<BoardOrderItem> InnerLayersCopperWeights {
			get {
				if (this.innerLayersCopperWeights == null) {
					this.innerLayersCopperWeights = this.preferencesSettingsRepository.GetInnerLayerCopperWeights();
				}

				return this.innerLayersCopperWeights;
			}
		}

		public IEnumerable<BoardOrderItem> OuterLayersCopperWeights {
			get {
				if (this.outerLayersCopperWeights == null) {
					this.outerLayersCopperWeights = this.preferencesSettingsRepository.GetOuterLayerCopperWeights();
				}

				return this.outerLayersCopperWeights;
			}
		}

		public IEnumerable<BoardOrderItem> LeadFreeOptions {
			get {
				if (this.leadFreeOptions == null) {
					this.leadFreeOptions = this.preferencesSettingsRepository.GetLeadFreeOptions();
				}

				return this.leadFreeOptions;
			}
		}

		public IEnumerable<BoardOrderItem> IpcClasses {
			get {
				if (this.ipcClasses == null) {
					this.ipcClasses = this.preferencesSettingsRepository.GetIpcClasses();
				}

				return this.ipcClasses;
			}
		}

		public IEnumerable<BoardOrderItem> ItarComplianceOptions {
			get {
				if (this.itarComplianceOptions == null) {
					this.itarComplianceOptions = this.preferencesSettingsRepository.GetItarComplianceOptions();
				}

				return this.itarComplianceOptions;
			}
		}

		public IEnumerable<BoardOrderItem> FluxTypes {
			get {
				if (this.fluxTypes == null) {
					this.fluxTypes = this.preferencesSettingsRepository.GetFluxTypes();
				}

				return this.fluxTypes;
			}
		}

		public IEnumerable<BoardOrderItem> ControlledImpedanceOptions {
			get {
				if (this.controlledImpedanceOptions == null) {
					this.controlledImpedanceOptions = this.preferencesSettingsRepository.GetControlledImpedanceOptions();
				}

				return this.controlledImpedanceOptions;
			}
		}

		public IEnumerable<BoardOrderItem> TentingForViasOptions {
			get {
				if (this.tentingForViasOptions == null) {
					this.tentingForViasOptions = this.preferencesSettingsRepository.GetTentingForViasOptions();
				}

				return this.tentingForViasOptions;
			}
		}

		public IEnumerable<BoardOrderItem> StackupOptions {
			get {
				if (this.stackupOptions == null) {
					this.stackupOptions = this.preferencesSettingsRepository.GetStackupOptions();
				}

				return this.stackupOptions;
			}
		}
	}
}
