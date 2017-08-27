using System.Collections.ObjectModel;
using MyDictionary.Components.Interfaces;

namespace MyDictionary.Components.Models
{
	public class Dictionaries : IDictionaries
	{
		private DictionaryModel dictionaryModel = null;
		private ObservableCollection<DictionaryModel> _dictionaries = new ObservableCollection<DictionaryModel>();

		public ObservableCollection<DictionaryModel> GetDictionaries()
		{
			if (_dictionaries.Count == 0)
				InitializeDictionary();
			return _dictionaries;
		}

		private void InitializeDictionary()
		{
			dictionaryModel = new DictionaryModel();
			dictionaryModel.Count = 10;
			dictionaryModel.PrimaryLanguage = "English";
			dictionaryModel.SecondaryLanguage = "Dutch";
			_dictionaries.Add(dictionaryModel);

			dictionaryModel = new DictionaryModel();
			dictionaryModel.Count = 12;
			dictionaryModel.PrimaryLanguage = "Portuguese";
			dictionaryModel.SecondaryLanguage = "English";
			_dictionaries.Add(dictionaryModel);

			dictionaryModel = new DictionaryModel();
			dictionaryModel.Count = 24;
			dictionaryModel.PrimaryLanguage = "Japanese";
			dictionaryModel.SecondaryLanguage = "German";
			_dictionaries.Add(dictionaryModel);

			dictionaryModel = new DictionaryModel();
			dictionaryModel.Count = 35;
			dictionaryModel.PrimaryLanguage = "German";
			dictionaryModel.SecondaryLanguage = "Portuguese";
			_dictionaries.Add(dictionaryModel);

			dictionaryModel = new DictionaryModel();
			dictionaryModel.Count = 8;
			dictionaryModel.PrimaryLanguage = "Japanese";
			dictionaryModel.SecondaryLanguage = "Portuguese";
			_dictionaries.Add(dictionaryModel);

			dictionaryModel = new DictionaryModel();
			dictionaryModel.Count = 20;
			dictionaryModel.PrimaryLanguage = "English";
			dictionaryModel.SecondaryLanguage = "German";
			_dictionaries.Add(dictionaryModel);
		}
	}
}
