using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;
using TekhLoanManagement.Domain.Abstractions;
using TekhLoanManagement.Domain.Enums;

namespace TekhLoanManagement.Domain.Entities
{
    public class Transaction : BaseEntity<Guid> //Tarakonesh
    {
        public Guid DebitWalletAccountId { get; set; }
        public WalletAccount? DebitWalletAccount { get; set; } = default!;
        public Guid CreditWalletAccountId { get; set; }
        public WalletAccount? CreditWalletAccount { get; set; } = default!;
        public decimal Amount { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string? Description { get; set; }
        public TransactionType Type { get; set; }
        public Installment? Installment { get; set; }

    }
}
