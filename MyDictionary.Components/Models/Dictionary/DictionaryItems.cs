#region FileHeader
// ***********************************************************************
// Assembly         : MyDictionary
// Author           : Sino Raj
// Created          : 27-08-2017
//
// ***********************************************************************
// <copyright file="DictionaryItems.cs" company="Xebia">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
#endregion
using System.Collections.ObjectModel;
using MyDictionary.Components.Interfaces;

namespace MyDictionary.Components.Models
{
	public class DictionaryItems : IDictionaryItems
	{
		private DictionaryItemModel dictionaryModel = null;
		private ObservableCollection<DictionaryItemModel> _dictionaries = new ObservableCollection<DictionaryItemModel>();

		public ObservableCollection<DictionaryItemModel> GetDictionaryItems()
		{
			if (_dictionaries.Count == 0)
				InitializeDictionary();
			return _dictionaries;
		}

		private void InitializeDictionary()
		{
			dictionaryModel = new DictionaryItemModel();
			dictionaryModel.PrimaryWord = "Vegetable";
			dictionaryModel.SecondaryWord = "Groente";
			_dictionaries.Add(dictionaryModel);

			dictionaryModel = new DictionaryItemModel();
			dictionaryModel.PrimaryWord = "Steak";
			dictionaryModel.SecondaryWord = "Biefstuk";
			_dictionaries.Add(dictionaryModel);

			dictionaryModel = new DictionaryItemModel();
			dictionaryModel.PrimaryWord = "Bag of crisps";
			dictionaryModel.SecondaryWord = "Zak chips";
			_dictionaries.Add(dictionaryModel);

			dictionaryModel = new DictionaryItemModel();
			dictionaryModel.PrimaryWord = "Cabbage";
			dictionaryModel.SecondaryWord = "Kool";
			_dictionaries.Add(dictionaryModel);

			dictionaryModel = new DictionaryItemModel();
			dictionaryModel.PrimaryWord = "Fish";
			dictionaryModel.SecondaryWord = "vis";
			_dictionaries.Add(dictionaryModel);

			dictionaryModel = new DictionaryItemModel();
			dictionaryModel.PrimaryWord = "pigeon";
			dictionaryModel.SecondaryWord = "duif";
			_dictionaries.Add(dictionaryModel);

			dictionaryModel = new DictionaryItemModel();
			dictionaryModel.PrimaryWord = "butterfly";
			dictionaryModel.SecondaryWord = "vlinder";
			_dictionaries.Add(dictionaryModel);
		}
	}
}
