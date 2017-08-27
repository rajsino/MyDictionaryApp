using Xamarin.Forms;

namespace MyDictionary.Pages
{
	public partial class HomePage : ContentPage
	{
		public HomePage()
		{
			InitializeComponent();

			if (Device.RuntimePlatform.Equals(Device.iOS))
				Title = "Home";
		}

		protected override void OnSizeAllocated(double width, double height)
		{
			base.OnSizeAllocated(width, height);
			stackWordWrapper.WidthRequest = width;
		}
	}
}