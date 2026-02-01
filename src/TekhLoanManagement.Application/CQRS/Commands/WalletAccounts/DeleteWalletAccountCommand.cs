using System;
using System.Collections.Generic;
using System.Text;
using TekhLoanManagement.Application.CQRS.Interfaces;

namespace TekhLoanManagement.Application.CQRS.Commands.WalletAccounts
{
    public class DeleteWalletAccountCommand : ICommand
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
    }
}
