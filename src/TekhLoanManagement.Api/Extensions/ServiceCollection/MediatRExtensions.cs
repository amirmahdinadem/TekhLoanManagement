using System.Reflection;
using TekhLoanManagement.Application.CQRS.Behaviors;

namespace TekhLoanManagement.Api.Extensions.ServiceCollection
{
    public static class MediatRExtensions
    {
        public static IServiceCollection AddCustomMediatR(
           this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(Assembly.Load("TekhLoanManagement.Application"));
                cfg.AddOpenBehavior(typeof(LoggingBehavior<,>));
            });
            return services;
        }
    }
}
