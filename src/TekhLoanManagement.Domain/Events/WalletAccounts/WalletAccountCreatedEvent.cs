using MediatR;
using TekhLoanManagement.Domain.Entities;

namespace TekhLoanManagement.Domain.Events.WalletAccounts
{
    public class WalletAccountCreatedEvent : INotification
    {
        public WalletAccount WalletAccount { get; }
        public Guid UserId { get; }

        public WalletAccountCreatedEvent(WalletAccount walletAccount, Guid userId)
        {
            WalletAccount = walletAccount;
            UserId = userId;
        }
    }
}
