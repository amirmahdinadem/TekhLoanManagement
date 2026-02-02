using System;
using System.Collections.Generic;
using System.Text;
using TekhLoanManagement.Domain.Enums;

namespace TekhLoanManagement.Application.DTOs.Requests.WalletAccounts
{
    public class UpdateWalletAccountRequestDto
    {
        public Guid Id { get; set; }
        public WalletAccountStatus Status { get; set; }
    }
}
