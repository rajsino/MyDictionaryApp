#region FileHeader
// ***********************************************************************
// Assembly         : MyDictionary
// Author           : Sino Raj
// Created          : 20-08-2017
//
// ***********************************************************************
// <copyright file="MainActivity.cs" company="Dreamz">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
#endregion

using Android.App;
using Android.Content.PM;
using Android.OS;
using Acr.UserDialogs;

namespace MyDictionary.Droid
{
	[Activity(Label = "MyDictionary",
			  Icon = "@drawable/ic_launcher",
			  Theme = "@style/MainTheme",
	          ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation,
	          ScreenOrientation=ScreenOrientation.SensorPortrait)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			TabLayoutResource = Resource.Layout.Tabbar;
			ToolbarResource = Resource.Layout.Toolbar;

			base.OnCreate(savedInstanceState);

			global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

			UserDialogs.Init(this);

            LoadApplication(new App());
		}
	}
}
