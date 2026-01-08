using System;
using System.Collections.Generic;
using System.Text;
using TekhLoanManagement.Domain.Enums;

namespace TekhLoanManagement.Application.DTOs.Responses.Transactions
{
    public class TransactionResponseDto
    {
        public Guid Id { get; set; }
        public Guid DebitWalletAccountId { get; set; }
        public Guid CreditWalletAccountId { get; set; }
        public decimal Amount { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Description { get; set; }
        public TransactionType Type { get; set; }
    }
}
