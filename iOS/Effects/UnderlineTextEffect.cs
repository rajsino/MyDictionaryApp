#region FileHeader
// ***********************************************************************
// Assembly         : MyDictionary
// Author           : Sino Raj
// Created          : 27-08-2017
//
// ***********************************************************************
// <copyright file="UnderlineTextEffect.cs" company="Xebia">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
#endregion
using Foundation;
using MyDictionary.Effects;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportEffect(typeof(UnderlineTextEffect), "UnderlineTextEffect")]
namespace MyDictionary.iOS
{
	public class UnderlineTextEffect : PlatformEffect
	{
		protected override void OnAttached()
		{
			var label = Control as UILabel;
			var element = Element as Label;

			if (label != null && element != null)
			{
				var attributes = new UIStringAttributes { UnderlineStyle = NSUnderlineStyle.Single };
				var attrString = new NSAttributedString(element.Text, attributes);
				label.AttributedText = attrString;
			}
		}

		protected override void OnDetached()
		{
		}
	}
}
