using BoardOrder.Domain.Models;
using System.Linq;

namespace BoardOrder.Domain.Services {
	public class BoardOrdersManager : IBoardOrdersManager {
		private readonly IPreferencesOptions preferenceOptions;

		public BoardOrdersManager(IPreferencesOptions options) {
			this.preferenceOptions = options;
		}

		public BoardOrderDetails GetEmptyOrder() {
			var order = new BoardOrderDetails() {
				ProjectName = string.Empty,
				Zipcode = string.Empty,
				BoardsQuantity = 1,
				BoardThickness = 1.0,
				SelectedMaterial = this.preferenceOptions.Materials.FirstOrDefault(),
				SelectedSurfaceFinish = this.preferenceOptions.SurfaceFinishes.FirstOrDefault(),
				SelectedMaskColor = this.preferenceOptions.SolderMaskColors.FirstOrDefault(),
				SelectedSilkscreenColor = this.preferenceOptions.SilkscreenColors.FirstOrDefault(),
				SelectedInnerLayersCopperWeight = this.preferenceOptions.InnerLayersCopperWeights.FirstOrDefault(),
				SelectedOuterLayersCopperWeight = this.preferenceOptions.OuterLayersCopperWeights.FirstOrDefault(),
				SelectedLeadFreeOption = this.preferenceOptions.LeadFreeOptions.FirstOrDefault(),
				SelectedIPCClass = this.preferenceOptions.IpcClasses.FirstOrDefault(),
				SelectedITARComplianceOption = this.preferenceOptions.ItarComplianceOptions.FirstOrDefault(),
				SelectedFluxType = this.preferenceOptions.FluxTypes.FirstOrDefault(),
				SelectedControlledImpedanceOption = this.preferenceOptions.ControlledImpedanceOptions.FirstOrDefault(),
				SelectedTentingForViasOption = this.preferenceOptions.TentingForViasOptions.FirstOrDefault(),
				SelectedStackup = this.preferenceOptions.StackupOptions.FirstOrDefault(),
			};
			return order;
		}
	}
}
