using BoardOrder.Domain;
using System.Collections.Generic;
using System.Windows.Media;

namespace BoardOrder.DataAccess {
	public class PredefinedPreferencesSettingsRepository : IPredefinedPreferencesSettingsRepository {
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
	}
}
