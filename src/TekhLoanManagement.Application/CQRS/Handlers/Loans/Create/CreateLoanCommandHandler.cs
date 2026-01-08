using MediatR;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;
using TekhLoanManagement.Application.CQRS.Commands.Loans.Create;
using TekhLoanManagement.Application.CQRS.Interfaces;
using TekhLoanManagement.Application.Interfaces;
using TekhLoanManagement.Domain.Entities;

namespace TekhLoanManagement.Application.CQRS.Handlers.Loans.Create
{
    public class CreateLoanCommandHandler : ICommandHandler<CreateLoanCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateLoanCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(CreateLoanCommand request, CancellationToken cancellationToken)
        {

            var loan = new Loan(request.FundId, request.Amount, request.InstallmentCount);
            await _unitOfWork.Loans.AddAsync(loan, cancellationToken);
            await _unitOfWork.SaveChangesAsync();

        }

    }
}
