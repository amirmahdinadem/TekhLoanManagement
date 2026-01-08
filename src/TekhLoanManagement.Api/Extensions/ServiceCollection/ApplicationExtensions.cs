

using System.Reflection;
using TekhLoanManagement.Application.CQRS.Commands.WalletAccounts;

namespace TekhLoanManagement.Api.Extensions.ServiceCollection
{
    public static class ApplicationExtensions
    {
        public static IServiceCollection AddApplicationServices(
            this IServiceCollection services)
        {
            services.AddAutoMapper(cfg =>
            cfg.AddMaps(typeof(CreateWalletAccountCommand).Assembly));


            return services;
        }
    }
}
