using System;

namespace MyDictionary.Components.Models.Users
{
	public class User
	{
		public int Id { get; set; }

		public string UserName { get; set; }
		public DateTime LastLogin { get; set; }

		public UserProfile Profile { get; set; }

		public string Password { get; set; }

		public int TenantId { get; set; }
		public string Tenant { get; set; }
	}
}
