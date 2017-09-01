#region FileHeader
// ***********************************************************************
// Assembly         : MyDictionary
// Author           : Sino Raj
// Created          : 27-08-2017
//
// ***********************************************************************
// <copyright file="App.cs" company="Dreamz">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
#endregion
using System.Threading.Tasks;
using System.Linq;
using MyDictionary.Services;
using MyDictionary.ViewModels;
using Xamarin.Forms;
using MyDictionary.Helper;

namespace MyDictionary
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

            AdaptColorsToHexString();
		}

		protected override async void OnStart()
		{
			base.OnStart();

			await InitNavigation();
		}

		private Task InitNavigation()
		{
			var navigationService = ViewModelLocator.Instance.Resolve<INavigationService>();
			return navigationService.InitializeAsync();
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}

		private void AdaptColorsToHexString()
		{
			for (var i = 0; i < this.Resources.Count; i++)
			{
				var key = this.Resources.Keys.ElementAt(i);
				var resource = this.Resources[key];

				if (resource is Color)
				{
					var color = (Color)resource;
					this.Resources.Add(key + "HexString", color.ToHexString());
				}
			}
		}
	}
}
