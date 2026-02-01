using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using TekhLoanManagement.Domain.Entities;

namespace TekhLoanManagement.Domain.Events.WalletAccounts
{
    public class WalletAccountUpdatedEvent : INotification
    {
        public WalletAccount WalletAccount { get; }
        public string? OldValue { get; }
        public Guid UserId { get; }

        public WalletAccountUpdatedEvent(WalletAccount walletAccount, Guid userId, string? oldValue)
        {
            WalletAccount = walletAccount;
            UserId = userId;
            OldValue = oldValue;
        }
    }
}
