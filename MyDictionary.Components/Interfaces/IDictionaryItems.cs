using System;
using System.Collections.ObjectModel;
using MyDictionary.Components.Models;

namespace MyDictionary.Components.Interfaces
{
	public interface IDictionaryItems
	{
		ObservableCollection<DictionaryItemModel> GetDictionaryItems();
	}
}
