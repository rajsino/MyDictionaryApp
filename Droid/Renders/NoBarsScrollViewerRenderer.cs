#region FileHeader
// ***********************************************************************
// Assembly         : MyDictionary
// Author           : Sino Raj
// Created          : 20-08-2017
//
// ***********************************************************************
// <copyright file="NoBarsScrollViewerRenderer.cs" company="Xebia">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
#endregion

using System.ComponentModel;
using MyDictionary.Controls;
using MyDictionary.Droid.Renders;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(NoBarsScrollViewer), typeof(NoBarsScrollViewerRenderer))]
namespace MyDictionary.Droid.Renders
{
	public class NoBarsScrollViewerRenderer : ScrollViewRenderer
	{
		protected override void OnElementChanged(VisualElementChangedEventArgs e)
		{
			base.OnElementChanged(e);

			if (e.OldElement != null || this.Element == null)
			{
				return;
			}

			if (e.OldElement != null)
			{
				e.OldElement.PropertyChanged -= OnElementPropertyChanged;
			}

			e.NewElement.PropertyChanged += OnElementPropertyChanged;
		}

		private void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == "ContentSize" && ChildCount > 0)
			{
				Android.Views.View child = GetChildAt(0);
				child.VerticalScrollBarEnabled = false;
				child.HorizontalScrollBarEnabled = false;
			}
		}
	}
}
