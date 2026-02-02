using System;
using System.Collections.Generic;
using System.Text;
using TekhLoanManagement.Application.CQRS.Interfaces;
using TekhLoanManagement.Application.DTOs.Responses.WalletAccounts;
using TekhLoanManagement.Domain.Enums;

namespace TekhLoanManagement.Application.CQRS.Commands.WalletAccounts
{
    public class CreateWalletAccountCommand : ICommand<WalletAccountResponseDto>
    {
        public WalletAccountType Type { get; set; }
        public Guid UserId { get; set; }
    }
}
