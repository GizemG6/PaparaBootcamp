using PaparaBootcamp.Week2.Middleware;
using System;

namespace PaparaBootcamp.Week2
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			builder.Services.AddControllers();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

			// added middleware (global exception and global logging)
			app.UseMiddleware<ExceptionMiddleware>();

			app.UseAuthorization();

			app.MapControllers();

			app.Run();
		}
	}
}
