using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using TrainingCenter.DAL.Persistent;
using TrainingCenter.DAL.Persistent.Models;

namespace TrainingCenter.Api.Extensions
{
    public static class AuthenticationExtensions
    {
        public static IServiceCollection AddAuthenticationServices(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddIdentityCore<ApplicationUser>()
                               .AddRoles<IdentityRole>()
                               .AddEntityFrameworkStores<AppDbContext>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                          .AddJwtBearer(options =>
                          {
                              options.TokenValidationParameters = new TokenValidationParameters
                              {
                                  ValidateIssuer = true,
                                  ValidateAudience = true,
                                  ValidateLifetime = true,
                                  ValidateIssuerSigningKey = true,

                                  ValidIssuer = configuration["JWT:Issuer"],
                                  ValidAudience =configuration["JWT:Audience"],

                                  IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Key"]!))
                              };


                              // Customize Authentication / Authorization responses
                              options.Events = new JwtBearerEvents
                              {
                                  // 401 - Authentication failed
                                  OnChallenge = async context =>
                                  {
                                      context.HandleResponse();

                                      context.Response.StatusCode =StatusCodes.Status401Unauthorized;

                                      context.Response.ContentType ="application/json";

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
                                      context.Response.StatusCode =StatusCodes.Status403Forbidden;

                                      context.Response.ContentType = "application/json";

                                      var response = new
                                      {
                                          Success = false,
                                          Message = "You are not authorized to access this resource.",
                                          StatusCode = StatusCodes.Status403Forbidden
                                      };

                                      await context.Response.WriteAsync( JsonSerializer.Serialize(response));
                                  }
                              };
                          });

            services.AddAuthorization();

            return services;

        }
    }
}
