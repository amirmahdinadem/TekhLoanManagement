using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TekhLoanManagement.Application.Interfaces;
using TekhLoanManagement.Domain.Entities;
using TekhLoanManagement.Infrastructure.Context;
using TekhLoanManagement.Infrastructure.Generators;
using TekhLoanManagement.Infrastructure.Repositories;
using TekhLoanManagement.Infrastructure.UnitOfWork;

namespace TekhLoanManagement.Api.Extensions.ServiceCollection
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

            services.AddScoped(typeof(IGenericRepository<,>), typeof(GenericRepository<,>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<INumberGenerator, AccountNumberGenerator>();

            return services;
        }
    }
}
