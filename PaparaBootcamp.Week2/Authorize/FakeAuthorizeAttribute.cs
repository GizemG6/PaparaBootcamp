using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PaparaBootcamp.Week2.Services;
using System.Text;

namespace PaparaBootcamp.Week2.Authorize
{
	// this method is called during the authorization process.
	// it checks whether the request contains a valid authorization token.
	public class FakeAuthorizeAttribute : Attribute, IAuthorizationFilter
	{
		public void OnAuthorization(AuthorizationFilterContext context)
		{
			// retrieve the 'Authorization' header from the request
			var token = context.HttpContext.Request.Headers["Authorization"].FirstOrDefault();

			// if the token is missing or invalid, return an unauthorized response
			if (string.IsNullOrEmpty(token) || !FakeAuthService.ValidateToken(token))
			{
				context.Result = new UnauthorizedObjectResult(new { message = "Unauthorized access" });
			}
		}
	}
}
