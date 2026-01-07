using System;
using System.Collections.Generic;
using System.Text;
using TekhLoanManagement.Application.CQRS.Interfaces;
using TekhLoanManagement.Application.DTOs.Responses.Transactions;
using TekhLoanManagement.Domain.Enums;

namespace TekhLoanManagement.Application.CQRS.Commands.Transactions
{
    public class CreateTransactionCommand : ICommand<TransactionResponseDto>
    {
        public Guid DebitWalletAccountId { get; set; }
        public Guid CreditWalletAccountId { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public TransactionType Type { get; set; }
        public Guid? InstallmentId { get; set; } = null;
    }
}
