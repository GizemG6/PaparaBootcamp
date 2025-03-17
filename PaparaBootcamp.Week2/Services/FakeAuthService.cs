using PaparaBootcamp.Week2.Entity;
using System.Collections.Generic;

namespace PaparaBootcamp.Week2.Services
{
	public class FakeAuthService
	{
		// a static list of fake users with their respective tokens
		private static List<(string Username, string Token)> fakeUsers = new()
	    {
			("admin", "admin-token"),
			("user", "user-token")
		};

		// validates if the provided token exists in the fake users list.
		public static bool ValidateToken(string token)
		{
			return fakeUsers.Any(user => user.Token == token);
		}
	}
}
