#region FileHeader
// ***********************************************************************
// Assembly         : MyDictionary
// Author           : Sino Raj
// Created          : 27-08-2017
//
// ***********************************************************************
// <copyright file="InialDictionaryCreationViewModel.cs" company="Dreamz">
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
	public class InialDictionaryCreationViewModel : ViewModelBase
	{
		private bool isPrimaryLanguage = true;
		private string primaryLanguage = "Select";

		private readonly ILanguageItems _languageItems = null;

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

		public InialDictionaryCreationViewModel(ILanguageItems languageItems)
		{
			_languageItems = languageItems;
			InitializeMessaging();
			OnUpdateLanguage();
		}

		public ICommand PrimaryLanguageCommand => new Command(PrimaryLanguageAsync);
		public ICommand SecondaryLanguageCommand => new Command(SecondaryLanguageAsync);
		public ICommand ContinueCommand => new Command(ContinueAsync);

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

		private async void ContinueAsync()
		{
			if (Settings.PrimaryLanguage == -1)
				await DialogService.ShowAlertAsync("Please select 'Primary language'", "Warning", "Ok");
			else if (Settings.SecondaryLanguage == -1)
				await DialogService.ShowAlertAsync("Please select 'Secondary language'", "Warning", "Ok");
			else
				await NavigationService.NavigateToAsync<CreateDictionaryViewModel>();
		}

		private void InitializeMessaging()
		{
			MessagingCenter.Subscribe<SelectLanguageViewModel, LanguageModel>(this, "LanguageChanged", (sender, args)=>
			{
				if (isPrimaryLanguage)
					Settings.PrimaryLanguage = args.Id;
				else
					Settings.SecondaryLanguage = args.Id;
				OnUpdateLanguage();
			});
		}

		private void OnUpdateLanguage()
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
	}
}
