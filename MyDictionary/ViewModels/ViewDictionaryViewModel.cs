#region FileHeader
// ***********************************************************************
// Assembly         : MyDictionary
// Author           : Sino Raj
// Created          : 27-08-2017
//
// ***********************************************************************
// <copyright file="ViewDictionaryViewModel.cs" company="Xebia">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
#endregion
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using MyDictionary.Components.Interfaces;
using MyDictionary.Components.Models;
using Xamarin.Forms;

namespace MyDictionary.ViewModels
{
	public class ViewDictionaryViewModel : ViewModelBase
	{
		private DictionaryModel dictionaryModel = null;
		private ObservableCollection<DictionaryItemModel> _dictionaries = null;

		public DictionaryModel Dictionary
		{
			get
			{
				return dictionaryModel;
			}
			set
			{
				dictionaryModel = value;
                RaisePropertyChanged(() => Dictionary);
			}
		}

		public ObservableCollection<DictionaryItemModel> DictionaryItems
		{
			get
			{
				return _dictionaries;
			}
			set
			{
				_dictionaries = value;
				RaisePropertyChanged(()=> DictionaryItems);
			}
		}

		public ViewDictionaryViewModel(IDictionaryItems dictionaryItems)
		{
			_dictionaries = dictionaryItems.GetDictionaryItems();
			if (_dictionaries.Count >= 5)
				IsTakeTestVisible = true;
		}

		public override async Task InitializeAsync(object navigationData)
		{
			IsBusy = true;
			try{
				Dictionary = navigationData as DictionaryModel;
			}
			catch (Exception e)
			{
			}
			IsBusy = false;
		}

		public ICommand TakeaTestCommand => new Command(TakeaTestAsync);

		private async void TakeaTestAsync()
		{
			await NavigationService.NavigateToAsync<TakeaTestViewModel>();
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
	}
}
