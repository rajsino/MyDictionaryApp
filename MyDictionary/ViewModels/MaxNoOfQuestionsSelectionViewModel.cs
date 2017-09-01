#region FileHeader
// ***********************************************************************
// Assembly         : MyDictionary
// Author           : Sino Raj
// Created          : 27-08-2017
//
// ***********************************************************************
// <copyright file="MaxNoOfQuestionsSelectionViewModel.cs" company="Dreamz">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
#endregion
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace MyDictionary.ViewModels
{
	public class MaxNoOfQuestionsSelectionViewModel : ViewModelBase
	{
		private ObservableCollection<int> _maxCount = new ObservableCollection<int>();

		public ObservableCollection<int> MaxCount
		{
			get
			{
				return _maxCount;
			}

			set
			{
				_maxCount = value;
				RaisePropertyChanged(() => MaxCount);
			}
		}

		public MaxNoOfQuestionsSelectionViewModel()
		{
			for (int i = 1; i <= 10; i++)
			{
				_maxCount.Add(i * 5);
			}
		}


		private Command<int> selectCmd;
		public Command<int> SelectCommand
		{
			get
			{
				this.selectCmd = this.selectCmd ?? new Command<int>(s =>
					 MessagingCenter.Send(this, "CountChanged", s));
				return this.selectCmd;
			}
		}
	}
}
