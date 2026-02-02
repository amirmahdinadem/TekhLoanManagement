using Microsoft.Extensions.Diagnostics.HealthChecks;
using TekhLoanManagement.Api.HealthChecks;

namespace TekhLoanManagement.Api.Extensions.ServiceCollection
{
    public static class HealthCheckExtensions
    {
        public static IServiceCollection AddCustomHealthChecks(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var conStr = configuration.GetConnectionString("TekhLoanDbContext")
                ?? throw new InvalidOperationException("Connection string 'TekhLoanDbContext' not found.");

            services.AddHealthChecks()
            .AddSqlServer(conStr, tags: new[] { "ready" });

            services.Configure<HealthCheckPublisherOptions>(options =>
            {
                options.Delay = TimeSpan.FromSeconds(300);
            });

            services.AddSingleton<IHealthCheckPublisher, HealthCheckPublisher>();


            return services;
        }
    }
}
