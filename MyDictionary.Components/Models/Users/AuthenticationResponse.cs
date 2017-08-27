#region FileHeader
// ***********************************************************************
// Assembly         : MyDictionary
// Author           : Sino Raj
// Created          : 19-08-2017
//
// ***********************************************************************
// <copyright file="AuthenticationResponse.cs" company="Xebia">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
#endregion

namespace MyDictionary.Components.Models.User
{
	public class AuthenticationResponse
	{
		#region PROPERTIES
		/// <summary>
		/// Gets or sets the user identifier.
		/// </summary>
		/// <value>The user identifier.</value>
		public int UserId { get; set; }
		/// <summary>
		/// Gets or sets the profile identifier.
		/// </summary>
		/// <value>The profile identifier.</value>
		public int ProfileId { get; set; }
		/// <summary>
		/// Gets or sets the access token.
		/// </summary>
		/// <value>The access token.</value>
		public string AccessToken { get; set; }
		#endregion
	}
}
