using System;
using System.Threading.Tasks;
using MyDictionary.Components.Interfaces;
using MyDictionary.Components.Models.Users;
using MyDictionary.Components.Utils;

namespace MyDictionary.API.DataServices
{
	public class ProfileService : IProfileService
	{
		private readonly IRequestProvider _requestProvider;
		private readonly IAuthenticationService _authenticationService;

		public ProfileService(IRequestProvider requestProvider, IAuthenticationService authenticationService)
		{
			_requestProvider = requestProvider;
			_authenticationService = authenticationService;
		}

		public Task<UserProfile> GetCurrentProfileAsync()
		{
			var userId = _authenticationService.GetCurrentUserId();

			var builder = new UriBuilder(GlobalSettings.AuthenticationEndpoint);
			builder.Path = $"api/Profiles/{userId}";

			var uri = builder.ToString();

			return _requestProvider.GetAsync<UserProfile>(uri);
		}

		public Task<UserAndProfileModel> SignUp(UserAndProfileModel profile)
		{
			var builder = new UriBuilder(GlobalSettings.AuthenticationEndpoint);
			builder.Path = $"api/Profiles/";
			var uri = builder.ToString();

			return _requestProvider.PostAsync(uri, profile);
		}
	}
}