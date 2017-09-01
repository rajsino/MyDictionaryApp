#region FileHeader
// ***********************************************************************
// Assembly         : MyDictionary
// Author           : Sino Raj
// Created          : 19-08-2017
//
// ***********************************************************************
// <copyright file="AuthenticationRequest.cs" company="Dreamz">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
#endregion

namespace MyDictionary.Components.Models.User
{
	public class AuthenticationRequest
	{
		#region PROPERTIES
		/// <summary>
		/// Gets or sets the name of the user.
		/// </summary>
		/// <value>The name of the user.</value>
		public string UserName { get; set; }
		/// <summary>
		/// Gets or sets the credentials.
		/// </summary>
		/// <value>The credentials.</value>
		public string Credentials { get; set; }
		/// <summary>
		/// Gets or sets the type of the grant.
		/// </summary>
		/// <value>The type of the grant.</value>
		public string GrantType { get; set; }
		#endregion
	}
}
