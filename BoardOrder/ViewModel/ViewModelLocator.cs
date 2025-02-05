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
			SimpleIoc.Default.Register<IQuoteService, QuoteService>();
			SimpleIoc.Default.Register<PreferencesOptionsProvider>();
			SimpleIoc.Default.Register<BoardOrderManager>();
			SimpleIoc.Default.Register<PreferencesViewModel>();
			SimpleIoc.Default.Register<LoaderViewModel>();
			SimpleIoc.Default.Register<QuoteViewModel>();
			SimpleIoc.Default.Register<PlacedOrdersViewModel>();
			SimpleIoc.Default.Register<MainViewModel>();

			//this registrations break design time
			if (!ViewModelBase.IsInDesignModeStatic) {
				SimpleIoc.Default.Register<IOptionsProvider>(() => ServiceLocator.Current.GetInstance<PreferencesOptionsProvider>());
				SimpleIoc.Default.Register<IPreferencesOptions>(() => ServiceLocator.Current.GetInstance<PreferencesOptionsProvider>());
				SimpleIoc.Default.Register(() => Messenger.Default);
				SimpleIoc.Default.Register<IBoardOrderManager>(() => ServiceLocator.Current.GetInstance<BoardOrderManager>());
				SimpleIoc.Default.Register<IQuoteManager>(() => ServiceLocator.Current.GetInstance<BoardOrderManager>());
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

		public QuoteViewModel QuoteViewModel {
			get {
				return ServiceLocator.Current.GetInstance<QuoteViewModel>();
			}
		}

		public PlacedOrdersViewModel PlacedOrdersViewModel {
			get {
				return ServiceLocator.Current.GetInstance<PlacedOrdersViewModel>();
			}
		}

		public static void Cleanup() {
			ServiceLocator.Current.GetInstance<MainViewModel>().Cleanup();
			ServiceLocator.Current.GetInstance<PreferencesViewModel>().Cleanup();
			ServiceLocator.Current.GetInstance<LoaderViewModel>().Cleanup();
			ServiceLocator.Current.GetInstance<QuoteViewModel>().Cleanup();
			ServiceLocator.Current.GetInstance<PlacedOrdersViewModel>().Cleanup();
		}
	}
}
