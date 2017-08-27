#region FileHeader
// ***********************************************************************
// Assembly         : MyDictionary
// Author           : Sino Raj
// Created          : 19-08-2017
//
// ***********************************************************************
// <copyright file="GlobalSettings.cs" company="Xebia">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
#endregion

namespace MyDictionary.Components.Utils
{
	public class GlobalSettings
	{
		#region WEB SERVICE END POINTS
		/// <summary>
		/// The authentication endpoint.
		/// </summary>
		public const string AuthenticationEndpoint = "http://mydictionaryapp.azurewebsites.net/";
		#endregion

		#region HOCKEY APP IDS
		/// <summary>
		/// The hockey app APIK ey for android.
		/// </summary>
		public const string HockeyAppAPIKeyForAndroid = "f43a511316664285a378bfafa0c53228";
		/// <summary>
		/// The hockey app APIK ey fori os.
		/// </summary>
		public const string HockeyAppAPIKeyForiOS = "33be7dd329f44c40931ae053c29d5b63";
		#endregion

		#region TENAT ID
		/// <summary>
		/// The tenant identifier.
		/// </summary>
		public static int TenantId = 1;
		#endregion
	}
}
