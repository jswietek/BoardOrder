using System.Windows;
using System.Windows.Controls;

namespace BoardOrder.Common.Extensions {
	public class TopMouseScrollPriorityBehavior {
        public static bool GetTopMouseScrollPriority(DependencyObject obj) {
            return (bool)obj.GetValue(TopMouseScrollPriorityProperty);
        }

        public static void SetTopMouseScrollPriority(DependencyObject obj, bool value) {
            obj.SetValue(TopMouseScrollPriorityProperty, value);
        }

        public static readonly DependencyProperty TopMouseScrollPriorityProperty =
            DependencyProperty.RegisterAttached("TopMouseScrollPriority", typeof(bool), typeof(TopMouseScrollPriorityBehavior), new PropertyMetadata(false, OnPropertyChanged));

        private static void OnPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {
            if (d is ScrollViewer scrollViewer && e.NewValue is bool shouldPrioritizeScroll) {
                if (shouldPrioritizeScroll) {
                    scrollViewer.PreviewMouseWheel += ScrollViewer_PreviewMouseWheel;
                }
				else {
                    scrollViewer.PreviewMouseWheel -= ScrollViewer_PreviewMouseWheel;
                }
            }
        }

        private static void ScrollViewer_PreviewMouseWheel(object sender, System.Windows.Input.MouseWheelEventArgs e) {
            if (sender is ScrollViewer scrollViewer) {
                scrollViewer.ScrollToVerticalOffset(scrollViewer.VerticalOffset - e.Delta);
                e.Handled = true;
            }
        }
    }
}
