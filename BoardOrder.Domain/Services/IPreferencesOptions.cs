using BoardOrder.Domain.Models;
using System.Collections.Generic;

namespace BoardOrder.Domain.Services {
	public interface IPreferencesOptions {
		IEnumerable<BoardOrderItem> ControlledImpedanceOptions { get; set; }
		IEnumerable<BoardOrderItem> FluxTypes { get; set; }
		IEnumerable<BoardOrderItem> InnerLayersCopperWeights { get; set; }
		IEnumerable<BoardOrderItem> IpcClasses { get; set; }
		IEnumerable<BoardOrderItem> ItarComplianceOptions { get; set; }
		IEnumerable<BoardOrderItem> LeadFreeOptions { get; set; }
		IEnumerable<BoardOrderItem> Materials { get; set; }
		IEnumerable<BoardOrderItem> OuterLayersCopperWeights { get; set; }
		IEnumerable<ColorBoardOrderItem> SilkscreenColors { get; set; }
		IEnumerable<ColorBoardOrderItem> SolderMaskColors { get; set; }
		IEnumerable<BoardOrderItem> StackupOptions { get; set; }
		IEnumerable<BoardOrderItem> SurfaceFinishes { get; set; }
		IEnumerable<BoardOrderItem> TentingForViasOptions { get; set; }
	}
}