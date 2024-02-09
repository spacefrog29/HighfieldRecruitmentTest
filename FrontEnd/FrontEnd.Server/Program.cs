using FrontEnd.Server.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

internal class Program
{
	private static void Main(string[] args)
	{
		var builder = WebApplication.CreateBuilder(args);

		builder.Services.AddControllers();
		builder.Services.AddEndpointsApiExplorer();
		builder.Services.AddSwaggerGen();
		builder.Services.AddScoped<IUserEntityService, UserEntityService>();
		builder.Services.AddCors(options =>
		{
			options.AddPolicy(name: "AllowAngularApp",
				builder => builder.WithOrigins("http://localhost:4200")
								  .AllowAnyMethod()
								  .AllowAnyHeader());
		});
		//111122
		var app = builder.Build();

		app.UseDefaultFiles();
		app.UseStaticFiles();
		app.UseCors("AllowAngularApp");

		// Configure the HTTP request pipeline.
		if (app.Environment.IsDevelopment())
		{
			app.UseSwagger();
			app.UseSwaggerUI();
		}

		app.UseHttpsRedirection();

		app.UseAuthorization();

		app.MapControllers();

		app.MapFallbackToFile("/index.html");

		app.Run();
	}
}