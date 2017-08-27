using System.Threading.Tasks;

namespace MyDictionary.Components.Interfaces
{
	public interface IDialogService
	{
		Task ShowAlertAsync(string message, string title, string buttonLabel);
	}
}
