using Xamarin.Forms;

namespace MyDictionary.Pages
{
	public partial class CustomNavigationPage : NavigationPage
	{
		public CustomNavigationPage()
		{
			InitializeComponent();
		}

		public CustomNavigationPage(Page root) : base(root)
        {
			InitializeComponent();
			BarBackgroundColor = Color.FromHex("#0aca91");
			BarTextColor = Color.White;
		}
	}
}
