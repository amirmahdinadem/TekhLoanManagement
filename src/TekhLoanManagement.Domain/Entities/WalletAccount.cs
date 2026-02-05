using Ardalis.GuardClauses;
using TekhLoanManagement.Domain.Abstractions;
using TekhLoanManagement.Domain.Enums;
using TekhLoanManagement.Domain.Events.WalletAccounts;
using TekhLoanManagement.Domain.Exceptions;
using TekhLoanManagement.Domain.Extensions;
using TekhLoanManagement.Domain.Interfaces;

namespace TekhLoanManagement.Domain.Entities
{
    public class WalletAccount : BaseEntity<Guid>, IAggregateRoot //Hesab Mali
    {
        private WalletAccount(string walletAccountNumber, WalletAccountType type)
        {
            Guard.Against.NullOrEmpty(walletAccountNumber, nameof(walletAccountNumber));
            Guard.Against.EnumOutOfRange(type, nameof(type));

            WalletAccountNumber = walletAccountNumber;
            Type = type;
        }

#pragma warning disable CS8618 // Required by Entity Framework
        private WalletAccount() { }

        public string WalletAccountNumber { get; private set; }
        public WalletAccountType Type { get; private set; }
        public decimal Balance { get; private set; } = 0;
        public decimal Frozen { get; private set; } = 0;
        public WalletAccountStatus Status { get; private set; } = WalletAccountStatus.Active;
        public Member? Member { get; private set; }
        public Fund? Fund { get; private set; }
        // Todo: Private collection And
        // Todo: Relation fund and Wallet
        public ICollection<Transaction>? DebitTransactions { get; set; } = new List<Transaction>();
        public ICollection<Transaction>? CreditTransactions { get; set; } = new List<Transaction>();

        public void Debit(decimal amount)
        {
            Guard.Against.Debit(this, amount);

            Balance -= amount;
        }

        public void Credit(decimal amount)
        {
            Guard.Against.Credit(this, amount);

            Balance += amount;
        }

        public Guid? GetOwnerId()
        {
            if (Member is not null) return Member.Id;
            else if (Fund is not null) return Fund.Id;
            else return null;
        }

        public static WalletAccount Create(string walletAccountNumber, WalletAccountType type, Guid userId)
        {
            var walletAccount = new WalletAccount(walletAccountNumber, type);
            walletAccount.AddDomainEvent(new WalletAccountCreatedEvent(walletAccount, userId));
            return walletAccount;
        }

        public static WalletAccount Delete(WalletAccount walletAccount, Guid userId)
        {
            walletAccount.AddDomainEvent(
                new WalletAccountDeletedEvent(walletAccount, userId)
            );
            return walletAccount;
        }

        public void ChangeStatus(WalletAccountStatus status, Guid userId, string oldValue)
        {
            Status = status;
            AddDomainEvent(new WalletAccountUpdatedEvent(this, userId, oldValue));
        }

        public void Frezze(decimal amount)
        {
            if (Status != WalletAccountStatus.Active)
                throw new DomainException("Account is not active");

            if (amount <= 0)
                throw new DomainException("Invalid amount");

            if (GetBalance() < amount)
                throw new DomainException("Insufficient funds");

            Frozen += amount;
        }

        public void UnFrezze(decimal amount)
        {
            if (Status != WalletAccountStatus.Active)
                throw new DomainException("Account is not active");

            if (amount <= 0)
                throw new DomainException("Invalid amount");

            if (amount > Frozen)
                throw new DomainException("Invalid amount. Amount Not Be Greater Than Frozen Amount");

            Frozen -= amount;
        }

        public decimal GetBalance()
        {
            return Balance - Frozen;
        }
    }
}
