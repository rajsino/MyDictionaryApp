#region FileHeader
// ***********************************************************************
// Assembly         : MyDictionary
// Author           : Sino Raj
// Created          : 27-08-2017
//
// ***********************************************************************
// <copyright file="BaseViewModel.cs" company="Dreamz">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
#endregion
using System.Threading.Tasks;

namespace MyDictionary.ViewModels
{
	public class BaseViewModel : ViewModelBase
	{
		private MasterViewModel _masterViewModel;

		public MasterViewModel MasterViewModel
		{
			get
			{
				return _masterViewModel;
			}

			set
			{
				_masterViewModel = value;
				RaisePropertyChanged(() => MasterViewModel);
			}
		}

		public BaseViewModel(MasterViewModel masterViewModel)
		{
			_masterViewModel = masterViewModel;
		}

		public override Task InitializeAsync(object navigationData)
		{
			return Task.WhenAll
			(
				_masterViewModel.InitializeAsync(navigationData),
				NavigationService.NavigateToAsync<HomePageViewModel>()
			);
		}
	}
}