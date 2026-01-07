using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace TekhLoanManagement.Application.CQRS.Interfaces
{
    public interface IQuery<TResult> : IRequest<TResult>
    {
    }
}
