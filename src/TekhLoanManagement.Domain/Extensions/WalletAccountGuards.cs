using Ardalis.GuardClauses;
using System;
using System.Collections.Generic;
using System.Text;
using TekhLoanManagement.Domain.Entities;
using TekhLoanManagement.Domain.Enums;
using TekhLoanManagement.Domain.Exceptions;

namespace TekhLoanManagement.Domain.Extensions
{
    public static class WalletAccountGuards
    {
        public static void Debit(this IGuardClause guardClause, WalletAccount account, decimal amount)
        {
            if (account.Status != WalletAccountStatus.Active)
                throw new DomainException("Account is not active");

            if (amount <= 0)
                throw new DomainException("Invalid amount");

            if (account.GetBalance() < amount)
                throw new DomainException("Insufficient funds");
        }

        public static void Credit(this IGuardClause guardClause, WalletAccount account, decimal amount)
        {
            if (account.Status != WalletAccountStatus.Active)
                throw new DomainException("Account is not active");

            if (amount <= 0)
                throw new DomainException("Invalid amount");
        }
    }
}
