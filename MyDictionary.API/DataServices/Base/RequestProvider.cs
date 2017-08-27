#region FileHeader
// ***********************************************************************
// Assembly         : MyDictionary
// Author           : Sino Raj
// Created          : 20-08-2017
//
// ***********************************************************************
// <copyright file="RequestProvider.cs" company="Xebia">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
#endregion

using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using MyDictionary.API.Exceptions;
using MyDictionary.Components.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace MyDictionary.API.DataServices
{
	public class RequestProvider : IRequestProvider
	{
		#region DECLARATIONS
		/// <summary>
		/// The serializer settings.
		/// </summary>
		private readonly JsonSerializerSettings _serializerSettings;
		#endregion

		#region CTOR
		/// <summary>
		/// Initializes a new instance of the <see cref="T:MyDictionary.API.DataServices.RequestProvider"/> class.
		/// </summary>
		public RequestProvider()
		{
			_serializerSettings = new JsonSerializerSettings
			{
				ContractResolver = new CamelCasePropertyNamesContractResolver(),
				DateTimeZoneHandling = DateTimeZoneHandling.Utc,
				NullValueHandling = NullValueHandling.Ignore
			};

			_serializerSettings.Converters.Add(new StringEnumConverter());
		}
		#endregion

		#region GET ASYNC
		public async Task<TResult> GetAsync<TResult>(string uri)
		{
			HttpClient httpClient = CreateHttpClient();
			HttpResponseMessage response = await httpClient.GetAsync(uri);

			await HandleResponse(response);

			string serialized = await response.Content.ReadAsStringAsync();
			TResult result = await Task.Run(() => JsonConvert.DeserializeObject<TResult>(serialized, _serializerSettings));

			return result;
		}
		#endregion

		#region POST ASYNC
		/// <summary>
		/// Posts the async.
		/// </summary>
		/// <returns>The async.</returns>
		/// <param name="uri">URI.</param>
		/// <param name="data">Data.</param>
		/// <typeparam name="TResult">The 1st type parameter.</typeparam>
		public Task<TResult> PostAsync<TResult>(string uri, TResult data)
		{
			return PostAsync<TResult, TResult>(uri, data);
		}
		#endregion

		#region DO POST ASYNC
		/// <summary>
		/// Posts the async.
		/// </summary>
		/// <returns>The async.</returns>
		/// <param name="uri">URI.</param>
		/// <param name="data">Data.</param>
		/// <typeparam name="TRequest">The 1st type parameter.</typeparam>
		/// <typeparam name="TResult">The 2nd type parameter.</typeparam>
		public async Task<TResult> PostAsync<TRequest, TResult>(string uri, TRequest data)
		{
			HttpClient httpClient = CreateHttpClient();
			string serialized = await Task.Run(() => JsonConvert.SerializeObject(data, _serializerSettings));
			HttpResponseMessage response = await httpClient.PostAsync(uri, new StringContent(serialized, Encoding.UTF8, "application/json"));

			await HandleResponse(response);

			string responseData = await response.Content.ReadAsStringAsync();

			return await Task.Run(() => JsonConvert.DeserializeObject<TResult>(responseData, _serializerSettings));
		}
		#endregion

		#region PUST ASYNC
		/// <summary>
		/// Puts the async.
		/// </summary>
		/// <returns>The async.</returns>
		/// <param name="uri">URI.</param>
		/// <param name="data">Data.</param>
		/// <typeparam name="TResult">The 1st type parameter.</typeparam>
		public Task<TResult> PutAsync<TResult>(string uri, TResult data)
		{
			return PutAsync<TResult, TResult>(uri, data);
		}
		#endregion

		#region PUT ASYNC
		/// <summary>
		/// Puts the async.
		/// </summary>
		/// <returns>The async.</returns>
		/// <param name="uri">URI.</param>
		/// <param name="data">Data.</param>
		/// <typeparam name="TRequest">The 1st type parameter.</typeparam>
		/// <typeparam name="TResult">The 2nd type parameter.</typeparam>
		public async Task<TResult> PutAsync<TRequest, TResult>(string uri, TRequest data)
		{
			HttpClient httpClient = CreateHttpClient();
			string serialized = await Task.Run(() => JsonConvert.SerializeObject(data, _serializerSettings));
			HttpResponseMessage response = await httpClient.PutAsync(uri, new StringContent(serialized, Encoding.UTF8, "application/json"));

			await HandleResponse(response);

			string responseData = await response.Content.ReadAsStringAsync();

			return await Task.Run(() => JsonConvert.DeserializeObject<TResult>(responseData, _serializerSettings));
		}
		#endregion

		#region CREATE HTTP CLIENT
		/// <summary>
		/// Creates the http client.
		/// </summary>
		/// <returns>The http client.</returns>
		private HttpClient CreateHttpClient()
		{
			var httpClient = new HttpClient();

			httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

			return httpClient;
		}
		#endregion

		#region HANDLE RESPONSE
		/// <summary>
		/// Handles the response.
		/// </summary>
		/// <returns>The response.</returns>
		/// <param name="response">Response.</param>
		private async Task HandleResponse(HttpResponseMessage response)
		{
			if (!response.IsSuccessStatusCode)
			{
				var content = await response.Content.ReadAsStringAsync();

				if (response.StatusCode == HttpStatusCode.Forbidden || response.StatusCode == HttpStatusCode.Unauthorized)
				{
					throw new ServiceAuthenticationException(content);
				}

				throw new HttpRequestException(content);
			}
		}
		#endregion
	}
}
