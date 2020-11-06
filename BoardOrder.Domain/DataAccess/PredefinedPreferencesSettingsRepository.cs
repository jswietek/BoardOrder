using BoardOrder.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BoardOrder.Domain.DataAccess {
	public class PredefinedPreferencesSettingsRepository : IPreferencesSettingsRepository {
		public async Task<IEnumerable<Material>> GetMaterialsAsync() {
			// simulate fetching (e.g. from database or web service)
			await Task.Delay(300).ConfigureAwait(false);
			return new List<Material>() {
				new Material("Arlon", 8, 0),
				new Material("Nelco", 9.5, 0),
				new Material("Shengyi", 7.2, 0)
			};
		}

		public async Task<IEnumerable<SurfaceFinish>> GetSurfaceFinishesAsync() {
			// simulate fetching (e.g. from database or web service)
			await Task.Delay(300).ConfigureAwait(false);
			return new List<SurfaceFinish>() {
				new SurfaceFinish("ENEPIG", 3.5, 0),
				new SurfaceFinish("ENIG", 2, 0),
				new SurfaceFinish("HASL", 1.0, 0),
				new SurfaceFinish("OSP", 1.2, 0)
			};
		}

		public async Task<IEnumerable<SolderMaskColor>> GetSolderMaskColorsAsync() {
			// simulate fetching (e.g. from database or web service)
			await Task.Delay(300).ConfigureAwait(false);
			return new List<SolderMaskColor>() {
				new SolderMaskColor("Green", 0, 0),
				new SolderMaskColor("Red", 0.2, 0),
				new SolderMaskColor("Blue", 0.2, 0)
			};
		}

		public async Task<IEnumerable<SilkscreenColor>> GetSilkscreenColorsAsync() {
			// simulate fetching (e.g. from database or web service)
			await Task.Delay(300).ConfigureAwait(false);
			return new List<SilkscreenColor>() {
				new SilkscreenColor("White", 0, 0),
				new SilkscreenColor("Yellow", 0.2, 0),
				new SilkscreenColor("Brown", 0.2, 0),
				new SilkscreenColor("Black", 0, 0)
			};
		}

		public async Task<IEnumerable<InnerLayerCopperWeight>> GetInnerLayerCopperWeightsAsync() {
			// simulate fetching (e.g. from database or web service)
			await Task.Delay(300).ConfigureAwait(false);
			return new List<InnerLayerCopperWeight>() {
				new InnerLayerCopperWeight("0.5oz", 0, 0),
				new InnerLayerCopperWeight("1.0oz", 1, 0),
				new InnerLayerCopperWeight("2.0oz", 2, 0),
				new InnerLayerCopperWeight("3.0oz", 4, 0)
			};
		}

		public async Task<IEnumerable<OuterLayerCopperWeight>> GetOuterLayerCopperWeightsAsync() {
			// simulate fetching (e.g. from database or web service)
			await Task.Delay(300).ConfigureAwait(false);
			return new List<OuterLayerCopperWeight>() {
				new OuterLayerCopperWeight("0.5oz", 0, 0),
				new OuterLayerCopperWeight("1.0oz", 0.5, 0),
				new OuterLayerCopperWeight("1.5oz", 1, 0),
				new OuterLayerCopperWeight("2.0oz", 1.5, 0)
			};
		}

		public async Task<IEnumerable<LeadFreeOption>> GetLeadFreeOptionsAsync() {
			// simulate fetching (e.g. from database or web service)
			await Task.Delay(300).ConfigureAwait(false);
			return new List<LeadFreeOption>() {
				new LeadFreeOption("No", 0, 0),
				new LeadFreeOption("Yes", 1.3, 0)
			};
		}

		public async Task<IEnumerable<IpcClass>> GetIpcClassesAsync() {
			// simulate fetching (e.g. from database or web service)
			await Task.Delay(300).ConfigureAwait(false);
			return new List<IpcClass>() {
				new IpcClass("Class 2", 0, 0),
				new IpcClass("Class 3", 2.5, 0)
			};
		}

		public async Task<IEnumerable<ItarComplianceOption>> GetItarComplianceOptionsAsync() {
			// simulate fetching (e.g. from database or web service)
			await Task.Delay(300).ConfigureAwait(false);
			return new List<ItarComplianceOption>() {
				new ItarComplianceOption("No", 0, 0),
				new ItarComplianceOption("Yes", 1, 0)
			};
		}

		public async Task<IEnumerable<FluxType>> GetFluxTypesAsync() {
			// simulate fetching (e.g. from database or web service)
			await Task.Delay(300).ConfigureAwait(false);
			return new List<FluxType>() {
				new FluxType("Clean", 1.5, 0),
				new FluxType("No Clean", 0, 0)
			};
		}

		public async Task<IEnumerable<ControlledImpedance>> GetControlledImpedanceOptionsAsync() {
			// simulate fetching (e.g. from database or web service)
			await Task.Delay(300).ConfigureAwait(false);
			return new List<ControlledImpedance>() {
				new ControlledImpedance("None", 0, 0),
				new ControlledImpedance("See Notes", 0, 0)
			};
		}

		public async Task<IEnumerable<TentingForViasOption>> GetTentingForViasOptionsAsync() {
			// simulate fetching (e.g. from database or web service)
			await Task.Delay(300).ConfigureAwait(false);
			return new List<TentingForViasOption>() {
				new TentingForViasOption("None", 0, 0),
				new TentingForViasOption("Top Side", 1.4, 0),
				new TentingForViasOption("Bottom Side", 1.4, 0),
				new TentingForViasOption("Both Sides", 2.6, 0)
			};
		}

		public async Task<IEnumerable<StackupOption>> GetStackupOptionsAsync() {
			// simulate fetching (e.g. from database or web service)
			await Task.Delay(300).ConfigureAwait(false);
			return new List<StackupOption>() {
				new StackupOption("None", 0, 0),
				new StackupOption("See Notes", 0, 0)
			};
		}
	}
}
