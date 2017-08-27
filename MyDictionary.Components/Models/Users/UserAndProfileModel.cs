using System;
namespace MyDictionary.Components.Models.Users
{
	public class UserAndProfileModel
	{
		public string UserName { get; set; }
		public string Password { get; set; }
		public string Gender { get; set; }
		public DateTime? BirthDate { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }

		public string Email { get; set; }

		public int TenantId { get; set; }
	}
}
