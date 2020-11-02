using BoardOrder.Domain;
using System.Collections.Generic;
using System.Windows.Media;

namespace BoardOrder.DataAccess {
	public class PredefinedPreferencesSettingsRepository : IPreferencesSettingsRepository {
		public IEnumerable<BoardOrderItem> GetMaterials() {
			return new List<BoardOrderItem>() {
				new BoardOrderItem("Arlon", 8, 0),
				new BoardOrderItem("Nelco", 9.5, 0),
				new BoardOrderItem("Shengyi", 7.2, 0)
			};
		}

		public IEnumerable<BoardOrderItem> GetSurfaceFinishes() {
			return new List<BoardOrderItem>() {
				new BoardOrderItem("ENEPIG", 3.5, 0),
				new BoardOrderItem("ENIG", 2, 0),
				new BoardOrderItem("HASL", 1.0, 0),
				new BoardOrderItem("OSP", 1.2, 0)
			};
		}

		public IEnumerable<ColorBoardOrderItem> GetSolderMaskColors() {
			return new List<ColorBoardOrderItem>() {
				new ColorBoardOrderItem(Colors.Green,"Green", 0, 0),
				new ColorBoardOrderItem(Colors.Red, "Red", 0.2, 0),
				new ColorBoardOrderItem(Colors.Blue, "Blue", 0.2, 0)
			};
		}

		public IEnumerable<ColorBoardOrderItem> GetSilkscreenColors() {
			return new List<ColorBoardOrderItem>() {
				new ColorBoardOrderItem(Colors.White, "White", 0, 0),
				new ColorBoardOrderItem(Colors.Yellow, "Yellow", 0.2, 0),
				new ColorBoardOrderItem(Colors.Brown, "Brown", 0.2, 0),
				new ColorBoardOrderItem(Colors.Brown, "Black", 0, 0)
			};
		}

		public IEnumerable<BoardOrderItem> GetInnerLayerCopperWeights() {
			return new List<BoardOrderItem>() {
				new BoardOrderItem("0.5oz", 0, 0),
				new BoardOrderItem("1.0oz", 1, 0),
				new BoardOrderItem("2.0oz", 2, 0),
				new BoardOrderItem("3.0oz", 4, 0)
			};
		}

		public IEnumerable<BoardOrderItem> GetOuterLayerCopperWeights() {
			return new List<BoardOrderItem>() {
				new BoardOrderItem("0.5oz", 0, 0),
				new BoardOrderItem("1.0oz", 0.5, 0),
				new BoardOrderItem("1.5oz", 1, 0),
				new BoardOrderItem("2.0oz", 1.5, 0)
			};
		}

		public IEnumerable<BoardOrderItem> GetLeadFreeOptions() {
			return new List<BoardOrderItem>() {
				new BoardOrderItem("No", 0, 0),
				new BoardOrderItem("Yes", 1.3, 0)
			};
		}

		public IEnumerable<BoardOrderItem> GetIpcClasses() {
			return new List<BoardOrderItem>() {
				new BoardOrderItem("Class 2", 0, 0),
				new BoardOrderItem("Class 3", 2.5, 0)
			};
		}

		public IEnumerable<BoardOrderItem> GetItarComplianceOptions() {
			return new List<BoardOrderItem>() {
				new BoardOrderItem("No", 0, 0),
				new BoardOrderItem("Yes", 1, 0)
			};
		}

		public IEnumerable<BoardOrderItem> GetFluxTypes() {
			return new List<BoardOrderItem>() {
				new BoardOrderItem("Clean", 1.5, 0),
				new BoardOrderItem("No Clean", 0, 0)
			};
		}

		public IEnumerable<BoardOrderItem> GetControlledImpedanceOptions() {
			return new List<BoardOrderItem>() {
				new BoardOrderItem("None", 0, 0),
				new BoardOrderItem("See Notes", 0, 0)
			};
		}

		public IEnumerable<BoardOrderItem> GetTentingForViasOptions() {
			return new List<BoardOrderItem>() {
				new BoardOrderItem("None", 0, 0),
				new BoardOrderItem("Top Side", 1.4, 0),
				new BoardOrderItem("Bottom Side", 1.4, 0),
				new BoardOrderItem("Both Sides", 2.6, 0)
			};
		}

		public IEnumerable<BoardOrderItem> GetStackupOptions() {
			return new List<BoardOrderItem>() {
				new BoardOrderItem("None", 0, 0),
				new BoardOrderItem("See Notes", 0, 0)
			};
		}
	}
}
