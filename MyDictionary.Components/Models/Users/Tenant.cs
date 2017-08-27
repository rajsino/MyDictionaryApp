using System.Collections.Generic;

namespace MyDictionary.Components.Models.Users
{
	public class Tenant
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public IEnumerable<User> Users { get; set; }
	}
}
