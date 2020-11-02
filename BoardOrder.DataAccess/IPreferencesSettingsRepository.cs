using BoardOrder.Domain;
using System.Collections.Generic;

namespace BoardOrder.DataAccess {
	public interface IPreferencesSettingsRepository {
		IEnumerable<BoardOrderItem> GetInnerLayerCopperWeights();
		IEnumerable<BoardOrderItem> GetMaterials();
		IEnumerable<BoardOrderItem> GetSurfaceFinishes();
		IEnumerable<BoardOrderItem> GetOuterLayerCopperWeights();
		IEnumerable<ColorBoardOrderItem> GetSilkscreenColors();
		IEnumerable<ColorBoardOrderItem> GetSolderMaskColors();
		IEnumerable<BoardOrderItem> GetLeadFreeOptions();
		IEnumerable<BoardOrderItem> GetIpcClasses();
		IEnumerable<BoardOrderItem> GetItarComplianceOptions();
		IEnumerable<BoardOrderItem> GetFluxTypes();
		IEnumerable<BoardOrderItem> GetControlledImpedanceOptions();
		IEnumerable<BoardOrderItem> GetTentingForViasOptions();
		IEnumerable<BoardOrderItem> GetStackupOptions();
	}
}