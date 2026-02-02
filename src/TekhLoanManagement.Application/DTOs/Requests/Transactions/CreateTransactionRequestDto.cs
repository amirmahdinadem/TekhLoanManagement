using System;
using System.Collections.Generic;
using System.Text;
using TekhLoanManagement.Domain.Enums;

namespace TekhLoanManagement.Application.DTOs.Requests.Transactions
{
    public class CreateTransactionRequestDto
    {
        public Guid DebitWalletAccountId { get; set; }
        public Guid CreditWalletAccountId { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public TransactionType Type { get; set; }
        public Guid? InstallmentId { get; set; } = null;
    }
}
