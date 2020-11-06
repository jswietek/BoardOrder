using BoardOrder.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BoardOrder.Domain.DataAccess {
	public class PredefinedPreferencesSettingsRepository : IPreferencesSettingsRepository {
		public async Task<IEnumerable<BoardOrderItem>> GetMaterialsAsync() {
			// simulate fetching (e.g. from database or web service)
			await Task.Delay(300).ConfigureAwait(false);
			return new List<BoardOrderItem>() {
				new Material("Arlon", 8, 0),
				new Material("Nelco", 9.5, 0),
				new Material("Shengyi", 7.2, 0)
			};
		}

		public async Task<IEnumerable<BoardOrderItem>> GetSurfaceFinishesAsync() {
			// simulate fetching (e.g. from database or web service)
			await Task.Delay(300).ConfigureAwait(false);
			return new List<BoardOrderItem>() {
				new SurfaceFinish("ENEPIG", 3.5, 0),
				new SurfaceFinish("ENIG", 2, 0),
				new SurfaceFinish("HASL", 1.0, 0),
				new SurfaceFinish("OSP", 1.2, 0)
			};
		}

		public async Task<IEnumerable<BoardOrderItem>> GetSolderMaskColorsAsync() {
			// simulate fetching (e.g. from database or web service)
			await Task.Delay(300).ConfigureAwait(false);
			return new List<BoardOrderItem>() {
				new SolderMaskColor("Green", 0, 0),
				new SolderMaskColor("Red", 0.2, 0),
				new SolderMaskColor("Blue", 0.2, 0)
			};
		}

		public async Task<IEnumerable<BoardOrderItem>> GetSilkscreenColorsAsync() {
			// simulate fetching (e.g. from database or web service)
			await Task.Delay(300).ConfigureAwait(false);
			return new List<BoardOrderItem>() {
				new SilkscreenColor("White", 0, 0),
				new SilkscreenColor("Yellow", 0.2, 0),
				new SilkscreenColor("Brown", 0.2, 0),
				new SilkscreenColor("Black", 0, 0)
			};
		}

		public async Task<IEnumerable<BoardOrderItem>> GetInnerLayerCopperWeightsAsync() {
			// simulate fetching (e.g. from database or web service)
			await Task.Delay(300).ConfigureAwait(false);
			return new List<BoardOrderItem>() {
				new InnerLayerCopperWeight("0.5oz", 0, 0),
				new InnerLayerCopperWeight("1.0oz", 1, 0),
				new InnerLayerCopperWeight("2.0oz", 2, 0),
				new InnerLayerCopperWeight("3.0oz", 4, 0)
			};
		}

		public async Task<IEnumerable<BoardOrderItem>> GetOuterLayerCopperWeightsAsync() {
			// simulate fetching (e.g. from database or web service)
			await Task.Delay(300).ConfigureAwait(false);
			return new List<BoardOrderItem>() {
				new OuterLayerCopperWeight("0.5oz", 0, 0),
				new OuterLayerCopperWeight("1.0oz", 0.5, 0),
				new OuterLayerCopperWeight("1.5oz", 1, 0),
				new OuterLayerCopperWeight("2.0oz", 1.5, 0)
			};
		}

		public async Task<IEnumerable<BoardOrderItem>> GetLeadFreeOptionsAsync() {
			// simulate fetching (e.g. from database or web service)
			await Task.Delay(300).ConfigureAwait(false);
			return new List<BoardOrderItem>() {
				new LeadFreeOption("No", 0, 0),
				new LeadFreeOption("Yes", 1.3, 0)
			};
		}

		public async Task<IEnumerable<BoardOrderItem>> GetIpcClassesAsync() {
			// simulate fetching (e.g. from database or web service)
			await Task.Delay(300).ConfigureAwait(false);
			return new List<BoardOrderItem>() {
				new IpcClass("Class 2", 0, 0),
				new IpcClass("Class 3", 2.5, 0)
			};
		}

		public async Task<IEnumerable<BoardOrderItem>> GetItarComplianceOptionsAsync() {
			// simulate fetching (e.g. from database or web service)
			await Task.Delay(300).ConfigureAwait(false);
			return new List<BoardOrderItem>() {
				new ItarComplianceOption("No", 0, 0),
				new ItarComplianceOption("Yes", 1, 0)
			};
		}

		public async Task<IEnumerable<BoardOrderItem>> GetFluxTypesAsync() {
			// simulate fetching (e.g. from database or web service)
			await Task.Delay(300).ConfigureAwait(false);
			return new List<BoardOrderItem>() {
				new FluxType("Clean", 1.5, 0),
				new FluxType("No Clean", 0, 0)
			};
		}

		public async Task<IEnumerable<BoardOrderItem>> GetControlledImpedanceOptionsAsync() {
			// simulate fetching (e.g. from database or web service)
			await Task.Delay(300).ConfigureAwait(false);
			return new List<BoardOrderItem>() {
				new ControlledImpedance("None", 0, 0),
				new ControlledImpedance("See Notes", 0, 0)
			};
		}

		public async Task<IEnumerable<BoardOrderItem>> GetTentingForViasOptionsAsync() {
			// simulate fetching (e.g. from database or web service)
			await Task.Delay(300).ConfigureAwait(false);
			return new List<BoardOrderItem>() {
				new TentingForViasOption("None", 0, 0),
				new TentingForViasOption("Top Side", 1.4, 0),
				new TentingForViasOption("Bottom Side", 1.4, 0),
				new TentingForViasOption("Both Sides", 2.6, 0)
			};
		}

		public async Task<IEnumerable<BoardOrderItem>> GetStackupOptionsAsync() {
			// simulate fetching (e.g. from database or web service)
			await Task.Delay(300).ConfigureAwait(false);
			return new List<BoardOrderItem>() {
				new StackupOption("None", 0, 0),
				new StackupOption("See Notes", 0, 0)
			};
		}
	}
}
