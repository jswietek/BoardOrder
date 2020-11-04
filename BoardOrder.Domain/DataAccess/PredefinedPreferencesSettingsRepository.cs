using BoardOrder.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Media;

namespace BoardOrder.Domain.DataAccess {
	public class PredefinedPreferencesSettingsRepository : IPreferencesSettingsRepository {
		public async Task<IEnumerable<BoardOrderItem>> GetMaterialsAsync() {
			// simulate fetching (e.g. from database or web service)
			await Task.Delay(300).ConfigureAwait(false);
			return new List<BoardOrderItem>() {
				new BoardOrderItem("Arlon", 8, 0),
				new BoardOrderItem("Nelco", 9.5, 0),
				new BoardOrderItem("Shengyi", 7.2, 0)
			};
		}

		public async Task<IEnumerable<BoardOrderItem>> GetSurfaceFinishesAsync() {
			// simulate fetching (e.g. from database or web service)
			await Task.Delay(300).ConfigureAwait(false);
			return new List<BoardOrderItem>() {
				new BoardOrderItem("ENEPIG", 3.5, 0),
				new BoardOrderItem("ENIG", 2, 0),
				new BoardOrderItem("HASL", 1.0, 0),
				new BoardOrderItem("OSP", 1.2, 0)
			};
		}

		public async Task<IEnumerable<ColorBoardOrderItem>> GetSolderMaskColorsAsync() {
			// simulate fetching (e.g. from database or web service)
			await Task.Delay(300).ConfigureAwait(false);
			return new List<ColorBoardOrderItem>() {
				new ColorBoardOrderItem(Colors.Green,"Green", 0, 0),
				new ColorBoardOrderItem(Colors.Red, "Red", 0.2, 0),
				new ColorBoardOrderItem(Colors.Blue, "Blue", 0.2, 0)
			};
		}

		public async Task<IEnumerable<ColorBoardOrderItem>> GetSilkscreenColorsAsync() {
			// simulate fetching (e.g. from database or web service)
			await Task.Delay(300).ConfigureAwait(false);
			return new List<ColorBoardOrderItem>() {
				new ColorBoardOrderItem(Colors.White, "White", 0, 0),
				new ColorBoardOrderItem(Colors.Yellow, "Yellow", 0.2, 0),
				new ColorBoardOrderItem(Colors.Brown, "Brown", 0.2, 0),
				new ColorBoardOrderItem(Colors.Brown, "Black", 0, 0)
			};
		}

		public async Task<IEnumerable<BoardOrderItem>> GetInnerLayerCopperWeightsAsync() {
			// simulate fetching (e.g. from database or web service)
			await Task.Delay(300).ConfigureAwait(false);
			return new List<BoardOrderItem>() {
				new BoardOrderItem("0.5oz", 0, 0),
				new BoardOrderItem("1.0oz", 1, 0),
				new BoardOrderItem("2.0oz", 2, 0),
				new BoardOrderItem("3.0oz", 4, 0)
			};
		}

		public async Task<IEnumerable<BoardOrderItem>> GetOuterLayerCopperWeightsAsync() {
			// simulate fetching (e.g. from database or web service)
			await Task.Delay(300).ConfigureAwait(false);
			return new List<BoardOrderItem>() {
				new BoardOrderItem("0.5oz", 0, 0),
				new BoardOrderItem("1.0oz", 0.5, 0),
				new BoardOrderItem("1.5oz", 1, 0),
				new BoardOrderItem("2.0oz", 1.5, 0)
			};
		}

		public async Task<IEnumerable<BoardOrderItem>> GetLeadFreeOptionsAsync() {
			// simulate fetching (e.g. from database or web service)
			await Task.Delay(300).ConfigureAwait(false);
			return new List<BoardOrderItem>() {
				new BoardOrderItem("No", 0, 0),
				new BoardOrderItem("Yes", 1.3, 0)
			};
		}

		public async Task<IEnumerable<BoardOrderItem>> GetIpcClassesAsync() {
			// simulate fetching (e.g. from database or web service)
			await Task.Delay(300).ConfigureAwait(false);
			return new List<BoardOrderItem>() {
				new BoardOrderItem("Class 2", 0, 0),
				new BoardOrderItem("Class 3", 2.5, 0)
			};
		}

		public async Task<IEnumerable<BoardOrderItem>> GetItarComplianceOptionsAsync() {
			// simulate fetching (e.g. from database or web service)
			await Task.Delay(300).ConfigureAwait(false);
			return new List<BoardOrderItem>() {
				new BoardOrderItem("No", 0, 0),
				new BoardOrderItem("Yes", 1, 0)
			};
		}

		public async Task<IEnumerable<BoardOrderItem>> GetFluxTypesAsync() {
			// simulate fetching (e.g. from database or web service)
			await Task.Delay(300).ConfigureAwait(false);
			return new List<BoardOrderItem>() {
				new BoardOrderItem("Clean", 1.5, 0),
				new BoardOrderItem("No Clean", 0, 0)
			};
		}

		public async Task<IEnumerable<BoardOrderItem>> GetControlledImpedanceOptionsAsync() {
			// simulate fetching (e.g. from database or web service)
			await Task.Delay(300).ConfigureAwait(false);
			return new List<BoardOrderItem>() {
				new BoardOrderItem("None", 0, 0),
				new BoardOrderItem("See Notes", 0, 0)
			};
		}

		public async Task<IEnumerable<BoardOrderItem>> GetTentingForViasOptionsAsync() {
			// simulate fetching (e.g. from database or web service)
			await Task.Delay(300).ConfigureAwait(false);
			return new List<BoardOrderItem>() {
				new BoardOrderItem("None", 0, 0),
				new BoardOrderItem("Top Side", 1.4, 0),
				new BoardOrderItem("Bottom Side", 1.4, 0),
				new BoardOrderItem("Both Sides", 2.6, 0)
			};
		}

		public async Task<IEnumerable<BoardOrderItem>> GetStackupOptionsAsync() {
			// simulate fetching (e.g. from database or web service)
			await Task.Delay(300).ConfigureAwait(false);
			return new List<BoardOrderItem>() {
				new BoardOrderItem("None", 0, 0),
				new BoardOrderItem("See Notes", 0, 0)
			};
		}
	}
}
