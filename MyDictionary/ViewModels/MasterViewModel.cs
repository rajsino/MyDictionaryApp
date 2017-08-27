#region FileHeader
// ***********************************************************************
// Assembly         : MyDictionary
// Author           : Sino Raj
// Created          : 27-08-2017
//
// ***********************************************************************
// <copyright file="MasterViewModel.cs" company="Xebia">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
#endregion
using System.Windows.Input;
using MyDictionary.Components.Interfaces;
using Xamarin.Forms;

namespace MyDictionary.ViewModels
{
	public class MasterViewModel : ViewModelBase
	{
		private readonly IAuthenticationService _authenticationService;

		public MasterViewModel(IAuthenticationService authenticationService)
		{
			_authenticationService = authenticationService;
		}

		public ICommand MyProfileCommand => new Command(MyProfileAsync);
		public ICommand SettingsCommand => new Command(SettingsAsync);
		public ICommand HelpCommand => new Command(HelpAsync);
		public ICommand AboutUsCommand => new Command(AboutUsAsync);
		public ICommand SignOutCommand => new Command(OnSignout);


		private async void MyProfileAsync()
		{
			await NavigationService.NavigateToAsync<MyProfileViewModel>();
		}

		private async void SettingsAsync()
		{
			await NavigationService.NavigateToAsync<SettingsViewModel>();
		}

		private async void HelpAsync()
		{
			await NavigationService.NavigateToAsync<HelpViewModel>();
		}

		private async void AboutUsAsync()
		{
			await NavigationService.NavigateToAsync<AboutUsViewModel>();
		}

		private async void OnSignout()
		{
			await _authenticationService.LogoutAsync();
			await NavigationService.NavigateToAsync<LoginViewModel>();
		}
	}
}