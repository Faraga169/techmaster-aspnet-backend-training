
using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using StudentManagementAPI.Middleware;
using TrainingCenter.DAL.Persistent;
using TrainingCenter.DAL.Persistent.Models;

namespace SecurityRefactoringEF
{
    public class Program
    {
        public async static Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Database
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddIdentityCore<ApplicationUser>(options =>
            {
                options.User.AllowedUserNameCharacters =
                    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+ ";
            })
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


                              // Customize Authentication / Authorization responses
                              options.Events = new JwtBearerEvents
                              {
                                  // 401 - Authentication failed
                                  OnChallenge = async context =>
                                  {
                                      context.HandleResponse();

                                      context.Response.StatusCode = StatusCodes.Status401Unauthorized;

                                      context.Response.ContentType = "application/json";

                                      var response = new
                                      {
                                          Success = false,
                                          Message = "Authentication is required.",
                                          StatusCode = StatusCodes.Status401Unauthorized
                                      };

                                      await context.Response.WriteAsync(JsonSerializer.Serialize(response));
                                  },

                                  // 403 - User authenticated but not authorized
                                  OnForbidden = async context =>
                                  {
                                      context.Response.StatusCode = StatusCodes.Status403Forbidden;

                                      context.Response.ContentType = "application/json";

                                      var response = new
                                      {
                                          Success = false,
                                          Message = "You are not authorized to access this resource.",
                                          StatusCode = StatusCodes.Status403Forbidden
                                      };

                                      await context.Response.WriteAsync(JsonSerializer.Serialize(response));
                                  }
                              };
                          });

            builder.Services.AddAuthorization();

            

            var app = builder.Build();

            // Identity Seeding
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                var userManager =
                    services.GetRequiredService<UserManager<ApplicationUser>>();

                var roleManager =
                    services.GetRequiredService<RoleManager<IdentityRole>>();

                await IdentitySeeder.SeedAsync(userManager, roleManager, app.Configuration);
            }

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseMiddleware<ExceptionHandlingMiddleware>();
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
