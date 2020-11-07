using System.Windows;

namespace BoardOrder.Common.Extensions {
	public static class ExpanderExtensions {
		public static string GetCostSummary(DependencyObject obj) {
			return (string)obj.GetValue(CostSummaryProperty);
		}

		public static void SetCostSummary(DependencyObject obj, string value) {
			obj.SetValue(CostSummaryProperty, value);
		}

		// Using a DependencyProperty as the backing store for CostSummary.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty CostSummaryProperty =
			DependencyProperty.RegisterAttached("CostSummary", typeof(string), typeof(ExpanderExtensions), new PropertyMetadata(string.Empty));



		public static string GetTimeSummary(DependencyObject obj) {
			return (string)obj.GetValue(TimeSummaryProperty);
		}

		public static void SetTimeSummary(DependencyObject obj, string value) {
			obj.SetValue(TimeSummaryProperty, value);
		}

		// Using a DependencyProperty as the backing store for TimeSummary.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty TimeSummaryProperty =
			DependencyProperty.RegisterAttached("TimeSummary", typeof(string), typeof(ExpanderExtensions), new PropertyMetadata(0));


	}
}
