
using DotNetEmpWebAPI.Models;
using DotNetEmpWebAPI.Repository;
using DotNetEmpWebAPI.Services;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace DotNetEmpWebAPI
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

			builder.Services.AddControllers();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			// The below lines before builder.Build() are the ones I added:

			builder.Services.AddDbContext<EmpDbContext>(options =>
				options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
			
			builder.Services.AddScoped<IEmpRepo<EmpTable>, EmpRepo>();
			builder.Services.AddScoped<IEmpService<EmpTable>, EmpService>();
			
			builder.Services.AddScoped<IDeptRepo<DeptTable>, DeptRepo>();
			builder.Services.AddScoped<IDeptService<DeptTable>, DeptService>();

			builder.Services.AddCors(); //Cross Origin Resource Sharing

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			// The UseCors() is also the one I added
			app.UseCors(options => options.WithOrigins("http://localhost:4200/").AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin());

			app.UseHttpsRedirection();

			app.UseAuthorization();


			app.MapControllers();

			app.Run();
		}
	}
}
