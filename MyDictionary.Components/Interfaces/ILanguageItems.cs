using System.Collections.ObjectModel;
using MyDictionary.Components.Model;

namespace MyDictionary.Components.Interfaces
{
	public interface ILanguageItems
	{
		ObservableCollection<LanguageModel> Languages();
	}
}
