using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace TekhLoanManagement.Application.CQRS.Interfaces
{
    public interface ICommandHandler<TCommand> : IRequestHandler<TCommand>
    where TCommand : ICommand
    {
    }

    public interface ICommandHandler<TCommand, TResult> : IRequestHandler<TCommand, TResult>
     where TCommand : ICommand<TResult>
    {
    }
}
