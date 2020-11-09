using BoardOrder.Common.Messages;
using BoardOrder.Domain.Models;
using BoardOrder.Domain.Services;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace BoardOrder.ViewModel {
	public class QuoteViewModel : ViewModelBase {
		private readonly IQuoteManager quoteOrderManager;

		private ObservableCollection<CostsSummaryItemViewModel> costsSummaryItems;
		private ObservableCollection<BoardOrderItem> quote;
		private bool isTimeSummaryVisible;
		private bool isCostSummaryVisible;

		public QuoteViewModel(IQuoteManager quoteOrderManager) {
			this.quoteOrderManager = quoteOrderManager;

			this.MessengerInstance.Register<OrderDetailsSaved>(this, this.HandleOrderDetailsSaved);
		}

		public ObservableCollection<CostsSummaryItemViewModel> CostsSummaryItems {
			get => this.costsSummaryItems;
			set => this.Set(nameof(this.CostsSummaryItems), ref this.costsSummaryItems, value);
		}

		public ObservableCollection<BoardOrderItem> Quote {
			get => this.quote;
			set => this.Set(nameof(this.Quote), ref this.quote, value);
		}
		
		public bool IsTimeSummaryVisible {
			get => this.isTimeSummaryVisible;
			set {
				this.Set(nameof(this.IsTimeSummaryVisible), ref this.isTimeSummaryVisible, value);
				this.isCostSummaryVisible = !value;
				RaisePropertyChanged(nameof(this.IsCostSummaryVisible));
			}
		}

		public bool IsCostSummaryVisible {
			get => this.isCostSummaryVisible;
			set {
				this.Set(nameof(this.IsCostSummaryVisible), ref this.isCostSummaryVisible, value);
				this.isTimeSummaryVisible = !value;
				RaisePropertyChanged(nameof(this.IsTimeSummaryVisible));
			}
		}

		public int BoardsQuantity => this.quoteOrderManager.BoardsQuantity;

		public double TotalCost => this.CalculateSumCost(this.quote);

		public double TotalTime => this.CalculateSumTime(this.quote);

		public double PercentageFabricationCost => this.CalculatePercentage(this.FabricationCost, this.TotalCost);

		public double PercentageAssemblyCost => this.CalculatePercentage(this.AssemblyCost, this.TotalCost);

		public double PercentageComponentsCost => this.CalculatePercentage(this.ComponentsCost, this.TotalCost);

		public double PercentageFabricationTime => this.CalculatePercentage(this.FabricationTime, this.TotalTime);

		public double PercentageAssemblyTime => this.CalculatePercentage(this.AssemblyTime, this.TotalTime);

		public double PercentageComponentsTime => this.CalculatePercentage(this.ComponentsTime, this.TotalTime);

		public double FabricationCost => this.CalculateSumCost(this.quote?.Where(item => item.CostType == CostType.Fabrication));

		public double AssemblyCost => this.CalculateSumCost(this.quote?.Where(item => item.CostType == CostType.Assembly));

		public double ComponentsCost => this.CalculateSumCost(this.quote?.Where(item => item.CostType == CostType.Parts));

		public double FabricationTime => this.CalculateSumTime(this.quote?.Where(item => item.CostType == CostType.Fabrication));

		public double AssemblyTime => this.CalculateSumTime(this.quote?.Where(item => item.CostType == CostType.Assembly));

		public double ComponentsTime => this.CalculateSumTime(this.quote?.Where(item => item.CostType == CostType.Parts));

		public override void Cleanup() {
			this.MessengerInstance.Unregister<OrderDetailsSaved>(this, this.HandleOrderDetailsSaved);
			base.Cleanup();
		}

		private void HandleOrderDetailsSaved(OrderDetailsSaved message) {
			this.SetOrder(this.quoteOrderManager.Quote);
		}

		public void SetOrder(ObservableCollection<BoardOrderItem> value) {
			this.Quote = value;
			this.CostsSummaryItems = new ObservableCollection<CostsSummaryItemViewModel>(value.Select(item => CreateSummaryItem(item)));
			this.quote.CollectionChanged += this.HandleQuoteChanged;
			this.IsCostSummaryVisible = true;
			this.RaiseCostsChanged();
		}

		private CostsSummaryItemViewModel CreateSummaryItem(BoardOrderItem item) {
			return new CostsSummaryItemViewModel() {
				Item = item,
				TotalCost = CalculateSumCost(this.Quote.Where(i => i.CostType == item.CostType)),
				TotalTime = CalculateSumTime(this.Quote.Where(i => i.CostType == item.CostType)),
				BoardsQuantity = this.BoardsQuantity
			};
		}

		private void HandleQuoteChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) {

			this.RaiseCostsChanged();
		}

		private int CalculatePercentage(double sum, double total) {
			return (int)(sum / total * 100);
		}

		private double CalculateSumCost(IEnumerable<BoardOrderItem> items) {
			return items?.Sum(item => item.CostModifier * this.quoteOrderManager.BoardsQuantity) ?? 0;
		}

		private double CalculateSumTime(IEnumerable<BoardOrderItem> items) {
			return Math.Round(items?.Sum(item => item.WorkdaysModifier * this.quoteOrderManager.BoardsQuantity) ?? 0);
		}

		private void RaiseCostsChanged() {
			RaisePropertyChanged(nameof(this.TotalTime));
			RaisePropertyChanged(nameof(this.TotalCost));

			RaisePropertyChanged(nameof(this.PercentageFabricationCost));
			RaisePropertyChanged(nameof(this.PercentageAssemblyCost));
			RaisePropertyChanged(nameof(this.PercentageComponentsCost));
			RaisePropertyChanged(nameof(this.PercentageFabricationTime));
			RaisePropertyChanged(nameof(this.PercentageAssemblyTime));
			RaisePropertyChanged(nameof(this.PercentageComponentsTime));

			RaisePropertyChanged(nameof(this.FabricationCost));
			RaisePropertyChanged(nameof(this.AssemblyCost));
			RaisePropertyChanged(nameof(this.ComponentsCost));
			RaisePropertyChanged(nameof(this.FabricationTime));
			RaisePropertyChanged(nameof(this.AssemblyTime));
			RaisePropertyChanged(nameof(this.ComponentsTime));
		}
	}
}
