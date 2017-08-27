#region FileHeader
// ***********************************************************************
// Assembly         : MyDictionary
// Author           : Sino Raj
// Created          : 27-08-2017
//
// ***********************************************************************
// <copyright file="SettingsViewModel.cs" company="Xebia">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
#endregion
using System.Windows.Input;
using System.Linq;
using MyDictionary.Components.Helpers;
using MyDictionary.Components.Interfaces;
using MyDictionary.Components.Model;
using Xamarin.Forms;

namespace MyDictionary.ViewModels
{
	public class SettingsViewModel : ViewModelBase
	{
		private bool isPrimaryLanguage = true;
		private readonly IAuthenticationService _authenticationService;
		private readonly ILanguageItems _languageItems = null;

		private string primaryLanguage = "Select";

		public string PrimaryLanguage
		{
			get
			{
				return primaryLanguage;
			}
			set
			{
				primaryLanguage = value;
				RaisePropertyChanged(() => PrimaryLanguage);
			}
		}

		private string secondaryLanguage = "Select";

		public string SecondaryLanguage
		{
			get
			{
				return secondaryLanguage;
			}

			set
			{
				secondaryLanguage = value;
				RaisePropertyChanged(() => SecondaryLanguage);
			}
		}

		private string noOfQuestions = "0";

		public string NoOfQuestions
		{
			get
			{
				return noOfQuestions;
			}

			set
			{
				noOfQuestions = value;
				RaisePropertyChanged(() => NoOfQuestions);
			}
		}

		public SettingsViewModel(IAuthenticationService authenticationService, ILanguageItems languageItems)
		{
			_authenticationService = authenticationService;
			_languageItems = languageItems;

			OnUpdateLanguages();
			OnUpdateCount();

			InitializeMessaging();
	}

		public ICommand PrimaryLanguageCommand => new Command(PrimaryLanguageAsync);
		public ICommand SecondaryLanguageCommand => new Command(SecondaryLanguageAsync);
		public ICommand MaxNoOfQuestionsCommand => new Command(MaxNoOfQuestionsAsync);
		public ICommand SignOutCommand => new Command(OnSignout);

		private async void PrimaryLanguageAsync()
		{
			isPrimaryLanguage = true;
			await NavigationService.NavigateToAsync<SelectLanguageViewModel>();
		}

		private async void SecondaryLanguageAsync()
		{
			isPrimaryLanguage = false;
			await NavigationService.NavigateToAsync<SelectLanguageViewModel>();
		}

		private async void MaxNoOfQuestionsAsync()
		{
			await NavigationService.NavigateToAsync<MaxNoOfQuestionsSelectionViewModel>();
		}

		private async void OnSignout()
		{
			IsBusy = true;
			await _authenticationService.LogoutAsync();
			await NavigationService.NavigateToAsync<LoginViewModel>();
			IsBusy = false;
		}

		private void InitializeMessaging()
		{
			MessagingCenter.Subscribe<SelectLanguageViewModel, LanguageModel>(this, "LanguageChanged", (sender, args)=>
			{
				if (isPrimaryLanguage)
					Settings.PrimaryLanguage = args.Id;
				else
					Settings.SecondaryLanguage = args.Id;
				OnUpdateLanguages();
			});
			MessagingCenter.Subscribe<MaxNoOfQuestionsSelectionViewModel, int>(this, "CountChanged", (sender, args) =>
			{
				Settings.NoOfQuestions = args;
				OnUpdateCount();
			});
		}

		private void OnUpdateLanguages()
		{
			if (Settings.PrimaryLanguage > -1)
			{
				var language = _languageItems.Languages().SingleOrDefault((arg) => arg.Id == Settings.PrimaryLanguage);
				PrimaryLanguage = language.Name;
			}
			if (Settings.SecondaryLanguage > -1)
			{
				var language = _languageItems.Languages().SingleOrDefault((arg) => arg.Id == Settings.SecondaryLanguage);
				SecondaryLanguage = language.Name;
			}
		}

		private void OnUpdateCount()
		{
			NoOfQuestions = Settings.NoOfQuestions.ToString();
		}
	}
}
