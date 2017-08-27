using System.Collections.ObjectModel;
using MyDictionary.Components.Models;

namespace MyDictionary.Components.Interfaces
{
	public interface IDictionaries
	{
		ObservableCollection<DictionaryModel> GetDictionaries();
	}
}
