using Infrastructure.Database;
using Infrastructure.Database.DatabaseHelpers;
using Infrastructure.Database.MySQLDatabase;
using Infrastructure.Repositories.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString)
        {
            services.AddSingleton<MockDatabase>();
            services.AddScoped<AuthRepository>();

            services.AddDbContext<RealDatabase>(options =>
            {
                options.UseSqlServer(connectionString).AddInterceptors(new CommandLoggingInterceptor());
            });

            return services;
        }
    }
}
