using Azure;
using System.Net;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Reflection.Metadata;

namespace PaparaBootcamp.Week2.Middleware
{
	public class ExceptionMiddleware
	{
		private readonly RequestDelegate _next;
		private readonly ILogger<ExceptionMiddleware> _logger;

		// constructor to initialize the middleware with the next delegate and logger.
		public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
		{
			_next = next;
			_logger = logger;
		}

		// middleware logic that catches unhandled exceptions and processes them.
		public async Task Invoke(HttpContext context)
		{
			try
			{
				await _next(context); // continue to the next middleware
			}
			catch (Exception ex)
			{
				_logger.LogError($"Unhandled exception: {ex.Message}"); // log the error
				await HandleExceptionAsync(context, ex); // handle the exception
			}
		}


		// handles exceptions and returns a JSON response with error details.
		private static Task HandleExceptionAsync(HttpContext context, Exception ex)
		{
			context.Response.ContentType = "application/json";
			context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

			var response = new
			{
				status = context.Response.StatusCode,
				message = "An error occurred while processing your request.",
				detail = ex.Message // include exception details
			};

			return context.Response.WriteAsJsonAsync(response); // return JSON response
		}
	}
}
