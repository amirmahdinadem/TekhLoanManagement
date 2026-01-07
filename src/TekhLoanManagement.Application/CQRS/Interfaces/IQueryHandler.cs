using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace TekhLoanManagement.Application.CQRS.Interfaces
{
    public interface IQueryHandler<TQuery, TResult> : IRequestHandler<TQuery, TResult>
    where TQuery : IQuery<TResult>
    {
    }
}
