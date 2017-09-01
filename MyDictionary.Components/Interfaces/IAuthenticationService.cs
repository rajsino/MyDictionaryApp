#region FileHeader
// ***********************************************************************
// Assembly         : MyDictionary
// Author           : Sino Raj
// Created          : 19-08-2017
//
// ***********************************************************************
// <copyright file="IAuthenticationService.cs" company="Dreamz">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
#endregion

using System.Threading.Tasks;

namespace MyDictionary.Components.Interfaces
{
	public interface IAuthenticationService
	{
		#region METHODS
		/// <summary>
		/// Gets a value indicating whether this <see cref="T:MyDictionary.Components.Interfaces.IAuthenticationService"/> is authenticated.
		/// </summary>
		/// <value><c>true</c> if is authenticated; otherwise, <c>false</c>.</value>
		bool IsAuthenticated { get; }
		/// <summary>
		/// Gets the current user identifier.
		/// </summary>
		/// <returns>The current user identifier.</returns>
		int GetCurrentUserId();
		/// <summary>
		/// Logins the async.
		/// </summary>
		/// <returns>The async.</returns>
		/// <param name="userName">User name.</param>
		/// <param name="password">Password.</param>
		Task<bool> LoginAsync(string userName, string password);
		/// <summary>
		/// Logouts the async.
		/// </summary>
		/// <returns>The async.</returns>
		Task LogoutAsync();
		#endregion
	}
}
