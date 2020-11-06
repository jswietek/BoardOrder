using BoardOrder.Domain;
using BoardOrder.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BoardOrder.Domain.DataAccess {
	public interface IPreferencesSettingsRepository {
		Task<IEnumerable<ControlledImpedance>> GetControlledImpedanceOptionsAsync();
		Task<IEnumerable<FluxType>> GetFluxTypesAsync();
		Task<IEnumerable<InnerLayerCopperWeight>> GetInnerLayerCopperWeightsAsync();
		Task<IEnumerable<IpcClass>> GetIpcClassesAsync();
		Task<IEnumerable<ItarComplianceOption>> GetItarComplianceOptionsAsync();
		Task<IEnumerable<LeadFreeOption>> GetLeadFreeOptionsAsync();
		Task<IEnumerable<Material>> GetMaterialsAsync();
		Task<IEnumerable<OuterLayerCopperWeight>> GetOuterLayerCopperWeightsAsync();
		Task<IEnumerable<SilkscreenColor>> GetSilkscreenColorsAsync();
		Task<IEnumerable<SolderMaskColor>> GetSolderMaskColorsAsync();
		Task<IEnumerable<StackupOption>> GetStackupOptionsAsync();
		Task<IEnumerable<SurfaceFinish>> GetSurfaceFinishesAsync();
		Task<IEnumerable<TentingForViasOption>> GetTentingForViasOptionsAsync();
	}
}