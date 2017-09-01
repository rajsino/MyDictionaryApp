#region FileHeader
// ***********************************************************************
// Assembly         : MyDictionary
// Author           : Sino Raj
// Created          : 27-08-2017
//
// ***********************************************************************
// <copyright file="MyProfileViewModel.cs" company="Dreamz">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
#endregion
using System;
using System.Diagnostics;
using System.Globalization;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using MyDictionary.Components.Interfaces;
using MyDictionary.Components.Models.Users;

namespace MyDictionary.ViewModels
{
	public class MyProfileViewModel : ViewModelBase
	{
		private readonly IProfileService _profileService;
		private UserProfile profile;

		public UserProfile Profile
		{
			get
			{
				return profile;
			}

			set
			{
				profile = value;
			}
		}

		private string fullName = "Name";

		public string FullName
		{
			get
			{
				return fullName;
			}

			set
			{
				fullName = value;
				RaisePropertyChanged(() => FullName);
			}
		}

		private string emailID = "test@gmail.com";

		public string EmailID
		{
			get
			{
				return emailID;
			}

			set
			{
				emailID = value;
				RaisePropertyChanged(() => EmailID);
			}
		}

		private string dob = "10/10/2000";

		public string DOB
		{
			get
			{
				return dob;
			}

			set
			{
				dob = value;
				RaisePropertyChanged(() => DOB);
			}
		}

		public MyProfileViewModel(IProfileService profileService)
		{
			_profileService = profileService;
		}

		public override async Task InitializeAsync(object navigationData)
		{
			IsBusy = true;
			try
			{
				Profile = await _profileService.GetCurrentProfileAsync();

				FullName = Profile.FirstName.Trim() + " " + Profile.LastName.Trim();
				EmailID = Profile.Email;
				DOB = Profile.BirthDate.Value.ToString("dd/MM/yyyy"); 
			}
			catch (Exception ex) when (ex is WebException || ex is HttpRequestException)
			{
				await DialogService.ShowAlertAsync("Communication error", "Error", "Ok");
			}
			catch (Exception ex)
			{
				await DialogService.ShowAlertAsync("Unknown error" + ex.ToString(), "Error", "Ok");
				Debug.WriteLine($"Error fetching profile with exception: {ex}");
			}
			IsBusy = false;
		}
	}
}
