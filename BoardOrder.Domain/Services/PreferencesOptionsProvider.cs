using BoardOrder.Common.Messages;
using BoardOrder.Domain.DataAccess;
using BoardOrder.Domain.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace BoardOrder.Domain.Services {
	public class PreferencesOptionsProvider : ObservableObject, IOptionsProvider {
		private readonly IPreferencesSettingsRepository preferencesSettingsRepository;

		private readonly IMessenger messenger;

		private IEnumerable<BoardOrderItem> materials;

		private IEnumerable<BoardOrderItem> surfaceFinishes;

		private IEnumerable<ColorBoardOrderItem> solderMaskColors;

		private IEnumerable<ColorBoardOrderItem> silkscreenColors;

		private IEnumerable<BoardOrderItem> innerLayersCopperWeights;

		private IEnumerable<BoardOrderItem> outerLayersCopperWeights;

		private IEnumerable<BoardOrderItem> leadFreeOptions;

		private IEnumerable<BoardOrderItem> ipcClasses;

		private IEnumerable<BoardOrderItem> itarComplianceOptions;

		private IEnumerable<BoardOrderItem> fluxTypes;

		private IEnumerable<BoardOrderItem> controlledImpedanceOptions;

		private IEnumerable<BoardOrderItem> tentingForViasOptions;

		private IEnumerable<BoardOrderItem> stackupOptions;

		public PreferencesOptionsProvider(
			IPreferencesSettingsRepository preferencesSettingsRepository,
			IMessenger messenger) {
			this.preferencesSettingsRepository = preferencesSettingsRepository;
			this.messenger = messenger;
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
			this.messenger.Send(new LoadingFinishedMessage());
		}

		public IEnumerable<BoardOrderItem> Materials {
			get => this.materials;
			set => this.Set(ref this.materials, value);
		}

		public IEnumerable<BoardOrderItem> SurfaceFinishes {
			get => this.surfaceFinishes;
			set => this.Set(ref this.surfaceFinishes, value);
		}

		public IEnumerable<ColorBoardOrderItem> SolderMaskColors {
			get => this.solderMaskColors;
			set => this.Set(ref this.solderMaskColors, value);
		}

		public IEnumerable<ColorBoardOrderItem> SilkscreenColors {
			get => this.silkscreenColors;
			set => this.Set(ref this.silkscreenColors, value);
		}

		public IEnumerable<BoardOrderItem> InnerLayersCopperWeights {
			get => this.innerLayersCopperWeights;
			set => this.Set(ref this.innerLayersCopperWeights, value);
		}

		public IEnumerable<BoardOrderItem> OuterLayersCopperWeights {
			get => this.outerLayersCopperWeights;
			set => this.Set(ref this.outerLayersCopperWeights, value);
		}

		public IEnumerable<BoardOrderItem> LeadFreeOptions {
			get => this.leadFreeOptions;
			set => this.Set(ref this.leadFreeOptions, value);
		}

		public IEnumerable<BoardOrderItem> IpcClasses {
			get => this.ipcClasses;
			set => this.Set(ref this.ipcClasses, value);
		}

		public IEnumerable<BoardOrderItem> ItarComplianceOptions {
			get => this.itarComplianceOptions;
			set => this.Set(ref this.itarComplianceOptions, value);
		}

		public IEnumerable<BoardOrderItem> FluxTypes {
			get => this.fluxTypes;
			set => this.Set(ref this.fluxTypes, value);
		}

		public IEnumerable<BoardOrderItem> ControlledImpedanceOptions {
			get => this.controlledImpedanceOptions;
			set => this.Set(ref this.controlledImpedanceOptions, value);
		}

		public IEnumerable<BoardOrderItem> TentingForViasOptions {
			get => this.tentingForViasOptions;
			set => this.Set(ref this.tentingForViasOptions, value);
		}

		public IEnumerable<BoardOrderItem> StackupOptions {
			get => this.stackupOptions;
			set => this.Set(ref this.stackupOptions, value);
		}

		private async Task FetchOptionAsync(string optionName, Func<Task> fetchingFunc) {
			const string fetchingMessageFormat = "Loading {0}...";
			this.messenger.Send(new LoadingInitializedMessage(string.Format(fetchingMessageFormat, optionName)));
			await fetchingFunc();
		}
	}
}
