#region FileHeader
// ***********************************************************************
// Assembly         : MyDictionary
// Author           : Sino Raj
// Created          : 27-08-2017
//
// ***********************************************************************
// <copyright file="DatePickerLineColorEffect.cs" company="Dreamz">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
#endregion
using System;
using System.Linq;
using System.ComponentModel;
using CoreGraphics;
using MyDictionary.iOS;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using MyDictionary.Effects;
using CoreAnimation;

[assembly: ExportEffect(typeof(DatePickerLineColorEffect), "DatePickerLineColorEffect")]
namespace MyDictionary.iOS
{
	public class DatePickerLineColorEffect : PlatformEffect
	{
		UITextField control;

		protected override void OnAttached()
		{
			try
			{
				control = Control as UITextField;
				UpdateLineColor();
			}
			catch (Exception ex)
			{
				Console.WriteLine("Cannot set property on attached control. Error: ", ex.Message);
			}
		}

		protected override void OnDetached()
		{
			control = null;
		}

		protected override void OnElementPropertyChanged(PropertyChangedEventArgs args)
		{
			base.OnElementPropertyChanged(args);

			if (args.PropertyName == LineColorEffect.LineColorProperty.PropertyName ||
				args.PropertyName == "Height")
			{
				Initialize();
				UpdateLineColor();
			}
		}

		private void Initialize()
		{
			var datePicker = Element as DatePicker;
			if (datePicker != null)
			{
				Control.Bounds = new CGRect(0, 0, datePicker.Width, datePicker.Height);
			}
		}

		private void UpdateLineColor()
		{
			if (control == null)
				return;

			BorderLineLayer lineLayer = control.Layer.Sublayers.OfType<BorderLineLayer>()
															 .FirstOrDefault();

			if (lineLayer == null)
			{
				lineLayer = new BorderLineLayer();
				lineLayer.MasksToBounds = true;
				lineLayer.BorderWidth = 1.0f;
				control.Layer.AddSublayer(lineLayer);
			}

			lineLayer.Frame = new CGRect(0f, Control.Frame.Height - 1f, Control.Bounds.Width, 1f);
			lineLayer.BorderColor = LineColorEffect.GetLineColor(Element).ToCGColor();
		}

		private class BorderLineLayer : CALayer
		{
		}
	}
}
