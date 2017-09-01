#region FileHeader
// ***********************************************************************
// Assembly         : MyDictionary
// Author           : Sino Raj
// Created          : 27-08-2017
//
// ***********************************************************************
// <copyright file="AppDelegate.cs" company="Dreamz">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
#endregion
using Foundation;
using UIKit;
using Xamarin.Forms.Platform.iOS;

namespace MyDictionary.iOS
{
	[Register("AppDelegate")]
	public partial class AppDelegate : FormsApplicationDelegate
	{
		UIWindow window = null;
		UIImageView splashImageView = null;

		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
			UIApplication.SharedApplication.SetStatusBarStyle(UIStatusBarStyle.LightContent, false);
            UINavigationBar.Appearance.SetTitleTextAttributes(new UITextAttributes
            {
                TextColor = UIColor.White
            });

            //AddHockeyApp();

            global::Xamarin.Forms.Forms.Init();

			#if ENABLE_TEST_CLOUD
				Xamarin.Calabash.Start();
			#endif

			LoadApplication(new App());

			splashImageView = new UIImageView(UIScreen.MainScreen.Bounds);
			splashImageView.Image = UIImage.FromFile ("Default.png");

            return base.FinishedLaunching(app, options);
		}


		public override void OnResignActivation(UIApplication uiApplication)
		{
			window = uiApplication.KeyWindow;
			window.AddSubview(splashImageView);

			base.OnResignActivation(uiApplication);
		}

		public override void OnActivated(UIApplication uiApplication)
		{
			if (null != splashImageView)
			{
				splashImageView.RemoveFromSuperview();
			}

			base.OnActivated(uiApplication);
		}

		public override UIInterfaceOrientationMask GetSupportedInterfaceOrientations(UIApplication application, UIWindow forWindow)
		{
			return UIInterfaceOrientationMask.Portrait;
		}
	}
}
