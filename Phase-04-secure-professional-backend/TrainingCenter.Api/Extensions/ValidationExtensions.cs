using Microsoft.AspNetCore.Mvc;
using TrainingCenter.BLL.Common;

namespace TrainingCenter.Api.Extensions
{
    public static class ValidationExtensions
    {
        public static IServiceCollection AddCustomValidation(this IServiceCollection services)
        {
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = context =>
                {
                    var errors = context.ModelState
                        .Where(x => x.Value?.Errors.Count > 0)
                        .ToDictionary(
                            x => x.Key,
                            x => x.Value!.Errors
                                .Select(e => e.ErrorMessage)
                                .ToArray());

                    var response = new ValidationErrorResponse()
                    {
                        Success = false,
                        Message = "Validation failed.",
                        StatusCode = 400,
                        Errors = errors
                    };

                    return new BadRequestObjectResult(response);
                };
            });

            return services;
        }
    }
}
