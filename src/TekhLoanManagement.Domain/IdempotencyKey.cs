using Ardalis.GuardClauses;
using TekhLoanManagement.Domain.Abstractions;

namespace TekhLoanManagement.Domain
{
    public class IdempotencyKey : BaseEntity<Guid>
    {
        public IdempotencyKey(Guid userId, string key, string result)
        {
            Guard.Against.NullOrEmpty(userId, nameof(userId));
            Guard.Against.NullOrEmpty(key, nameof(key));
            Guard.Against.NullOrEmpty(result, nameof(result));

            UserId = userId;
            Key = key;
            Result = result;
        }

#pragma warning disable CS8618 // Required by Entity Framework
        private IdempotencyKey() { }

        public Guid UserId { get; private set; }
        public string Key { get; private set; }
        public string Result { get; private set; }
        public DateTime CreatedAt { get; private set; } = DateTime.Now;
    }
}
