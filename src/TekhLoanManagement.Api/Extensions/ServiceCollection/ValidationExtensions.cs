using FluentValidation;
using MediatR;
using System.Reflection;
using TekhLoanManagement.Application.CQRS.Behaviors;

namespace TekhLoanManagement.Api.Extensions.ServiceCollection
{
    public static class ValidationExtensions
    {
        public static IServiceCollection AddValidation(
            this IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(Assembly.Load("TekhLoanManagement.Application"));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            return services;
        }
    }
}
