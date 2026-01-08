using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TekhLoanManagement.Domain.Entities;
using TekhLoanManagement.Infrastructure.Context;

namespace TekhLoanManagement.Api.Extensions
{
    public static class InfrastructureExtensions
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {

            services.AddDbContext<TekhLoanDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("TekhLoanDbContext")
                ?? throw new InvalidOperationException("Connection string 'TekhLoanDbContext' not found.")));

            services.AddIdentity<User, IdentityRole<Guid>>(options =>
            {
                options.User.RequireUniqueEmail = true;
            })
            .AddEntityFrameworkStores<TekhLoanDbContext>()
            .AddDefaultTokenProviders();

            return services;
        }
    }
}
