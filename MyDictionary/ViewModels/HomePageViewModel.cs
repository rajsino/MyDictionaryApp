#region FileHeader
// ***********************************************************************
// Assembly         : MyDictionary
// Author           : Sino Raj
// Created          : 27-08-2017
//
// ***********************************************************************
// <copyright file="HomePageViewModel.cs" company="Xebia">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
#endregion
using System.Collections.ObjectModel;
using System.Windows.Input;
using MyDictionary.Components.Helpers;
using MyDictionary.Components.Interfaces;
using Xamarin.Forms;

namespace MyDictionary.ViewModels
{
	public class HomePageViewModel : ViewModelBase
	{
		private ObservableCollection<DictionaryModel> _dictionaries = null;

		public ObservableCollection<DictionaryModel> Dictionaries
		{
			get
			{
				return _dictionaries;
			}
			set
			{
				_dictionaries = value;
                RaisePropertyChanged(() => Dictionaries);
			}
		}

		public ICommand CreateNewDictionaryCommand => new Command(OnCreateNewDictionary);

		private async void OnCreateNewDictionary()
		{
			if(Settings.PrimaryLanguage == -1 || Settings.SecondaryLanguage == -1)
				await NavigationService.NavigateToAsync<InialDictionaryCreationViewModel>();
			else
				await NavigationService.NavigateToAsync<CreateDictionaryViewModel>();
		}

		public HomePageViewModel(IDictionaries dictionaries)
		{
			_dictionaries = dictionaries.GetDictionaries();
			if (Settings.TestScoreOutOf == 0)
			{
				IsNotTakenATest = true;
				IsTestAlreadyTaken = false;
			}
			else
			{
				IsNotTakenATest = false;
				IsTestAlreadyTaken = true;
				DictionaryTaken = Settings.LastAttemtedDictionary;
				LatetTestScore = Settings.TestScore + "/" + Settings.TestScoreOutOf;
			}
		}

		public ICommand ShowDictionaryCommand => new Command<DictionaryModel>(ShowDictionaryAsync);

		private async void ShowDictionaryAsync(DictionaryModel @dictionaryModel)
		{
			if (@dictionaryModel != null)
            {
                await NavigationService.NavigateToAsync<ViewDictionaryViewModel>(@dictionaryModel);
            }
		}

		public bool IsNotTakenATest
		{
			get;
			set;
		}

		public bool IsTestAlreadyTaken
		{
			get;
			set;
		}

		public string DictionaryTaken
		{
			get;
			set;
		}

		public string LatetTestScore
		{
			get;
			set;
		}
	}
}