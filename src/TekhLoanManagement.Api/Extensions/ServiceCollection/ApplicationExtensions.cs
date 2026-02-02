using TekhLoanManagement.Application.CQRS.Commands.WalletAccounts;
using TekhLoanManagement.Application.Interfaces;
using TekhLoanManagement.Application.Services;

namespace TekhLoanManagement.Api.Extensions.ServiceCollection
{
    public static class ApplicationExtensions
    {
        public static IServiceCollection AddApplicationServices(
            this IServiceCollection services)
        {
            services.AddAutoMapper(cfg =>
            cfg.AddMaps(typeof(CreateWalletAccountCommand).Assembly));

            services.AddScoped<ITransactionService, TransactionService>();
            services.AddScoped<IWalletAccountService, WalletAccountService>();
            services.AddScoped<IMemberService, MemberService>();

            return services;
        }
    }
}
