using System;
using System.Collections.Generic;
using System.Text;
using TekhLoanManagement.Application.CQRS.Commands.Funds;
using TekhLoanManagement.Application.CQRS.Interfaces;
using TekhLoanManagement.Application.Interfaces;
using TekhLoanManagement.Domain.Entities;

namespace TekhLoanManagement.Application.CQRS.Handlers.Funds.CommandHandlers
{
    public class CreateFundCommandHandler : ICommandHandler<CreateFundCommand, Guid>  
    {
        private readonly IUnitOfWork _unitOfWork ;
        public CreateFundCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

    public async Task<Guid> Handle(CreateFundCommand request , CancellationToken cancellationToken)
        {
            var wallet = await _unitOfWork.WalletAccounts.GetByIdAsync(request.WalletAccountId, cancellationToken);
            if (wallet == null) { throw new Exception("Invalid Wallet"); }
            
            var fund = new Fund(
                request.MonthlyPaymentAmount,
                request.NumberOfInstallments,
                request.ProfitRate,
                request.WalletAccountId,
                wallet
                 
                );

            await _unitOfWork.Funds.AddAsync( fund ,cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return fund.Id;
            
        }
    }
}
