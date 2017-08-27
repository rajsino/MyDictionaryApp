using System.Threading.Tasks;
using MyDictionary.Components.Interfaces;
using MyDictionary.Services;

namespace MyDictionary.ViewModels
{
	public abstract class ViewModelBase : ExtendedBindableObject
	{
		protected readonly IDialogService DialogService;
		protected readonly INavigationService NavigationService;

		private bool _isBusy;

		public bool IsBusy
		{
			get
			{
				return _isBusy;
			}

			set
			{
				_isBusy = value;
				RaisePropertyChanged(() => IsBusy);
			}
		}

		public ViewModelBase()
		{
			DialogService = ViewModelLocator.Instance.Resolve<IDialogService>();
			NavigationService = ViewModelLocator.Instance.Resolve<INavigationService>();
		}

		public virtual Task InitializeAsync(object navigationData)
		{
			return Task.FromResult(false);
		}
	}
}
