using System;
using System.Collections.Generic;
using System.Text;
using TekhLoanManagement.Application.CQRS.Interfaces;
using TekhLoanManagement.Application.DTOs.Responses.WalletAccounts;

namespace TekhLoanManagement.Application.CQRS.Queries.WalletAccounts
{
    public class GetWalletAccountByIdQuery : IQuery<WalletAccountResponseDto>
    {
        public Guid Id { get; set; }
    }
}
