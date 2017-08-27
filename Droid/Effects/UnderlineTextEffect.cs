using System;
using Android.Widget;
using MyDictionary.Droid.Effects;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportEffect(typeof(UnderlineTextEffect), "UnderlineTextEffect")]
namespace MyDictionary.Droid.Effects
{
	public class UnderlineTextEffect : PlatformEffect
	{
		protected override void OnAttached()
		{
			var label = Control as TextView;

			if (label != null)
			{
				label.PaintFlags |= Android.Graphics.PaintFlags.UnderlineText;
			}
		}

		protected override void OnDetached()
		{
		}
	}
}
