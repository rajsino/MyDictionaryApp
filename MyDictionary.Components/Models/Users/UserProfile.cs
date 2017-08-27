using System;

namespace MyDictionary.Components.Models.Users
{
	public class UserProfile
	{
		public int Id { get; set; }
		public int UserId { get; set; }

		public User User { get; set; }
		public string Gender { get; set; }
		public DateTime? BirthDate { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }

		public string Email { get; set; }

		public string Mobile { get; set; }
	}
}
