#region FileHeader
// ***********************************************************************
// Assembly         : MyDictionary
// Author           : Sino Raj
// Created          : 27-08-2017
//
// ***********************************************************************
// <copyright file="CustomListView.cs" company="Xebia">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
#endregion
using System.Windows.Input;
using Xamarin.Forms;

namespace MyDictionary.Controls
{
	public class CustomListView : ListView
	{
		public static BindableProperty ItemClickCommandProperty = BindableProperty.Create<CustomListView, ICommand>
			(x => x.ItemClickCommand, null);


		public CustomListView()
		{
			this.ItemTapped += this.OnItemTapped;
		}


		public ICommand ItemClickCommand
		{
			get { return (ICommand)this.GetValue(ItemClickCommandProperty); }
			set { this.SetValue(ItemClickCommandProperty, value); }
		}


		private void OnItemTapped(object sender, ItemTappedEventArgs e)
		{
			if (e.Item != null && this.ItemClickCommand != null && this.ItemClickCommand.CanExecute(e))
			{
				this.ItemClickCommand.Execute(e.Item);
				this.SelectedItem = null;
			}
		}
	}
}
