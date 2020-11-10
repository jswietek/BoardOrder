using BoardOrder.Common.Controls;
using BoardOrder.Messages;
using CommonServiceLocator;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace BoardOrder {
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window {
		private readonly IMessenger messenger;

		public MainWindow() {
			InitializeComponent();
			this.messenger = ServiceLocator.Current.GetInstance<IMessenger>();
			this.messenger.Register<RequestResetOrderMessage>(this, this.ResetRequested);

			this.Icon = new BitmapImage(new Uri("pack://application:,,,/BoardOrder;component/Images/icons8-circuit-100.png"));
		}

		private void ToolBarMouseDown(object sender, MouseButtonEventArgs e) {
			if (e.ChangedButton == MouseButton.Left) {
				this.DragMove();
			}
		}

		private void ResetRequested(RequestResetOrderMessage obj) {
			var confirmationDialog = new ModalMessageBox();
			confirmationDialog.Message = Properties.Resources.ORDER_RESET_CONFIRMATION;
			confirmationDialog.Title = Properties.Resources.ORDER_RESET_TITLE;
			confirmationDialog.Owner = this;
			var result = confirmationDialog.ShowDialog();
			this.messenger.Send(new RestOrderConfirmationMessage(result.HasValue && result.Value));
		}

		private void Close(object sender, RoutedEventArgs e) {
			this.Close();
		}

		private void Minimize(object sender, RoutedEventArgs e) {
			this.WindowState = WindowState.Minimized;
		}

		private void RequestNavigate(object sender, RequestNavigateEventArgs e) {
			Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
			e.Handled = true;
		}
	}
}
