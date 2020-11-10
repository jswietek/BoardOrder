using BoardOrder.Messages;
using CommonServiceLocator;
using GalaSoft.MvvmLight.Messaging;
using System.Windows.Controls;

namespace BoardOrder.Views {
	/// <summary>
	/// Interaction logic for PreferencesView.xaml
	/// </summary>
	public partial class PreferencesView : UserControl {
		private readonly IMessenger messenger;

		public PreferencesView() {
			InitializeComponent();
		}
	}
}
