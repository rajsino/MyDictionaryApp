using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyDictionary.Pages
{
	[XamlCompilation(XamlCompilationOptions.Skip)]
	public partial class LoginPage : ContentPage
	{
		public LoginPage()
		{
			NavigationPage.SetHasNavigationBar(this, false);
			InitializeComponent();
		}

		protected override void OnBindingContextChanged()
		{
			base.OnBindingContextChanged();
		}
	}
}
