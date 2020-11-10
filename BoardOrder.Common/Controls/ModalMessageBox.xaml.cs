using System.Windows;
using System.Windows.Input;

namespace BoardOrder.Common.Controls {
	/// <summary>
	/// Interaction logic for ModalMessageBox.xaml
	/// </summary>
	public partial class ModalMessageBox : Window {
		public ModalMessageBox() {
			InitializeComponent();
		}

		public string Message {
			set {
				this.MessageText.Text = value;
			}
		}

		private void ToolBarMouseDown(object sender, MouseButtonEventArgs e) {
			if (e.ChangedButton == MouseButton.Left) {
				this.DragMove();
			}
		}

		private void CancelClose(object sender, RoutedEventArgs e) {
			this.DialogResult = false;
			this.Close();
		}

		private void OkClose(object sender, RoutedEventArgs e) {
			this.DialogResult = true;
			this.Close();
		}
	}
}
