using BoardOrder.Domain.Models;
using System.Windows;
using System.Windows.Controls;

namespace BoardOrder.Common.Controls {
	public partial class CostsSummary : UserControl {
		public CostsSummary() {
			InitializeComponent();
		}

		public int BoardQuantity {
			get { return (int)GetValue(BoardQuantityProperty); }
			set { SetValue(BoardQuantityProperty, value); }
		}

		public static readonly DependencyProperty BoardQuantityProperty =
			DependencyProperty.Register("BoardQuantity", typeof(int), typeof(CostsSummary), new FrameworkPropertyMetadata(1, HandleCostChange));


		public BoardOrderItem Item {
			get { return (BoardOrderItem)GetValue(ItemProperty); }
			set { SetValue(ItemProperty, value); }
		}

		public static readonly DependencyProperty ItemProperty =
			DependencyProperty.Register("Item", typeof(BoardOrderItem), typeof(CostsSummary), new FrameworkPropertyMetadata(null, HandleCostChange));

		public double MoneyCost {
			get { return (double)GetValue(MoneyCostProperty); }
			set { SetValue(MoneyCostProperty, value); }
		}

		// Using a DependencyProperty as the backing store for MoneyCost.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty MoneyCostProperty =
			DependencyProperty.Register("MoneyCost", typeof(double), typeof(CostsSummary), new PropertyMetadata(0.0));

		public double TimeCost {
			get { return (double)GetValue(TimeCostProperty); }
			set { SetValue(TimeCostProperty, value); }
		}

		// Using a DependencyProperty as the backing store for TimeCost.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty TimeCostProperty =
			DependencyProperty.Register("TimeCost", typeof(double), typeof(CostsSummary), new PropertyMetadata(0.0));


		private static void HandleCostChange(DependencyObject d, DependencyPropertyChangedEventArgs e) {
			if (d is CostsSummary summary) {
				if (summary.Item == null) {
					return;
				}

				var days = summary.Item.WorkdaysModifier * summary.BoardQuantity;
				var money = summary.Item.CostModifier * summary.BoardQuantity;

				summary.TimeCost = days;
				summary.MoneyCost = money;
			}
		}
	}
}
