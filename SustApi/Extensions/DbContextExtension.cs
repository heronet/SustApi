using Microsoft.EntityFrameworkCore;
using SustApi.Data;

namespace SustApi.Extensions;

public static class DbContextExtension
{
    public static IServiceCollection AddDbContext(this IServiceCollection services)
    {
        var uriString = Environment.GetEnvironmentVariable("DATABASE_URL");
        // var uriString = "postgres://sirat:secret@localhost:5432/sustapi";
        var uri = new Uri(uriString);
        var db = uri.AbsolutePath.Trim('/');
        var user = uri.UserInfo.Split(':')[0];
        var passwd = uri.UserInfo.Split(':')[1];
        var port = uri.Port > 0 ? uri.Port : 5432;
        var dbConnectionString = string.Format("Server={0};Database={1};User Id={2};Password={3};Port={4}", uri.Host, db, user, passwd, port);


        services.AddDbContext<SustDbContext>(options =>
        {
            options.UseNpgsql(dbConnectionString);
        });

        return services;
    }
}
