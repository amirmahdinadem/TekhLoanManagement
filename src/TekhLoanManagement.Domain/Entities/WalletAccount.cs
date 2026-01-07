using System;
using System.Collections.Generic;
using System.Text;
using TekhLoanManagement.Domain.Abstractions;
using TekhLoanManagement.Domain.Enums;
using TekhLoanManagement.Domain.Exceptions;

namespace TekhLoanManagement.Domain.Entities
{
    public class WalletAccount : BaseEntity<Guid> //Hesab Mali
    {
        public string? WalletAccountNumber { get; set; }
        public decimal Balance { get; private set; }
        public WalletAccountStatus Status { get; private set; } = WalletAccountStatus.Active;
        public ICollection<Transaction>? DebitTransactions { get; set; } = new List<Transaction>();
        public ICollection<Transaction>? CreditTransactions { get; set; } = new List<Transaction>();
        public Member? Member { get; set; }
        public Fund? Fund { get; set; }

        public void Debit(decimal amount)
        {
            if (Status != WalletAccountStatus.Active)
                throw new DomainException("Account is not active");

            if (amount <= 0)
                throw new DomainException("Invalid amount");

            if (Balance < amount)
                throw new DomainException("Insufficient funds");

            Balance -= amount;
        }

        public void Credit(decimal amount)
        {
            if (Status != WalletAccountStatus.Active)
                throw new DomainException("Account is not active");

            if (amount <= 0)
                throw new DomainException("Invalid amount");

            Balance += amount;
        }

    }
}
