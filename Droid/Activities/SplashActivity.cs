#region FileHeader
// ***********************************************************************
// Assembly         : MyDictionary
// Author           : Sino Raj
// Created          : 20-08-2017
//
// ***********************************************************************
// <copyright file="MyDictionary.cs" company="Dreamz">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
#endregion

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Support.V7.App;

namespace MyDictionary.Droid
{
	[Activity(
		Label = "MyDictionary",
		Icon = "@drawable/ic_launcher",
		Theme = "@style/Theme.Splash",
		MainLauncher = true,
		NoHistory = true,
		ScreenOrientation = ScreenOrientation.Portrait)]
	public class SplashActivity : AppCompatActivity
	{
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			InvokeMainActivity();
		}

		private void InvokeMainActivity()
		{
			var mIntent = new Intent(this, typeof(MainActivity));
			StartActivity(mIntent);
		}
	}
}
