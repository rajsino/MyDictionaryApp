using System.Threading.Tasks;
using MyDictionary.Components.Models.Users;

namespace MyDictionary.Components.Interfaces
{
	public interface IProfileService
	{
		Task<UserProfile> GetCurrentProfileAsync();

		Task<UserAndProfileModel> SignUp(UserAndProfileModel profile);
	}
}
