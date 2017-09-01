#region FileHeader
// ***********************************************************************
// Assembly         : MyDictionary
// Author           : Sino Raj
// Created          : 20-08-2017
//
// ***********************************************************************
// <copyright file="CustomProgressBarRenderer.cs" company="Dreamz">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
#endregion
using System;
using MyDictionary.Controls;
using MyDictionary.Droid.Renders;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomProgressBar), typeof(CustomProgressBarRenderer))]
namespace MyDictionary.Droid.Renders
{
	public class CustomProgressBarRenderer : ProgressBarRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<ProgressBar> e)
		{
			base.OnElementChanged(e);
			try
			{
				Control.ProgressDrawable.SetColorFilter(Color.DarkBlue.ToAndroid(), Android.Graphics.PorterDuff.Mode.SrcIn);
				Control.ProgressTintList = Android.Content.Res.ColorStateList.ValueOf(Color.DarkBlue.ToAndroid());
			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(ex.Message);
			}
		}
	}
}
