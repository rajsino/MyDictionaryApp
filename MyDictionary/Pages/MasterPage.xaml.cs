using Xamarin.Forms;

namespace MyDictionary.Pages
{
	public partial class MasterPage : ContentPage
	{
		public MasterPage()
		{
			InitializeComponent();

			if (Device.RuntimePlatform.Equals(Device.iOS))
				Icon = "hamburger.png";
		}
	}
}
