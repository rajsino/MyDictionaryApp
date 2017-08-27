using System;
using Microsoft.Practices.Unity;
using MyDictionary.API.DataServices;
using MyDictionary.Components.Interfaces;
using MyDictionary.Components.Models;
using MyDictionary.Services;

namespace MyDictionary.ViewModels
{
	public class ViewModelLocator
	{
		private readonly IUnityContainer _unityContainer;

		private static readonly ViewModelLocator _instance = new ViewModelLocator();

		public static ViewModelLocator Instance
		{
			get
			{
				return _instance;
			}
		}

		protected ViewModelLocator()
		{
			_unityContainer = new UnityContainer();
			_unityContainer.RegisterType<IRequestProvider, RequestProvider>();

			_unityContainer.RegisterType<IDialogService, DialogService>();
			RegisterSingleton<INavigationService, NavigationService>();
			RegisterSingleton<ILanguageItems, LanguageItems>();
			RegisterSingleton<IDictionaries, Dictionaries>();
			RegisterSingleton<IDictionaryItems, DictionaryItems>();

			// data services
            _unityContainer.RegisterType<IAuthenticationService, AuthenticationService>();
			_unityContainer.RegisterType<IProfileService, ProfileService>();

			// view models
            _unityContainer.RegisterType<HomePageViewModel>();
            _unityContainer.RegisterType<LoginViewModel>();
            _unityContainer.RegisterType<BaseViewModel>();
            _unityContainer.RegisterType<MasterViewModel>();
            _unityContainer.RegisterType<ProfileViewModel>();
            _unityContainer.RegisterType<SignUpViewModel>();
			_unityContainer.RegisterType<CreateDictionaryViewModel>();
            _unityContainer.RegisterType<ViewDictionaryViewModel>();
            _unityContainer.RegisterType<SelectLanguageViewModel>();
			_unityContainer.RegisterType<MyProfileViewModel>();
			_unityContainer.RegisterType<SettingsViewModel>();
			_unityContainer.RegisterType<AboutUsViewModel>();
			_unityContainer.RegisterType<HelpViewModel>();
			_unityContainer.RegisterType<MaxNoOfQuestionsSelectionViewModel>();
			_unityContainer.RegisterType<InialDictionaryCreationViewModel>();
			_unityContainer.RegisterType<TakeaTestViewModel>();
		}

		public T Resolve<T>()
		{
			return _unityContainer.Resolve<T>();
		}

		public object Resolve(Type type)
		{
			return _unityContainer.Resolve(type);
		}

		public void Register<T>(T instance)
		{
			_unityContainer.RegisterInstance<T>(instance);
		}

		public void Register<TInterface, T>() where T : TInterface
		{
			_unityContainer.RegisterType<TInterface, T>();
		}

		public void RegisterSingleton<TInterface, T>() where T : TInterface
		{
			_unityContainer.RegisterType<TInterface, T>(new ContainerControlledLifetimeManager());
		}
	}
}
