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
	public interface IRequestProvider
	{
		#region METHODS
		/// <summary>
		/// Gets the async.
		/// </summary>
		/// <returns>The async.</returns>
		/// <param name="uri">URI.</param>
		/// <typeparam name="TResult">The 1st type parameter.</typeparam>
		Task<TResult> GetAsync<TResult>(string uri);
		/// <summary>
		/// Posts the async.
		/// </summary>
		/// <returns>The async.</returns>
		/// <param name="uri">URI.</param>
		/// <param name="data">Data.</param>
		/// <typeparam name="TResult">The 1st type parameter.</typeparam>
		Task<TResult> PostAsync<TResult>(string uri, TResult data);
		/// <summary>
		/// Posts the async.
		/// </summary>
		/// <returns>The async.</returns>
		/// <param name="uri">URI.</param>
		/// <param name="data">Data.</param>
		/// <typeparam name="TRequest">The 1st type parameter.</typeparam>
		/// <typeparam name="TResult">The 2nd type parameter.</typeparam>
		Task<TResult> PostAsync<TRequest, TResult>(string uri, TRequest data);
		/// <summary>
		/// Puts the async.
		/// </summary>
		/// <returns>The async.</returns>
		/// <param name="uri">URI.</param>
		/// <param name="data">Data.</param>
		/// <typeparam name="TResult">The 1st type parameter.</typeparam>
		Task<TResult> PutAsync<TResult>(string uri, TResult data);
		/// <summary>
		/// Puts the async.
		/// </summary>
		/// <returns>The async.</returns>
		/// <param name="uri">URI.</param>
		/// <param name="data">Data.</param>
		/// <typeparam name="TRequest">The 1st type parameter.</typeparam>
		/// <typeparam name="TResult">The 2nd type parameter.</typeparam>
		Task<TResult> PutAsync<TRequest, TResult>(string uri, TRequest data);
		#endregion
	}
}
