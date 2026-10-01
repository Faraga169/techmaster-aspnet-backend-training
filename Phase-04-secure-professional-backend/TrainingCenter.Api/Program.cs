
using System.Text;
using System.Text.Json.Serialization;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using StudentManagementAPI.Middleware;
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

            builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<ITrackService, TrackService>();
            builder.Services.AddScoped<IStudentService, StudentService>();
            builder.Services.AddScoped<IReportService, ReportService>();
            builder.Services.AddScoped<IEnrollmentService, EnrollmentService>();
            builder.Services.AddScoped<IAuthenticationService,AuthenticationService>();
            builder.Services.AddScoped<IInstrcutorService, InstructorService>();
            builder.Services.AddScoped<IPaymentService, PaymentService>();
            builder.Services.AddScoped<IReportRepository,ReportRepository>();
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddIdentityCore<ApplicationUser>()
                            .AddRoles<IdentityRole>()
                            .AddEntityFrameworkStores<AppDbContext>();

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                          .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,

            ValidIssuer = builder.Configuration["JWT:Issuer"],
            ValidAudience = builder.Configuration["JWT:Audience"],

            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]!))
        };
    });

            builder.Services.AddAutoMapper(
    cfg => { },typeof(AssemblyBLL).Assembly);
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

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

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
