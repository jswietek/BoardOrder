using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
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

		private static void ItemsSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {
			if (d is MultiButton multiButton) {
				var childCopy = multiButton.MainGrid.Children.OfType<RadioButton>();
				foreach(var button in childCopy) {
					multiButton.MainGrid.Children.Remove(button);
				}
				multiButton.MainGrid.ColumnDefinitions.Clear();

				CreateControls(multiButton, e.NewValue as IEnumerable<object>);
			}
		}

		private static void CreateControls(MultiButton parent, IEnumerable<object> items) {
			if (items == null) {
				return;
			}

			var columnIndex = 0;

			foreach (var item in items) {
				parent.MainGrid.ColumnDefinitions.Add(new ColumnDefinition());
				var temp = new RadioButton();
				temp.Content = item;
				temp.SetValue(Grid.ColumnProperty, columnIndex);
				temp.GroupName = parent.GetHashCode().ToString();
				temp.Checked += parent.ButtonChecked;
				temp.SnapsToDevicePixels = true;
				parent.MainGrid.Children.Add(temp);
				columnIndex++;
			}
		}

		private void ButtonChecked(object sender, RoutedEventArgs e) {
			this.ignoreValueChanged = true;
			this.SelectedItem = (sender as ToggleButton).Content;
		}
	}
}
