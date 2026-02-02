using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using TekhLoanManagement.Domain.Entities;

namespace TekhLoanManagement.Domain.Events.WalletAccounts
{
    public class WalletAccountDeletedEvent : INotification
    {
        public WalletAccount WalletAccount { get; }
        public Guid UserId { get; }

        public WalletAccountDeletedEvent(WalletAccount walletAccount, Guid userId)
        {
            WalletAccount = walletAccount;
            UserId = userId;
        }
    }
}
