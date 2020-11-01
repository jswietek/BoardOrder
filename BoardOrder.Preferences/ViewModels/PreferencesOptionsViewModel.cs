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
	}
}
