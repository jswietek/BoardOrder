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
		private bool ignoreValueChanged = false;

		public MultiButton() {
			InitializeComponent();
		}

		public IEnumerable<object> ItemsSource {
			get { return (IEnumerable<object>)GetValue(ItemsSourceProperty); }
			set { SetValue(ItemsSourceProperty, value); }
		}

		// Using a DependencyProperty as the backing store for ItemsSource.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty ItemsSourceProperty =
			DependencyProperty.Register("ItemsSource", typeof(IEnumerable<object>), typeof(MultiButton), new PropertyMetadata(null, ItemsSourceChanged));

		public object SelectedItem {
			get { return (object)GetValue(SelectedItemProperty); }
			set { SetValue(SelectedItemProperty, value); }
		}

		// Using a DependencyProperty as the backing store for SelectedItem.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty SelectedItemProperty =
			DependencyProperty.Register("SelectedItem", typeof(object), typeof(MultiButton), new PropertyMetadata(null, SelectedItemChanged));

		public int SelectedIndex {
			get { return (int)GetValue(SelectedIndexProperty); }
			set { SetValue(SelectedIndexProperty, value); }
		}

		// Using a DependencyProperty as the backing store for SelectedItem.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty SelectedIndexProperty =
			DependencyProperty.Register("SelectedIndex", typeof(int), typeof(MultiButton), new PropertyMetadata(0, SelectedIndexChanged));

		private static void SelectedItemChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {
			if (d is MultiButton multiButton) {
				if (multiButton.ignoreValueChanged) {
					multiButton.ignoreValueChanged = false;
					return;
				}

				foreach (var child in multiButton.MainGrid.Children) {
					if (child is ToggleButton button) {
						button.Checked -= multiButton.ButtonChecked;
						button.IsChecked = button.Content == e.NewValue;
						button.Checked += multiButton.ButtonChecked;
					}
				}
			}
		}

		private static void SelectedIndexChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {
			if (d is MultiButton multiButton) {
				var selectedItem = multiButton.ItemsSource.ElementAt((int)e.NewValue);
				multiButton.SelectedItem = selectedItem;
			}
		}

		private static void ItemsSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {
			if (d is MultiButton multiButton) {
				var childCopy = multiButton.MainGrid.Children.OfType<RadioButton>();
				foreach (var button in childCopy) {
					multiButton.MainGrid.Children.Remove(button);
					button.Checked -= multiButton.ButtonChecked;
				}
				multiButton.MainGrid.ColumnDefinitions.Clear();
				if (e.NewValue is IEnumerable<object> source) {
					multiButton.CreateControls(source);
					var itemAtIndex = source.ElementAtOrDefault(multiButton.SelectedIndex);
					multiButton.SelectedItem = itemAtIndex;
				}
			}
		}

		private void CreateControls(IEnumerable<object> items) {
			if (items == null) {
				return;
			}

			var columnIndex = 0;

			foreach (var item in items) {
				this.MainGrid.ColumnDefinitions.Add(new ColumnDefinition());
				var temp = new RadioButton();
				temp.Content = item;
				temp.SetValue(Grid.ColumnProperty, columnIndex);
				temp.GroupName = this.GetHashCode().ToString();
				temp.Checked += this.ButtonChecked;
				temp.SnapsToDevicePixels = true;
				this.MainGrid.Children.Add(temp);
				columnIndex++;
			}
		}

		private void ButtonChecked(object sender, RoutedEventArgs e) {
			this.ignoreValueChanged = true;
			this.SelectedItem = (sender as ToggleButton).Content;
		}
	}
}
