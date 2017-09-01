#region FileHeader
// ***********************************************************************
// Assembly         : MyDictionary
// Author           : Sino Raj
// Created          : 27-08-2017
//
// ***********************************************************************
// <copyright file="SelectLanguageViewModel.cs" company="Dreamz">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
#endregion
using System.Collections.ObjectModel;
using MyDictionary.Components.Interfaces;
using MyDictionary.Components.Model;
using Xamarin.Forms;

namespace MyDictionary.ViewModels
{
	public class SelectLanguageViewModel : ViewModelBase
	{
		private ObservableCollection<LanguageModel> _languages = new ObservableCollection<LanguageModel>();

		public ObservableCollection<LanguageModel> Languages
		{
			get
			{
				return _languages;
			}

			set
			{
				_languages = value;
				RaisePropertyChanged(() => Languages);
			}
		}

		public SelectLanguageViewModel(ILanguageItems languageItems)
		{
			_languages = languageItems.Languages();
        }


		private Command<LanguageModel> selectCmd;
		public Command<LanguageModel> SelectCommand
		{
			get
			{
				this.selectCmd = this.selectCmd ?? new Command<LanguageModel>(s =>
				     MessagingCenter.Send(this, "LanguageChanged", s));
				return this.selectCmd;
			}
		}
	}
}
