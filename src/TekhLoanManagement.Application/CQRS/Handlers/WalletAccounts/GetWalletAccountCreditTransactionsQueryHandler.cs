using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TekhLoanManagement.Application.CQRS.Interfaces;
using TekhLoanManagement.Application.CQRS.Queries.WalletAccounts;
using TekhLoanManagement.Application.DTOs.Responses.Transactions;
using TekhLoanManagement.Application.Exceptions;
using TekhLoanManagement.Application.Interfaces;

namespace TekhLoanManagement.Application.CQRS.Handlers.WalletAccounts
{
    public class GetWalletAccountCreditTransactionsQueryHandler : IQueryHandler<GetWalletAccountCreditTransactionsQuery, IEnumerable<TransactionResponseDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetWalletAccountCreditTransactionsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TransactionResponseDto>> Handle(GetWalletAccountCreditTransactionsQuery request, CancellationToken cancellationToken)
        {
            var walletAccount = await _unitOfWork.WalletAccounts.GetByIdAsync(request.Id, cancellationToken);
            if (walletAccount == null)
                throw new NotFoundException("Wallet Account", request.Id);
            return _mapper.Map<IEnumerable<TransactionResponseDto>>(walletAccount.CreditTransactions);
        }
    }
}
