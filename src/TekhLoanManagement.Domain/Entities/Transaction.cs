using Ardalis.GuardClauses;
using TekhLoanManagement.Domain.Abstractions;
using TekhLoanManagement.Domain.Enums;
using TekhLoanManagement.Domain.Events.Transactions;

namespace TekhLoanManagement.Domain.Entities
{
    public class Transaction : BaseEntity<Guid> //Tarakonesh
    {
        private Transaction(Guid debitWalletAccountId,
                               Guid creditWalletAccountId,
                               decimal amount,
                               string description,
                               TransactionType type)
        {
            Guard.Against.NullOrEmpty(debitWalletAccountId, nameof(debitWalletAccountId));
            Guard.Against.NullOrEmpty(creditWalletAccountId, nameof(creditWalletAccountId));
            Guard.Against.NegativeOrZero(amount, nameof(amount));
            Guard.Against.NullOrEmpty(description, nameof(description));
            Guard.Against.EnumOutOfRange(type, nameof(type));

            DebitWalletAccountId = debitWalletAccountId;
            CreditWalletAccountId = creditWalletAccountId;
            Amount = amount;
            Description = description;
            Type = type;
        }

#pragma warning disable CS8618 // Required by Entity Framework
        private Transaction() { }

        public Guid DebitWalletAccountId { get; private set; }
        public Guid CreditWalletAccountId { get; private set; }
        public decimal Amount { get; private set; }
        public string Description { get; private set; }
        public TransactionType Type { get; private set; }
        public DateTime CreatedAt { get; private set; } = DateTime.Now;
        public WalletAccount? DebitWalletAccount { get; private set; }
        public WalletAccount? CreditWalletAccount { get; private set; }
        public Installment? Installment { get; private set; }

        public static Transaction Create(Guid debitWalletAccountId,
                           Guid creditWalletAccountId,
                           decimal amount,
                           string description,
                           TransactionType type,
                           string idempotencyKey,
                           Guid userId)
        {
            var transaction = new Transaction(debitWalletAccountId, creditWalletAccountId, amount, description, type);
            transaction.AddDomainEvent(new TransactionCreatedEvent(transaction, idempotencyKey, userId));
            return transaction;
        }

    }
}
