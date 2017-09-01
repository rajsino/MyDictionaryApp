#region FileHeader
// ***********************************************************************
// Assembly         : MyDictionary
// Author           : Sino Raj
// Created          : 19-08-2017
//
// ***********************************************************************
// <copyright file="Settings.cs" company="Dreamz">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
#endregion

using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace MyDictionary.Components.Helpers
{
	/// <summary>
	/// This is the Settings static class that can be used in your Core solution or in any
	/// of your client applications. All settings are laid out the same exact way with getters
	/// and setters. 
	/// </summary>
	public static class Settings
	{
		private static ISettings AppSettings
		{
			get
			{
				return CrossSettings.Current;
			}
		}

		#region SETTING CONSTANTS
		/// <summary>
		/// The user identifier key.
		/// </summary>
		private const string UserIdKey = "user_id_key";
		/// <summary>
		/// The user identifier default.
		/// </summary>
		private static readonly int UserIdDefault = 0;

		/// <summary>
		/// The profile identifier key.
		/// </summary>
		private const string ProfileIdKey = "profile_id_key";
		/// <summary>
		/// The profile identifier default.
		/// </summary>
		private static readonly int ProfileIdDefault = 0;

		/// <summary>
		/// The access token key.
		/// </summary>
		private const string AccessTokenKey = "access_token_key";
		/// <summary>
		/// The access token default.
		/// </summary>
		private static readonly string AccessTokenDefault = string.Empty;

		/// <summary>
		/// The primary language key.
		/// </summary>
		private const string PrimaryLanguageKey = "primary_language_key";
		/// <summary>
		/// The primary language default.
		/// </summary>
		private static readonly int PrimaryLanguageDefault = -1;

		/// <summary>
		/// The secondary language key.
		/// </summary>
		private const string SecondaryLanguageKey = "secondary_language_key";
		/// <summary>
		/// The secondary language default.
		/// </summary>
		private static readonly int SecondaryLanguageDefault = -1;

		/// <summary>
		/// The no of questions key.
		/// </summary>
		private const string NoOfQuestionsKey = "no_of_questions_key";
		/// <summary>
		/// The no of questions defult.
		/// </summary>
		private static readonly int NoOfQuestionsDefult = 10;


		/// <summary>
		/// The last attemted dictionary.
		/// </summary>
		private const string LastAttemtedDictionaryKey = "last_attemted_dictionary";
		/// <summary>
		/// The last attemted dictionary default.
		/// </summary>
		private static readonly string LastAttemtedDictionaryDefault = "English to Detch";

		/// <summary>
		/// The test score.
		/// </summary>
		private const string TestScoreKey = "test_result";
		/// <summary>
		/// The test score default.
		/// </summary>
		private static readonly int TestScoreDefault = 0;

		/// <summary>
		/// The test score out of.
		/// </summary>
		private const string TestScoreOutOfKey = "test_result_out_of";
		/// <summary>
		/// The test score out of default.
		/// </summary>
		private static readonly int TestScoreOutOfDefault = 0;
		#endregion

		#region SETTING ACCESSORS
		/// <summary>
		/// Gets or sets the user identifier.
		/// </summary>
		/// <value>The user identifier.</value>
		public static int UserId
		{
			get
			{
				return AppSettings.GetValueOrDefault(UserIdKey, UserIdDefault);
			}
			set
			{
				AppSettings.AddOrUpdateValue(UserIdKey, value);
			}
		}
		/// <summary>
		/// Gets or sets the profile identifier.
		/// </summary>
		/// <value>The profile identifier.</value>
		public static int ProfileId
		{
			get
			{
				return AppSettings.GetValueOrDefault(ProfileIdKey, ProfileIdDefault);
			}
			set
			{
				AppSettings.AddOrUpdateValue(ProfileIdKey, value);
			}
		}
		/// <summary>
		/// Gets or sets the access token.
		/// </summary>
		/// <value>The access token.</value>
		public static string AccessToken
		{
			get
			{
				return AppSettings.GetValueOrDefault(AccessTokenKey, AccessTokenDefault);
			}
			set
			{
				AppSettings.AddOrUpdateValue(AccessTokenKey, value);
			}
		}
		/// <summary>
		/// Gets or sets the primary language.
		/// </summary>
		/// <value>The primary language.</value>
		public static int PrimaryLanguage
		{
			get
			{
				return AppSettings.GetValueOrDefault(PrimaryLanguageKey, PrimaryLanguageDefault);
			}
			set
			{
				AppSettings.AddOrUpdateValue(PrimaryLanguageKey, value);
			}
		}
		/// <summary>
		/// Gets or sets the secondary language.
		/// </summary>
		/// <value>The secondary language.</value>
		public static int SecondaryLanguage
		{
			get
			{
				return AppSettings.GetValueOrDefault(SecondaryLanguageKey, SecondaryLanguageDefault);
			}
			set
			{
				AppSettings.AddOrUpdateValue(SecondaryLanguageKey, value);
			}
		}
		/// <summary>
		/// Gets or sets the no of questions.
		/// </summary>
		/// <value>The no of questions.</value>
		public static int NoOfQuestions
		{
			get
			{
				return AppSettings.GetValueOrDefault(NoOfQuestionsKey, NoOfQuestionsDefult);
			}
			set
			{
				AppSettings.AddOrUpdateValue(NoOfQuestionsKey, value);
			}
		}

		/// <summary>
		/// Gets or sets the last attemted dictionary.
		/// </summary>
		/// <value>The last attemted dictionary.</value>
		public static string LastAttemtedDictionary
		{
			get
			{
				return AppSettings.GetValueOrDefault(LastAttemtedDictionaryKey, LastAttemtedDictionaryDefault);
			}
			set
			{
				AppSettings.AddOrUpdateValue(LastAttemtedDictionaryKey, value);
			}
		}
		/// <summary>
		/// Gets or sets the test score.
		/// </summary>
		/// <value>The test score.</value>
		public static int TestScore
		{
			get
			{
				return AppSettings.GetValueOrDefault(TestScoreKey, TestScoreDefault);
			}
			set
			{
				AppSettings.AddOrUpdateValue(TestScoreKey, value);
			}
		}
		/// <summary>
		/// Gets or sets the test score out of.
		/// </summary>
		/// <value>The test score out of.</value>
		public static int TestScoreOutOf
		{
			get
			{
				return AppSettings.GetValueOrDefault(TestScoreOutOfKey, TestScoreOutOfDefault);
			}
			set
			{
				AppSettings.AddOrUpdateValue(TestScoreOutOfKey, value);
			}
		}
		#endregion

		#region RESET CONSTANTS
		/// <summary>
		/// Removes the user identifier.
		/// </summary>
		public static void RemoveUserId()
		{
			AppSettings.Remove(UserIdKey);
		}
		/// <summary>
		/// Removes the profile identifier.
		/// </summary>
		public static void RemoveProfileId()
		{
			AppSettings.Remove(ProfileIdKey);
		}
		/// <summary>
		/// Removes the access token.
		/// </summary>
		public static void RemoveAccessToken()
		{
			AppSettings.Remove(AccessTokenKey);
		}
		/// <summary>
		/// Removes the primary language.
		/// </summary>
		public static void RemovePrimaryLanguage()
		{
			AppSettings.Remove(PrimaryLanguageKey);
		}
		/// <summary>
		/// Removes the secondary language.
		/// </summary>
		public static void RemoveSecondaryLanguage()
		{
			AppSettings.Remove(SecondaryLanguageKey);
		}
		/// <summary>
		/// Removes the no of questions.
		/// </summary>
		public static void RemoveNoOfQuestions()
		{
			AppSettings.Remove(NoOfQuestionsKey);
		}
		/// <summary>
		/// Removes the primary language.
		/// </summary>
		public static void RemoveTestResult()
		{
			AppSettings.Remove(LastAttemtedDictionaryKey);
			AppSettings.Remove(TestScoreKey);
			AppSettings.Remove(TestScoreOutOfKey);
		}
		#endregion
	}
}