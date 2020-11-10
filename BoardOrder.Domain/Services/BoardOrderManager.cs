using BoardOrder.Domain.Models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace BoardOrder.Domain.Services {
	public class BoardOrderManager : IBoardOrderManager {
		private readonly IPreferencesOptions preferenceOptions;
		private readonly IQuoteService quoteService;

		public BoardOrderManager(IPreferencesOptions options, IQuoteService quoteService) {
			this.preferenceOptions = options;
			this.quoteService = quoteService;
		}

		public event PropertyChangedEventHandler OrderModified;

		public event Action OrderReset;

		public bool IsOrderValid => string.IsNullOrEmpty(this.CurrentOrder?.Error);

		public BoardOrderDetails CurrentOrder { get; private set; }

		public ObservableCollection<BoardOrderItem> Quote => this.CurrentOrder?.Quote;

		public int BoardsQuantity => this.CurrentOrder?.BoardsQuantity ?? 1;

		public bool IsQuoteAvailable => this.CurrentOrder?.Quote != null;

		public void ResetOrder() {
			var order = new BoardOrderDetails() {
				ProjectName = string.Empty,
				Zipcode = string.Empty,
				BoardsQuantity = 1,
				BoardThickness = 1.0,
				SelectedMaterial = this.preferenceOptions.Materials.FirstOrDefault(),
				SelectedSurfaceFinish = this.preferenceOptions.SurfaceFinishes.FirstOrDefault(),
				SelectedMaskColor = this.preferenceOptions.SolderMaskColors.FirstOrDefault(),
				SelectedSilkscreenColor = this.preferenceOptions.SilkscreenColors.FirstOrDefault(),
				SelectedInnerLayersCopperWeight = this.preferenceOptions.InnerLayersCopperWeights.FirstOrDefault(),
				SelectedOuterLayersCopperWeight = this.preferenceOptions.OuterLayersCopperWeights.FirstOrDefault(),
				SelectedLeadFreeOption = this.preferenceOptions.LeadFreeOptions.FirstOrDefault(),
				SelectedIPCClass = this.preferenceOptions.IpcClasses.FirstOrDefault(),
				SelectedITARComplianceOption = this.preferenceOptions.ItarComplianceOptions.FirstOrDefault(),
				SelectedFluxType = this.preferenceOptions.FluxTypes.FirstOrDefault(),
				SelectedControlledImpedanceOption = this.preferenceOptions.ControlledImpedanceOptions.FirstOrDefault(),
				SelectedTentingForViasOption = this.preferenceOptions.TentingForViasOptions.FirstOrDefault(),
				SelectedStackup = this.preferenceOptions.StackupOptions.FirstOrDefault(),
			};
			this.SetCurrentOrder(order);
			this.CurrentOrder.Quote = null;
			this.OrderReset?.Invoke();
		}


		public async Task<bool> SaveOrder() {
			if (!IsOrderValid) {
				return false;
			}

			var baseCosts = await this.quoteService.LoadBaseCosts();
			var preferencesQuote = await this.quoteService.ExtractQuote(this.CurrentOrder).ConfigureAwait(false);

			var quote = baseCosts.Concat(preferencesQuote);
			this.CurrentOrder.Quote = new ObservableCollection<BoardOrderItem>(quote);
			return true;
		}

		private void SetCurrentOrder(BoardOrderDetails orderDetails) {
			if (this.CurrentOrder != null) {
				this.CurrentOrder.PropertyChanged -= HandleCurrentOrderPropertyChanged;	
			}

			this.CurrentOrder = orderDetails;
			this.CurrentOrder.PropertyChanged += HandleCurrentOrderPropertyChanged;
			this.OrderModified?.Invoke(this, new PropertyChangedEventArgs(nameof(BoardOrderDetails.Error)));
		}

		private void HandleCurrentOrderPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e) {
			this.OrderModified?.Invoke(this, e);
		}

		public async Task<PlacedOrderItem> PlaceOrder() {
			var placedOrder = new PlacedOrderItem() {
				ProjectName = this.CurrentOrder.ProjectName,
				TotalCost = this.quoteService.CalculateSumCost(this.Quote, this.BoardsQuantity),
				TotalTime = this.quoteService.CalculateSumTime(this.Quote, this.BoardsQuantity),
				CurrentStatus = "Pending..."
			};

			// Simulate contacting server
			await Task.Delay(300).ConfigureAwait(false);

			ResetOrder();

			return placedOrder;
		}
	}
}
