using BoardOrder.Domain.Models;
using System.Collections.Generic;

namespace BoardOrder.Domain.Services {
	public interface IPreferencesOptions {
		IEnumerable<ControlledImpedance> ControlledImpedanceOptions { get; set; }
		IEnumerable<FluxType> FluxTypes { get; set; }
		IEnumerable<InnerLayerCopperWeight> InnerLayersCopperWeights { get; set; }
		IEnumerable<IpcClass> IpcClasses { get; set; }
		IEnumerable<ItarComplianceOption> ItarComplianceOptions { get; set; }
		IEnumerable<LeadFreeOption> LeadFreeOptions { get; set; }
		IEnumerable<Material> Materials { get; set; }
		IEnumerable<OuterLayerCopperWeight> OuterLayersCopperWeights { get; set; }
		IEnumerable<SilkscreenColor> SilkscreenColors { get; set; }
		IEnumerable<SolderMaskColor> SolderMaskColors { get; set; }
		IEnumerable<StackupOption> StackupOptions { get; set; }
		IEnumerable<SurfaceFinish> SurfaceFinishes { get; set; }
		IEnumerable<TentingForViasOption> TentingForViasOptions { get; set; }
	}
}