using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TekhLoanManagement.Application.CQRS.Commands.Transactions;
using TekhLoanManagement.Application.CQRS.Interfaces;
using TekhLoanManagement.Application.DTOs.Responses.Transactions;
using TekhLoanManagement.Application.Exceptions;
using TekhLoanManagement.Application.Interfaces;
using TekhLoanManagement.Domain.Entities;

namespace TekhLoanManagement.Application.CQRS.Handlers.Transactions
{
    public class CreateTransactionCommandHandler : ICommandHandler<CreateTransactionCommand, TransactionResponseDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateTransactionCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<TransactionResponseDto> Handle(CreateTransactionCommand request, CancellationToken cancellationToken)
        {

            if (request.DebitWalletAccountId == request.CreditWalletAccountId)
                throw new ConflictException("The parties to the transaction are the same.");

            await _unitOfWork.BeginTransactionAsync();

            try
            {
                var from = await _unitOfWork.WalletAccounts.GetByIdAsync(request.DebitWalletAccountId, cancellationToken);
                var to = await _unitOfWork.WalletAccounts.GetByIdAsync(request.CreditWalletAccountId, cancellationToken);

                from.Debit(request.Amount);
                to.Credit(request.Amount);

                var transaction = _mapper.Map<Transaction>(request);
                await _unitOfWork.Transactions.AddAsync(transaction, cancellationToken);
                await _unitOfWork.CommitAsync();
                return _mapper.Map<TransactionResponseDto>(transaction);
            }
            catch
            {
                await _unitOfWork.RollbackAsync();
                throw;
            }

        }
    }
}
