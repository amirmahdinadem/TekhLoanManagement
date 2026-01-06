using System;
using System.Collections.Generic;
using System.Text;
using TekhLoanManagement.Domain.Abstractions;
using TekhLoanManagement.Domain.Enums;

namespace TekhLoanManagement.Domain.Entities
{
    public class WalletAccount : BaseEntity<Guid> //Hesab Mali
    {
        public string? WalletAccountNumber { get; set; }
        public decimal Balance { get; private set; }
        public WalletAccountStatus Status { get; private set; } = WalletAccountStatus.Active;
        public ICollection<Transaction>? DebitTransactions { get; set; } = new List<Transaction>();
        public ICollection<Transaction>? CreditTransactions { get; set; } = new List<Transaction>();
        public Member Member { get; set; }
        public Fund Fund { get; set; }

    }
}
