using System;
using System.Collections.Generic;
using System.Text;
using TekhLoanManagement.Domain.Enums;

namespace TekhLoanManagement.Application.DTOs.Responses.WalletAccounts
{
    public class WalletAccountResponseDto
    {
        public Guid Id { get; set; }
        public string WalletAccountNumber { get; set; }
        public decimal Balance { get; set; }
        public WalletAccountStatus Status { get; set; }
    }
}
