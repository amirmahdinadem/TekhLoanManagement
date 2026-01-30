using System;
using System.Collections.Generic;
using System.Text;
using TekhLoanManagement.Application.CQRS.Commands.Funds;
using TekhLoanManagement.Application.CQRS.Interfaces;
using TekhLoanManagement.Application.Interfaces;

namespace TekhLoanManagement.Application.CQRS.Handlers.Funds
{
    public class AddLoanCommandHandler:ICommandHandler<AddLoanCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public AddLoanCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(AddLoanCommand request, CancellationToken cancellationToken)
        {
            var fund = await _unitOfWork.Funds.GetByIdAsync(request.FundId, cancellationToken);
            var loan = await _unitOfWork.Loans.GetByIdAsync(request.LoanId, cancellationToken);
            fund.AddLoan(loan);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

        }
    }
}
