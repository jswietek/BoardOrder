using BoardOrder.Domain.DataAccess;
using BoardOrder.Domain.Services;
using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;

namespace BoardOrder.ViewModel {
	/// <summary>
	/// This class contains static references to all the view models in the
	/// application and provides an entry point for the bindings.
	/// </summary>
	public class ViewModelLocator {
		/// <summary>
		/// Initializes a new instance of the ViewModelLocator class.
		/// </summary>
		public ViewModelLocator() {
			ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

			SimpleIoc.Default.Register<IPreferencesSettingsRepository, PredefinedPreferencesSettingsRepository>();
			SimpleIoc.Default.Register<IBoardOrdersManager, BoardOrdersManager>();
			SimpleIoc.Default.Register<PreferencesOptionsProvider>();
			SimpleIoc.Default.Register<PreferencesViewModel>();
			SimpleIoc.Default.Register<LoaderViewModel>();
			SimpleIoc.Default.Register<MainViewModel>();

			//this registrations break design time
			if (!ViewModelBase.IsInDesignModeStatic) {
				SimpleIoc.Default.Register<IOptionsProvider>(() => ServiceLocator.Current.GetInstance<PreferencesOptionsProvider>());
				SimpleIoc.Default.Register<IPreferencesOptions>(() => ServiceLocator.Current.GetInstance<PreferencesOptionsProvider>());
				SimpleIoc.Default.Register(() => Messenger.Default);
			}
		}

		public MainViewModel MainViewModel {
			get {
				return ServiceLocator.Current.GetInstance<MainViewModel>();
			}
		}

		public PreferencesViewModel PreferencesViewModel {
			get {
				return ServiceLocator.Current.GetInstance<PreferencesViewModel>();
			}
		}

		public LoaderViewModel LoaderViewModel {
			get {
				return ServiceLocator.Current.GetInstance<LoaderViewModel>();
			}
		}

		public static void Cleanup() {
		}
	}
}