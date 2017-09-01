#region FileHeader
// ***********************************************************************
// Assembly         : MyDictionary
// Author           : Sino Raj
// Created          : 27-08-2017
//
// ***********************************************************************
// <copyright file="TakeaTestViewModel.cs" company="Dreamz">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
#endregion
using System.Collections.ObjectModel;
using System.Windows.Input;
using MyDictionary.Components.Helpers;
using MyDictionary.Components.Interfaces;
using MyDictionary.Components.Models;
using Xamarin.Forms;

namespace MyDictionary.ViewModels
{
	public class TakeaTestViewModel : ViewModelBase
	{
		private int position = 0;
		private int correctAnswers = 0;
		private ObservableCollection<DictionaryItemModel> _dictionaryItems = null;

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

		public TakeaTestViewModel(IDictionaryItems dictionaryItems)
		{
			_dictionaryItems = dictionaryItems.GetDictionaryItems();
			ContinueButtonText = "Next";
			CountPos = (position + 1) + "/" + _dictionaryItems.Count;
			TestTitle = "'" + _dictionaryItems[position].PrimaryWord + "' meaning in 'Dutch' is ";
			SecondaryWord = "";
		}

		private string _testTitle = "";
		public string TestTitle
		{
			get
			{
				return _testTitle;
			}
			set
			{
				_testTitle = value;
				RaisePropertyChanged(() => TestTitle);
			}
		}

		private string _countPos = "";
		public string CountPos
		{
			get
			{
				return _countPos;
			}
			set
			{
				_countPos = value;
				RaisePropertyChanged(() => CountPos);
			}
		}

		private string _secondaryWord = "";
		public string SecondaryWord
		{
			get
			{
				return _secondaryWord;
			}
			set
			{
				_secondaryWord = value;
				RaisePropertyChanged(() => SecondaryWord);
			}
		}

		private string _continueButtonText = "";
		public string ContinueButtonText
		{
			get
			{
				return _continueButtonText;
			}
			set
			{
				_continueButtonText = value;
				RaisePropertyChanged(() => ContinueButtonText);
			}
		}

		public ICommand ContinueCommand => new Command(ContinueAsync);

		private async void ContinueAsync()
		{
			if (SecondaryWord.Trim().Length == 0)
			{
				await DialogService.ShowAlertAsync("Error", "Please enter a word" , "Ok");
				return;
			}

			if (SecondaryWord.ToUpper() == _dictionaryItems[position].SecondaryWord.ToUpper())
			{
				correctAnswers++;
				ContinueButtonText = "Next";
			}
			if (position == _dictionaryItems.Count - 1)
			{
				ContinueButtonText = "Next";
				position = 0;
				TestTitle = _dictionaryItems[position].PrimaryWord + " meaning in 'Dutch' is ";
				SecondaryWord = "";
				Settings.TestScore = correctAnswers;
				Settings.TestScoreOutOf = _dictionaryItems.Count;
				Settings.LastAttemtedDictionary = "English to Dutch Dictionary";
				await DialogService.ShowAlertAsync("You had completed your test with " 
				     + correctAnswers + "/" + _dictionaryItems.Count, "Completed your test",  "Take Test Again");
				correctAnswers = 0;
			}
			else
			{
				if (position < _dictionaryItems.Count - 1)
				{
					position++;
					if (position == _dictionaryItems.Count - 1)
						ContinueButtonText = "Done";
				}
				TestTitle = _dictionaryItems[position].PrimaryWord + " meaning in 'Dutch' is ";
				SecondaryWord = "";
			}
			CountPos = (position + 1) + "/" + _dictionaryItems.Count;
		}
	}
}
