using System.Reflection;

namespace TekhLoanManagement.Api.Extensions.ServiceCollection
{
    public static class MediatRExtensions
    {
        public static IServiceCollection AddCustomMediatR(
           this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssembly(Assembly.Load("TekhLoanManagement.Application")));

            return services;
        }
    }
}
