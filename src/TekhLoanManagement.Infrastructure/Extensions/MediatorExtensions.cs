using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using TekhLoanManagement.Domain.Abstractions;
using TekhLoanManagement.Infrastructure.Context;

namespace TekhLoanManagement.Infrastructure.Extensions
{
    static class MediatorExtensions
    {
        public static async Task DispatchDomainEventsAsync(this IMediator mediator, TekhLoanDbContext ctx)
        {
            var domainEntities = ctx.ChangeTracker
                .Entries<BaseEntity<Guid>>()
                .Where(x => x.Entity.DomainEvents != null && x.Entity.DomainEvents.Any());

            var domainEvents = domainEntities
                .SelectMany(x => x.Entity.DomainEvents)
                .ToList();

            domainEntities.ToList()
                .ForEach(entity => entity.Entity.ClearDomainEvents());

            foreach (var domainEvent in domainEvents)
                await mediator.Publish(domainEvent);
        }
    }
}
