using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace BoardOrder.Common.Controls {
	/// <summary>
	/// Interaction logic for CostTypeSummaryView.xaml
	/// </summary>
	public partial class CostTypeSummaryView : UserControl, INotifyPropertyChanged {
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

		private void RaisePropertyChanged(string propertyName) {
			this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
