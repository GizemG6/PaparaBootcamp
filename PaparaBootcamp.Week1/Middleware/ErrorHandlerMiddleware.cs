using Newtonsoft.Json;

namespace PaparaBootcamp.Week1.Middleware
{
	public class ErrorHandlerMiddleware
	{
		private readonly RequestDelegate _next;

		public ErrorHandlerMiddleware(RequestDelegate next)
		{
			_next = next;
		}

		public async Task Invoke(HttpContext context)
		{
			try
			{
				await _next(context);
			}
			catch (Exception ex)
			{
				context.Response.ContentType = "application/json";
				context.Response.StatusCode = 500;

				await context.Response.WriteAsync(JsonConvert.SerializeObject(new
				{
					status = 500,
					message = "An unexpected error occurred",
					details = ex.Message
				}));
			}
		}
	}
}
