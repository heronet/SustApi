using SustApi.Utils;

namespace SustApi.Extensions;

public static class CorsExtension
{
    public static IServiceCollection AddCorsConfiguration(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy(Constants.CORS_POLICY, policy =>
            {
                policy.AllowAnyHeader()
                    .AllowAnyMethod()
                    // .WithOrigins(
                    //     Environment.GetEnvironmentVariable("CORS_ORIGIN_PRIMARY")!,
                    //     Environment.GetEnvironmentVariable("CORS_ORIGIN_SECONDARY")!
                    // )
                    // .AllowCredentials()
                    .AllowAnyOrigin();
            });
        });
        return services;
    }
}
