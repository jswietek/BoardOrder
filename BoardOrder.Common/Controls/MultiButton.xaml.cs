using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace BoardOrder.Common.Controls {
	/// <summary>
	/// Interaction logic for MultiButton.xaml
	/// </summary>
	public partial class MultiButton : UserControl {
		public MultiButton() {
			InitializeComponent();
		}

		public IEnumerable<string> ItemsSource {
			get { return (IEnumerable<string>)GetValue(ItemsSourceProperty); }
			set { SetValue(ItemsSourceProperty, value); }
		}

		// Using a DependencyProperty as the backing store for ItemsSource.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty ItemsSourceProperty =
			DependencyProperty.Register("ItemsSource", typeof(IEnumerable<string>), typeof(MultiButton), new PropertyMetadata(Enumerable.Empty<string>(), ItemsSourceChanged));

		public string SelectedItem {
			get { return (string)GetValue(SelectedItemProperty); }
			set { SetValue(SelectedItemProperty, value); }
		}

		// Using a DependencyProperty as the backing store for SelectedItem.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty SelectedItemProperty =
			DependencyProperty.Register("SelectedItem", typeof(string), typeof(MultiButton), new PropertyMetadata(string.Empty));

		private static void ItemsSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {
			if (d is MultiButton multiButton) {
				multiButton.MainGrid.Children.Clear();
				multiButton.MainGrid.ColumnDefinitions.Clear();

				CreateControls(multiButton, e.NewValue as IEnumerable<string>);
			}
		}

		private static void CreateControls(MultiButton parent, IEnumerable<string> labels) {
			if (labels == null) {
				return;
			}

			var columnIndex = 0;

			foreach (var label in labels) {
				parent.MainGrid.ColumnDefinitions.Add(new ColumnDefinition());
				var temp = new ToggleButton();
				temp.Content = label;
				temp.SetValue(Grid.ColumnProperty, columnIndex);
				temp.Checked += parent.ButtonChecked;
				parent.MainGrid.Children.Add(temp);
				columnIndex++;
			}
		}

		private void ButtonChecked(object sender, RoutedEventArgs e) {
			foreach (var child in this.MainGrid.Children) {
				if (child is ToggleButton tb && tb != sender) {
					tb.IsChecked = false;
				}
			}

			SelectedItem = (sender as ToggleButton).Content.ToString();
		}
	}
}
