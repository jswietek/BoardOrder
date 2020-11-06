using BoardOrder.Domain;
using BoardOrder.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BoardOrder.Domain.DataAccess {
	public interface IPreferencesSettingsRepository {
		Task<IEnumerable<BoardOrderItem>> GetControlledImpedanceOptionsAsync();
		Task<IEnumerable<BoardOrderItem>> GetFluxTypesAsync();
		Task<IEnumerable<BoardOrderItem>> GetInnerLayerCopperWeightsAsync();
		Task<IEnumerable<BoardOrderItem>> GetIpcClassesAsync();
		Task<IEnumerable<BoardOrderItem>> GetItarComplianceOptionsAsync();
		Task<IEnumerable<BoardOrderItem>> GetLeadFreeOptionsAsync();
		Task<IEnumerable<BoardOrderItem>> GetMaterialsAsync();
		Task<IEnumerable<BoardOrderItem>> GetOuterLayerCopperWeightsAsync();
		Task<IEnumerable<BoardOrderItem>> GetSilkscreenColorsAsync();
		Task<IEnumerable<BoardOrderItem>> GetSolderMaskColorsAsync();
		Task<IEnumerable<BoardOrderItem>> GetStackupOptionsAsync();
		Task<IEnumerable<BoardOrderItem>> GetSurfaceFinishesAsync();
		Task<IEnumerable<BoardOrderItem>> GetTentingForViasOptionsAsync();
	}
}