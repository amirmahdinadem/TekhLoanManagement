using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TekhLoanManagement.Application.CQRS.Interfaces;
using TekhLoanManagement.Application.CQRS.Queries.Transactions;
using TekhLoanManagement.Application.DTOs.Responses.Transactions;
using TekhLoanManagement.Application.Interfaces;

namespace TekhLoanManagement.Application.CQRS.Handlers.Transactions
{
    public class GetAllTransactionsQueryHandler : IQueryHandler<GetAllTransactionsQuery, IEnumerable<TransactionResponseDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllTransactionsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TransactionResponseDto>> Handle(GetAllTransactionsQuery request, CancellationToken cancellationToken)
        {
            var transactions = await _unitOfWork.Transactions.GetAllAsync(cancellationToken);
            return _mapper.Map<IEnumerable<TransactionResponseDto>>(transactions);
        }
    }
}
