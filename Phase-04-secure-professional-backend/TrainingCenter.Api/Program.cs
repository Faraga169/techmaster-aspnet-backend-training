
using System.Text;
using System.Text.Json.Serialization;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using StudentManagementAPI.Middleware;
using TrainingCenter.Api.Extensions;
using TrainingCenter.BLL;
using TrainingCenter.BLL.AutoMapper;
using TrainingCenter.BLL.Services.Implementation;
using TrainingCenter.BLL.Services.Interface;
using TrainingCenter.DAL.Persistent;
using TrainingCenter.DAL.Persistent.Dataseeding;
using TrainingCenter.DAL.Persistent.Models;
using TrainingCenter.DAL.Repositories.Implementations;
using TrainingCenter.DAL.Repositories.Interfaces;

namespace TrainingCenter.Api
{
    public class Program
    {
        public async static Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers()
  .AddJsonOptions(options =>
  {
      options.JsonSerializerOptions.Converters.Add(
          new JsonStringEnumConverter());
  });
            // Custom Validation 
            builder.Services.AddCustomValidation();
            // Application Services
            builder.Services.AddApplicationServices( builder.Configuration);

            // Authentication & Authorization
            builder.Services.AddAuthenticationServices(builder.Configuration);


            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();


            // Identity Seeding
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                var userManager =
                    services.GetRequiredService<UserManager<ApplicationUser>>();

                var roleManager =
                    services.GetRequiredService<RoleManager<IdentityRole>>();

                await IdentitySeeder.SeedAsync(userManager, roleManager);
            }

            // Configure the HTTP request pipeline.
            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseMiddleware<ExceptionHandlingMiddleware>();
            app.UseHttpsRedirection();
            app.UseCors("AllowFrontend");
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
