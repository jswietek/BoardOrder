using BoardOrder.Domain.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace BoardOrder.Domain.Services {
	public class BoardOrderManager : IBoardOrderManager, IQuoteManager {
		private readonly IPreferencesOptions preferenceOptions;
		private readonly IQuoteService quoteService;
		private BoardOrderDetails currentOrder;

		public BoardOrderManager(IPreferencesOptions options, IQuoteService quoteService) {
			this.preferenceOptions = options;
			this.quoteService = quoteService;
		}

		public event PropertyChangedEventHandler OrderModified;

		public bool IsOrderValid => string.IsNullOrEmpty(this.currentOrder?.Error);

		public BoardOrderDetails CurrentOrder => this.currentOrder;
		public ObservableCollection<BoardOrderItem> Quote => this.currentOrder.Quote;

		public BoardOrderDetails ResetOrder() {
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
			return order;
		}


		public bool SaveOrder() {
			if (!IsOrderValid) {
				return false;
			}

			this.currentOrder.Quote = new ObservableCollection<BoardOrderItem>(this.quoteService.ExtractQuote(this.currentOrder));
			return true;
		}

		private void SetCurrentOrder(BoardOrderDetails orderDetails) {
			if (this.currentOrder != null) {
				this.currentOrder.PropertyChanged -= HandleCurrentOrderPropertyChanged;
			}
			this.currentOrder = orderDetails;
			this.currentOrder.PropertyChanged += HandleCurrentOrderPropertyChanged;
			this.OrderModified?.Invoke(this, new PropertyChangedEventArgs(nameof(BoardOrderDetails.Error)));
		}

		private void HandleCurrentOrderPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e) {
			this.OrderModified?.Invoke(this, e);
		}
	}
}
