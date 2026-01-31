using FluentValidation;
using MediatR;
using System.Reflection;

namespace TekhLoanManagement.Api.Extensions.ServiceCollection
{
    public static class ValidationExtensions
    {
        public static IServiceCollection AddValidation(
            this IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(Assembly.Load("TekhLoanManagement.Application"));
            return services;
        }
    }
}
