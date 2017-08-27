#region FileHeader
// ***********************************************************************
// Assembly         : MyDictionary
// Author           : Sino Raj
// Created          : 20-08-2017
//
// ***********************************************************************
// <copyright file="AuthenticationService.cs" company="Xebia">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
#endregion
using System;
using System.Threading.Tasks;
using MyDictionary.Components.Helpers;
using MyDictionary.Components.Interfaces;
using MyDictionary.Components.Models.User;
using MyDictionary.Components.Utils;

namespace MyDictionary.API.DataServices
{
	public class AuthenticationService : IAuthenticationService
	{
		#region DECLARATIONS
		/// <summary>
		/// The request provider.
		/// </summary>
		private readonly IRequestProvider _requestProvider;
		/// <summary>
		/// Gets a value indicating whether this <see cref="T:MyDictionary.API.DataServices.AuthenticationService"/> is authenticated.
		/// </summary>
		/// <value><c>true</c> if is authenticated; otherwise, <c>false</c>.</value>
		public bool IsAuthenticated => !string.IsNullOrEmpty(Settings.AccessToken);
		#endregion

		#region CTOR
		/// <summary>
		/// Initializes a new instance of the <see cref="T:MyDictionary.API.DataServices.AuthenticationService"/> class.
		/// </summary>
		/// <param name="requestProvider">Request provider.</param>
		public AuthenticationService(IRequestProvider requestProvider)
		{
			_requestProvider = requestProvider;
		}
		#endregion

		#region LOGIN
		/// <summary>
		/// Logins the async.
		/// </summary>
		/// <returns>The async.</returns>
		/// <param name="userName">User name.</param>
		/// <param name="password">Password.</param>
		public async Task<bool> LoginAsync(string userName, string password)
		{
			var auth = new AuthenticationRequest
			{
				UserName = userName,
				Credentials = password,
				GrantType = "password"
			};

			UriBuilder builder = new UriBuilder(GlobalSettings.AuthenticationEndpoint);
			builder.Path = "api/login";

			string uri = builder.ToString();

			AuthenticationResponse authenticationInfo = await _requestProvider.PostAsync<AuthenticationRequest, AuthenticationResponse>(uri, auth);
			Settings.UserId = authenticationInfo.UserId;
			Settings.ProfileId = authenticationInfo.ProfileId;
			Settings.AccessToken = authenticationInfo.AccessToken;

			return true;
		}
		#endregion

		#region CLEAR DATA WHEN LOGOUT
		/// <summary>
		/// Logouts the async.
		/// </summary>
		/// <returns>The async.</returns>
		public Task LogoutAsync()
		{
			Settings.RemoveUserId();
			Settings.RemoveProfileId();
			Settings.RemoveAccessToken();

			Settings.RemovePrimaryLanguage();
			Settings.RemoveSecondaryLanguage();
			Settings.RemoveNoOfQuestions();

			Settings.RemoveTestResult();

			return Task.FromResult(false);
		}
		#endregion

		#region GET CURRENT USER ID
		/// <summary>
		/// Gets the current user identifier.
		/// </summary>
		/// <returns>The current user identifier.</returns>
		public int GetCurrentUserId()
		{
			return Settings.UserId;
		}
		#endregion
	}
}
