using BoardOrder.Domain;
using System.Collections.Generic;

namespace BoardOrder.DataAccess {
	public interface IPreferencesSettingsRepository {
		IEnumerable<BoardOrderItem> GetInnerLayerCopperWeights();
		IEnumerable<BoardOrderItem> GetMaterials();
		IEnumerable<BoardOrderItem> GetOuterLayerCopperWeights();
		IEnumerable<ColorBoardOrderItem> GetSilkscreenColors();
		IEnumerable<ColorBoardOrderItem> GetSolderMaskColors();
		IEnumerable<BoardOrderItem> GetSurfaceFinishes();
	}
}