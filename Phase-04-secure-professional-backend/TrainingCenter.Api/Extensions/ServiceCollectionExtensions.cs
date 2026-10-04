using Microsoft.EntityFrameworkCore;
using TrainingCenter.BLL;
using TrainingCenter.BLL.Services.Implementation;
using TrainingCenter.BLL.Services.Interface;
using TrainingCenter.DAL.Persistent;
using TrainingCenter.DAL.Repositories.Implementations;
using TrainingCenter.DAL.Repositories.Interfaces;

namespace TrainingCenter.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Database
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection")));

            services.AddCors(options =>
            {
                options.AddPolicy("AllowFrontend", policy =>
                {
                    policy
                        .WithOrigins(
                            "http://localhost:4200",
                            "https://your-frontend-domain.com"
                        )
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });

            // Infrastructure
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IReportRepository, ReportRepository>();

            // Application Services
            services.AddScoped<ITrackService, TrackService>();
            services.AddScoped<IActivityLogService, ActivityLogService>();
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<IReportService, ReportService>();
            services.AddScoped<IEnrollmentService, EnrollmentService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<ITrackSession, TrackSessionService>();
            services.AddScoped<IInstrcutorService, InstructorService>();
            services.AddScoped<IPaymentService, PaymentService>();

            // HttpContext
            services.AddHttpContextAccessor();

            // AutoMapper
            services.AddAutoMapper(cfg => { },typeof(AssemblyBLL).Assembly);

            return services;
        }
    }
}
