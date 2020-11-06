using BoardOrder.Domain.DataAccess;
using BoardOrder.Domain.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BoardOrder.Domain.Services {
	public class PreferencesOptionsProvider : ObservableObject, IOptionsProvider, IPreferencesOptions {
		private readonly IPreferencesSettingsRepository preferencesSettingsRepository;

		private IEnumerable<Material> materials;

		private IEnumerable<SurfaceFinish> surfaceFinishes;

		private IEnumerable<SolderMaskColor> solderMaskColors;

		private IEnumerable<SilkscreenColor> silkscreenColors;

		private IEnumerable<InnerLayerCopperWeight> innerLayersCopperWeights;

		private IEnumerable<OuterLayerCopperWeight> outerLayersCopperWeights;

		private IEnumerable<LeadFreeOption> leadFreeOptions;

		private IEnumerable<IpcClass> ipcClasses;

		private IEnumerable<ItarComplianceOption> itarComplianceOptions;

		private IEnumerable<FluxType> fluxTypes;

		private IEnumerable<ControlledImpedance> controlledImpedanceOptions;

		private IEnumerable<TentingForViasOption> tentingForViasOptions;

		private IEnumerable<StackupOption> stackupOptions;

		public event Action<string> Fetching;

		public PreferencesOptionsProvider(
			IPreferencesSettingsRepository preferencesSettingsRepository) {
			this.preferencesSettingsRepository = preferencesSettingsRepository;
		}

		public async Task FetchOptions() {
			await this.FetchOptionAsync("Materials", async () => this.Materials = await this.preferencesSettingsRepository.GetMaterialsAsync());
			await this.FetchOptionAsync("Surface Finishes", async () => this.SurfaceFinishes = await this.preferencesSettingsRepository.GetSurfaceFinishesAsync());
			await this.FetchOptionAsync("Solder Mask Colors", async () => this.SolderMaskColors = await this.preferencesSettingsRepository.GetSolderMaskColorsAsync());
			await this.FetchOptionAsync("Silkscreen Colors", async () => this.SilkscreenColors = await this.preferencesSettingsRepository.GetSilkscreenColorsAsync());
			await this.FetchOptionAsync("Inner Layers Copper Weight Options", async () => this.InnerLayersCopperWeights = await this.preferencesSettingsRepository.GetInnerLayerCopperWeightsAsync());
			await this.FetchOptionAsync("Outer Layers Copper Weight Options", async () => this.OuterLayersCopperWeights = await this.preferencesSettingsRepository.GetOuterLayerCopperWeightsAsync());
			await this.FetchOptionAsync("Lead Free Options", async () => this.LeadFreeOptions = await this.preferencesSettingsRepository.GetLeadFreeOptionsAsync());
			await this.FetchOptionAsync("Ipc Classes", async () => this.IpcClasses = await this.preferencesSettingsRepository.GetIpcClassesAsync());
			await this.FetchOptionAsync("Itar Compliance Options", async () => this.ItarComplianceOptions = await this.preferencesSettingsRepository.GetItarComplianceOptionsAsync());
			await this.FetchOptionAsync("Flux Types", async () => this.FluxTypes = await this.preferencesSettingsRepository.GetFluxTypesAsync());
			await this.FetchOptionAsync("Controlled Impedance Options", async () => this.ControlledImpedanceOptions = await this.preferencesSettingsRepository.GetControlledImpedanceOptionsAsync());
			await this.FetchOptionAsync("Tenting For Vias Options", async () => this.TentingForViasOptions = await this.preferencesSettingsRepository.GetTentingForViasOptionsAsync());
			await this.FetchOptionAsync("Stackup Options", async () => this.StackupOptions = await this.preferencesSettingsRepository.GetStackupOptionsAsync());
		}

		public IEnumerable<Material> Materials {
			get => this.materials;
			set => this.Set(ref this.materials, value);
		}

		public IEnumerable<SurfaceFinish> SurfaceFinishes {
			get => this.surfaceFinishes;
			set => this.Set(ref this.surfaceFinishes, value);
		}

		public IEnumerable<SolderMaskColor> SolderMaskColors {
			get => this.solderMaskColors;
			set => this.Set(ref this.solderMaskColors, value);
		}

		public IEnumerable<SilkscreenColor> SilkscreenColors {
			get => this.silkscreenColors;
			set => this.Set(ref this.silkscreenColors, value);
		}

		public IEnumerable<InnerLayerCopperWeight> InnerLayersCopperWeights {
			get => this.innerLayersCopperWeights;
			set => this.Set(ref this.innerLayersCopperWeights, value);
		}

		public IEnumerable<OuterLayerCopperWeight> OuterLayersCopperWeights {
			get => this.outerLayersCopperWeights;
			set => this.Set(ref this.outerLayersCopperWeights, value);
		}

		public IEnumerable<LeadFreeOption> LeadFreeOptions {
			get => this.leadFreeOptions;
			set => this.Set(ref this.leadFreeOptions, value);
		}

		public IEnumerable<IpcClass> IpcClasses {
			get => this.ipcClasses;
			set => this.Set(ref this.ipcClasses, value);
		}

		public IEnumerable<ItarComplianceOption> ItarComplianceOptions {
			get => this.itarComplianceOptions;
			set => this.Set(ref this.itarComplianceOptions, value);
		}

		public IEnumerable<FluxType> FluxTypes {
			get => this.fluxTypes;
			set => this.Set(ref this.fluxTypes, value);
		}

		public IEnumerable<ControlledImpedance> ControlledImpedanceOptions {
			get => this.controlledImpedanceOptions;
			set => this.Set(ref this.controlledImpedanceOptions, value);
		}

		public IEnumerable<TentingForViasOption> TentingForViasOptions {
			get => this.tentingForViasOptions;
			set => this.Set(ref this.tentingForViasOptions, value);
		}

		public IEnumerable<StackupOption> StackupOptions {
			get => this.stackupOptions;
			set => this.Set(ref this.stackupOptions, value);
		}

		private async Task FetchOptionAsync(string optionName, Func<Task> fetchingFunc) {
			const string fetchingMessageFormat = "Loading {0}...";
			this.Fetching?.Invoke(string.Format(fetchingMessageFormat, optionName));
			await fetchingFunc();
		}
	}
}
