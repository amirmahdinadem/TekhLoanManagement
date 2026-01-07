using System;
using System.Collections.Generic;
using System.Text;
using TekhLoanManagement.Application.CQRS.Interfaces;
using TekhLoanManagement.Application.DTOs.Responses.Transactions;

namespace TekhLoanManagement.Application.CQRS.Queries.Transactions
{
    public class GetTransactionByIdQuery : IQuery<TransactionResponseDto>
    {
        public Guid Id { get; set; }
    }
}
