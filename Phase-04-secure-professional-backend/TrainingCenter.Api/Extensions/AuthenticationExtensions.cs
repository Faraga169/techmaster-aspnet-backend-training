using System.Text;
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
                          });

            services.AddAuthorization();

            return services;

        }
    }
}
