using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace BoardOrder.Common.Controls {
	/// <summary>
	/// Interaction logic for MultiButton.xaml
	/// </summary>
	public partial class MultiButton : UserControl {
		private bool ignoreValueChanged = false;
		private IList<RadioButton> buttons;

		static MultiButton() {
			BorderBrushProperty.OverrideMetadata(typeof(MultiButton), new FrameworkPropertyMetadata(null, BorderBrushChanged));
		}

		public MultiButton() {
			InitializeComponent();
			this.buttons = new List<RadioButton>();
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

		public double ButtonBorderThickness {
			get { return (double)GetValue(ButtonBorderThicknessProperty); }
			set { SetValue(ButtonBorderThicknessProperty, value); }
		}

		// Using a DependencyProperty as the backing store for SelectedItem.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty ButtonBorderThicknessProperty =
			DependencyProperty.Register("ButtonBorderThickness", typeof(double), typeof(MultiButton), new PropertyMetadata(0.0, ButtonBorderThicknessChanged));


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
				foreach (var button in childCopy) {
					multiButton.MainGrid.Children.Remove(button);
					button.Checked -= multiButton.ButtonChecked;
				}

				multiButton.MainGrid.ColumnDefinitions.Clear();
				multiButton.SelectedItem = null;

				if (e.NewValue is IEnumerable<object> source) {
					multiButton.CreateControls(source);
				}
			}
		}

		private static void ButtonBorderThicknessChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {
			if (e.NewValue is double thickness && d is MultiButton parent) {
				var buttonsWithBorder = parent.MainGrid.Children.OfType<RadioButton>().Where(b => b.GetValue(Grid.ColumnProperty) is int columnIndex && columnIndex > 0);
				foreach (var button in buttonsWithBorder) {
					button.BorderThickness = new Thickness(thickness, 0, 0, 0);
				}
			}
		}

		private static void BorderBrushChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {
			if (e.NewValue is Brush brush && d is MultiButton parent) {
				var buttonsWithBorder = parent.MainGrid.Children.OfType<RadioButton>().Where(b => b.GetValue(Grid.ColumnProperty) is int columnIndex && columnIndex > 0);
				foreach (var button in buttonsWithBorder) {
					button.BorderBrush = brush;
				}
			}
		}

		private void CreateControls(IEnumerable<object> items) {
			if (items == null) {
				return;
			}

			var itemsCount = items.Count();
			this.CreateColumnDefinitions(itemsCount);
			this.CreateButtons(items, itemsCount);
		}

		private void CreateColumnDefinitions(int count) {
			var currentCount = this.MainGrid.ColumnDefinitions.Count;
			if (currentCount > count) {
				this.MainGrid.ColumnDefinitions.RemoveRange(count - 1, currentCount - count);
				return;
			}
			if (currentCount < count) {
				for (int i = currentCount; i < count; i++) {
					this.MainGrid.ColumnDefinitions.Add(new ColumnDefinition());
				}
				return;
			}
		}

		private void CreateButtons(IEnumerable<object> items, int targetCount) {
			var currentCount = this.buttons.Count;
			if (currentCount > targetCount) {

				for (int i = currentCount - 1; i >= 0; --i) {
					var button = this.buttons[i];
					if (i < targetCount) {
						this.ResetButtonProperties(button, i, items.ElementAt(i));
					}
					else {
						button.Checked -= this.ButtonChecked;
						this.buttons.Remove(button);
						this.MainGrid.Children.Remove(button);
					}
				}
			}
			else if (currentCount < targetCount) {
				for (int i = currentCount; i < targetCount; i++) {
					var newButton = new RadioButton();
					this.ResetButtonProperties(newButton, i, items.ElementAt(i));
					this.buttons.Add(newButton);
					this.MainGrid.Children.Add(newButton);
				}

			}
		}

		private void ResetButtonProperties(RadioButton button, int columnIndex, object item) {
			button.Content = item;
			button.SetValue(Grid.ColumnProperty, columnIndex);
			button.GroupName = this.GetHashCode().ToString();
			button.Checked += this.ButtonChecked;
			button.BorderBrush = this.BorderBrush;
			if (columnIndex > 0) {
				button.BorderThickness = new Thickness(this.ButtonBorderThickness, 0, 0, 0);
			}
			else {
				button.BorderThickness = new Thickness(0, 0, 0, 0);
			}
			button.SnapsToDevicePixels = true;
		}

		private void ButtonChecked(object sender, RoutedEventArgs e) {
			this.ignoreValueChanged = true;
			this.SelectedItem = (sender as ToggleButton).Content;
		}
	}
}
