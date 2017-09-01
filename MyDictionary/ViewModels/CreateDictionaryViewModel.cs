#region FileHeader
// ***********************************************************************
// Assembly         : MyDictionary
// Author           : Sino Raj
// Created          : 27-08-2017
//
// ***********************************************************************
// <copyright file="CreateDictionaryViewModel.cs" company="Dreamz">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
#endregion
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using MyDictionary.Components.Helpers;
using MyDictionary.Components.Interfaces;
using MyDictionary.Components.Models;
using Xamarin.Forms;

namespace MyDictionary.ViewModels
{
	public class CreateDictionaryViewModel : ViewModelBase
	{
		private string primaryWord = "";

		public string PrimaryWord
		{
			get
			{
				return primaryWord;
			}
			set
			{
				primaryWord = value;
				RaisePropertyChanged(() => PrimaryWord);
			}
		}

		private string secondaryWord = "";

		public string SecondaryWord
		{
			get
			{
				return secondaryWord;
			}

			set
			{
				secondaryWord = value;
				RaisePropertyChanged(() => SecondaryWord);
			}
		}

		private bool isTakeTestVisible = false;

		public bool IsTakeTestVisible
		{
			get
			{
				return isTakeTestVisible;
			}
			set
			{
				isTakeTestVisible = value;
                RaisePropertyChanged(() => IsTakeTestVisible);
			}
		}

		public string PrimaryTitle
		{
			get;
			set;
		}

		public string SecondaryTitle
		{
			get;
			set;
		}

		private DictionaryItemModel dictionaryItemModel = null;
		private ObservableCollection<DictionaryItemModel> _dictionaryItems = new ObservableCollection<DictionaryItemModel>();

		public ObservableCollection<DictionaryItemModel> DictionaryItems
		{
			get
			{
				return _dictionaryItems;
			}

			set
			{
				_dictionaryItems = value;
				RaisePropertyChanged(() => DictionaryItems);
			}
		}

		public CreateDictionaryViewModel(ILanguageItems languageItems)
		{
			var language = languageItems.Languages().SingleOrDefault((arg) => arg.Id == Settings.PrimaryLanguage);
			PrimaryTitle = language.Name + " word";
			language = languageItems.Languages().SingleOrDefault((arg) => arg.Id == Settings.SecondaryLanguage);
			SecondaryTitle = language.Name + " Word";
		}

		public ICommand TakeTestCommand => new Command(DoTakeTestAction);

		private async void DoTakeTestAction()
		{
			await NavigationService.NavigateToAsync<TakeaTestViewModel>();
		}

		public ICommand AddNewItem => new Command(OnAddNewItem);

		private async void OnAddNewItem()
		{
			if (string.IsNullOrEmpty(PrimaryWord)) {
				await DialogService.ShowAlertAsync("Please enter primary word", "Error", "Ok");
				return;
			}
			else if (string.IsNullOrEmpty(SecondaryWord)) {
				await DialogService.ShowAlertAsync("Please enter secondary word'", "Error", "Ok");
				return;
			}
			dictionaryItemModel = new DictionaryItemModel();
			dictionaryItemModel.PrimaryWord = PrimaryWord;
			dictionaryItemModel.SecondaryWord = SecondaryWord;
			DictionaryItems.Add(dictionaryItemModel);

			PrimaryWord = "";
			SecondaryWord = "";

			if (DictionaryItems.Count >= 5)
				IsTakeTestVisible = true;
		}
	}
}
