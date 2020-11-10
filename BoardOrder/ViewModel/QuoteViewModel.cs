using BoardOrder.Common.Messages;
using BoardOrder.Domain.Models;
using BoardOrder.Domain.Services;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Management.Instrumentation;
using System.Threading.Tasks;
using System.Windows.Data;

namespace BoardOrder.ViewModel {
	public class QuoteViewModel : ViewModelBase {
		private readonly IQuoteManager quoteOrderManager;

		private ObservableCollection<CostsSummaryItemViewModel> costsSummaryItems;
		private ICollectionView quoteFabricationView;
		private ICollectionView quoteAssemblyView;
		private ICollectionView quoteComponentsView;
		private ObservableCollection<BoardOrderItem> quote;
		private bool isTimeSummaryVisible;
		private bool isCostSummaryVisible;

		public QuoteViewModel(IQuoteManager quoteOrderManager) {
			this.quoteOrderManager = quoteOrderManager;
			this.quoteOrderManager.OrderModified += HandleOrderModified;

			this.MessengerInstance.Register<OrderDetailsSaved>(this, this.HandleOrderDetailsSaved);
		}

		private void HandleOrderModified(object sender, System.ComponentModel.PropertyChangedEventArgs e) {
			RaisePropertyChanged(nameof(this.BoardsQuantity));
			RaiseCostsChanged();
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
				SetSorting();
			}
		}

		public bool IsCostSummaryVisible {
			get => this.isCostSummaryVisible;
			set {
				this.Set(nameof(this.IsCostSummaryVisible), ref this.isCostSummaryVisible, value);
				this.isTimeSummaryVisible = !value;
				RaisePropertyChanged(nameof(this.IsTimeSummaryVisible));
				SetSorting();
			}
		}

		public ICollectionView QuoteFabricationView {
			get => this.quoteFabricationView;
			set {
				this.Set(nameof(this.QuoteFabricationView), ref this.quoteFabricationView, value);
			}
		}

		public ICollectionView QuoteAssemblyView {
			get => this.quoteAssemblyView;
			set {
				this.Set(nameof(this.QuoteAssemblyView), ref this.quoteAssemblyView, value);
			}
		}

		public ICollectionView QuoteComponentsView {
			get => this.quoteComponentsView;
			set {
				this.Set(nameof(this.QuoteComponentsView), ref this.quoteComponentsView, value);
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
			this.Quote.CollectionChanged += this.HandleQuoteChanged;
			this.QuoteFabricationView = (new CollectionViewSource() { Source = this.CostsSummaryItems }).View;
			this.QuoteAssemblyView = (new CollectionViewSource() { Source = this.CostsSummaryItems }).View;
			this.QuoteComponentsView = (new CollectionViewSource() { Source = this.CostsSummaryItems }).View;
			this.SetSorting();
			this.SetFilters();
			this.IsCostSummaryVisible = true;
			this.RaiseCostsChanged();
		}

		private CostsSummaryItemViewModel CreateSummaryItem(BoardOrderItem item) {
			return item == null ? null : new CostsSummaryItemViewModel() {
				Item = item,
				TotalCost = CalculateSumCost(this.Quote.Where(i => i.CostType == item.CostType)),
				TotalTime = CalculateSumTime(this.Quote.Where(i => i.CostType == item.CostType)),
				BoardsQuantity = this.BoardsQuantity
			};
		}

		private void HandleQuoteChanged(object sender, NotifyCollectionChangedEventArgs e) {
			switch (e.Action) {
				case NotifyCollectionChangedAction.Add:
					this.CostsSummaryItems.Add(CreateSummaryItem(e.NewItems[0] as BoardOrderItem));
					break;
				case NotifyCollectionChangedAction.Remove:
					var itemToRemove = this.CostsSummaryItems.FirstOrDefault(i => i.Item == e.OldItems[0]);
					this.CostsSummaryItems.Remove(itemToRemove);
					break;
				case NotifyCollectionChangedAction.Replace:
					var itemToReplace = this.CostsSummaryItems.FirstOrDefault(i => i.Item == e.OldItems[0]);
					var index = this.CostsSummaryItems.IndexOf(itemToReplace);
					this.CostsSummaryItems[index] = CreateSummaryItem(e.NewItems[0] as BoardOrderItem);
					break;
				case NotifyCollectionChangedAction.Reset:
					this.CostsSummaryItems = new ObservableCollection<CostsSummaryItemViewModel>(this.Quote.Select(item => CreateSummaryItem(item)));
					break;
			}

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

		private void SetSorting() {
			var fabSortDesc = new SortDescription(IsTimeSummaryVisible ?
				nameof(CostsSummaryItemViewModel.PercentageTime) : nameof(CostsSummaryItemViewModel.PercentageCost), ListSortDirection.Descending);

			var assemblySortDesc = new SortDescription(IsTimeSummaryVisible ?
					nameof(CostsSummaryItemViewModel.PercentageTime) : nameof(CostsSummaryItemViewModel.PercentageCost), ListSortDirection.Descending);

			var comSortDesc = new SortDescription(IsTimeSummaryVisible ?
				nameof(CostsSummaryItemViewModel.PercentageTime) : nameof(CostsSummaryItemViewModel.PercentageCost), ListSortDirection.Descending);

			if (this.QuoteFabricationView.SortDescriptions.Count == 0) {
				this.QuoteFabricationView.SortDescriptions.Add(fabSortDesc);
			}
			else {
				this.QuoteFabricationView.SortDescriptions[0] = fabSortDesc;
			}

			if (this.QuoteAssemblyView.SortDescriptions.Count == 0) {
				this.QuoteAssemblyView.SortDescriptions.Add(assemblySortDesc);
			}
			else {
				this.QuoteAssemblyView.SortDescriptions[0] = assemblySortDesc;
			}

			if (this.QuoteComponentsView.SortDescriptions.Count == 0) {
				this.QuoteComponentsView.SortDescriptions.Add(comSortDesc);
			}
			else {
				this.QuoteComponentsView.SortDescriptions[0] = comSortDesc;
			}

			//this.QuoteFabricationView.Refresh();
			//this.QuoteAssemblyView.Refresh();
			//this.QuoteComponentsView.Refresh();
		}

		private void SetFilters() {
			this.QuoteFabricationView.Filter = item => item is CostsSummaryItemViewModel summary && summary.Item.CostType == CostType.Fabrication;
			this.QuoteAssemblyView.Filter = item => item is CostsSummaryItemViewModel summary && summary.Item.CostType == CostType.Assembly;
			this.QuoteComponentsView.Filter = item => item is CostsSummaryItemViewModel summary && summary.Item.CostType == CostType.Parts;

			this.QuoteFabricationView.Refresh();
			this.QuoteAssemblyView.Refresh();
			this.QuoteComponentsView.Refresh();
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
