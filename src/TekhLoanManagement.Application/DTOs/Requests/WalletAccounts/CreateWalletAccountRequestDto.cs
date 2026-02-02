using System;
using System.Collections.Generic;
using System.Text;
using TekhLoanManagement.Domain.Enums;

namespace TekhLoanManagement.Application.DTOs.Requests.WalletAccounts
{
    public class CreateWalletAccountRequestDto
    {
        public WalletAccountType Type { get; set; }
    }
}
