using System.Collections.ObjectModel;
using MyDictionary.Components.Interfaces;
using MyDictionary.Components.Model;

namespace MyDictionary.Components.Models
{
	public class LanguageItems : ILanguageItems
	{
		private LanguageModel languageModel = null;
		private ObservableCollection<LanguageModel> _languages = new ObservableCollection<LanguageModel>();

		public ObservableCollection<LanguageModel> Languages()
		{
			if (_languages.Count == 0)
				InitializeLanguage();
			return _languages;
		}

		private void InitializeLanguage()
		{
			languageModel = new LanguageModel();
			languageModel.Id = 0;
			languageModel.Name = "English";
			languageModel.IsSelected = false;
			_languages.Add(languageModel);

			languageModel = new LanguageModel();
			languageModel.Id = 1;
			languageModel.Name = "Dutch";
			languageModel.IsSelected = false;
			_languages.Add(languageModel);

			languageModel = new LanguageModel();
			languageModel.Id = 2;
			languageModel.Name = "French";
			languageModel.IsSelected = false;
			_languages.Add(languageModel);

			languageModel = new LanguageModel();
			languageModel.Id = 3;
			languageModel.Name = "Portuguese";
			languageModel.IsSelected = false;
			_languages.Add(languageModel);

			languageModel = new LanguageModel();
			languageModel.Id = 4;
			languageModel.Name = "German";
			languageModel.IsSelected = false;
			_languages.Add(languageModel);

			languageModel = new LanguageModel();
			languageModel.Id = 5;
			languageModel.Name = "Italian";
			languageModel.IsSelected = false;
			_languages.Add(languageModel);

			languageModel = new LanguageModel();
			languageModel.Id = 6;
			languageModel.Name = "Japanese";
			languageModel.IsSelected = false;
			_languages.Add(languageModel);


			languageModel = new LanguageModel();
			languageModel.Id = 7;
			languageModel.Name = "Hebrew";
			languageModel.IsSelected = false;
			_languages.Add(languageModel);

			languageModel = new LanguageModel();
			languageModel.Id = 8;
			languageModel.Name = "Spanish";
			languageModel.IsSelected = false;
			_languages.Add(languageModel);

			languageModel = new LanguageModel();
			languageModel.Id = 9;
			languageModel.Name = "Italian";
			languageModel.IsSelected = false;
			_languages.Add(languageModel);
		}
	}
}
