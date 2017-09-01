#region FileHeader
// ***********************************************************************
// Assembly         : MyDictionary
// Author           : Sino Raj
// Created          : 27-08-2017
//
// ***********************************************************************
// <copyright file="MaxLinesEffect.cs" company="Dreamz">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
#endregion
using System.ComponentModel;
using MyDictionary.Effects;
using MyDictionary.iOS;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportEffect(typeof(MaxLinesEffect), "MaxLinesEffect")]
namespace MyDictionary.iOS
{
	public class MaxLinesEffect : PlatformEffect
	{
		UILabel _control;

		protected override void OnAttached()
		{
			_control = Control as UILabel;
			SetMaxLines();
		}

		protected override void OnDetached()
		{
		}

		protected override void OnElementPropertyChanged(PropertyChangedEventArgs args)
		{
			if (args.PropertyName == NumberOfLinesEffect.NumberOfLinesProperty.PropertyName)
			{
				SetMaxLines();
			}
		}

		private void SetMaxLines()
		{
			var maxLines = NumberOfLinesEffect.GetNumberOfLines(Element);

			if (_control != null)
			{
				_control.Lines = maxLines;
			}
		}
	}
}
