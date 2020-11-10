using BoardOrder.Common.Interfaces;
using BoardOrder.Domain.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace BoardOrder.Common.Controls {
	/// <summary>
	/// Interaction logic for CostTypeSummaryView.xaml
	/// </summary>
	public partial class CostTypeSummaryView : UserControl, INotifyPropertyChanged {
		private CollectionViewSource filteredItemsSource;

		public CostTypeSummaryView() {
			InitializeComponent();
		}

		public event PropertyChangedEventHandler PropertyChanged;

		public string Header {
			get { return (string)GetValue(HeaderProperty); }
			set { SetValue(HeaderProperty, value); }
		}

		public static readonly DependencyProperty HeaderProperty =
			DependencyProperty.Register("Header", typeof(string), typeof(CostTypeSummaryView), new PropertyMetadata(string.Empty));


		public int BoardsQuantity {
			get { return (int)GetValue(BoardsQuantityProperty); }
			set { SetValue(BoardsQuantityProperty, value); }
		}

		// Using a DependencyProperty as the backing store for BoardsQuantity.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty BoardsQuantityProperty =
			DependencyProperty.Register("BoardsQuantity", typeof(int), typeof(CostTypeSummaryView), new PropertyMetadata(0));

		public ICollectionView ItemsSource {
			get { return (ICollectionView)GetValue(ItemsSourceProperty); }
			set { SetValue(ItemsSourceProperty, value); }
		}

		// Using a DependencyProperty as the backing store for ItemsSource.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty ItemsSourceProperty =
			DependencyProperty.Register("ItemsSource", typeof(ICollectionView), typeof(CostTypeSummaryView), new PropertyMetadata(null));


		//private static void ItemsSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {

		//	if (d is CostTypeSummaryView summaryView) {
		//		if (e.OldValue is INotifyCollectionChanged oldSource) {
		//			//oldSource.CollectionChanged -= summaryView.SourceChanged;
		//		}
		//		if (e.NewValue is INotifyCollectionChanged newSource) {
		//			//newSource.CollectionChanged += summaryView.SourceChanged;
		//		}
		//		summaryView.FilteredItemsSource.Source = e.NewValue;// is IEnumerable<ICostSummaryItem> source ? new ObservableCollection<ICostSummaryItem>(source.Where(item => item.Item.CostType == summaryView.CostTypeFilter)) : null;
		//	}
		//}

		//private void SourceChanged(object sender, NotifyCollectionChangedEventArgs e) {
		//	var oldItem = e.OldItems[0] as ICostSummaryItem;
		//	var newItem = e.NewItems[0] as ICostSummaryItem;
		//	switch (e.Action) {
		//		case NotifyCollectionChangedAction.Add:
		//			if (newItem?.Item.CostType == this.CostTypeFilter) {
		//				this.FilteredItemsSource.Add(newItem);
		//			}
		//			break;
		//		case NotifyCollectionChangedAction.Remove:
		//			if (oldItem?.Item.CostType == this.CostTypeFilter) {
		//				this.FilteredItemsSource.Remove(oldItem);
		//			}
		//			break;
		//		case NotifyCollectionChangedAction.Replace:
		//			if (oldItem.Item.CostType == this.CostTypeFilter) {
		//				var index = this.FilteredItemsSource.IndexOf(oldItem);
		//				this.FilteredItemsSource[index] = newItem;
		//			}
		//			break;
		//		case NotifyCollectionChangedAction.Reset:
		//			this.FilteredItemsSource.Source = new ObservableCollection<ICostSummaryItem>(this.ItemsSource.Where(item => item.Item.CostType == this.CostTypeFilter));
		//			break;
		//	}
		//}

		public CollectionViewSource FilteredItemsSource {
			get => this.filteredItemsSource;
			private set {
				this.filteredItemsSource = value;
				RaisePropertyChanged(nameof(this.FilteredItemsSource));
			}
		}

		private void RaisePropertyChanged(string propertyName) {
			this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
