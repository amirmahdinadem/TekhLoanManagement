using System;
using System.Collections.Generic;
using System.Text;
using TekhLoanManagement.Application.CQRS.Interfaces;

namespace TekhLoanManagement.Application.CQRS.Queries.Funds
{
    public record CalculateSeedMoneyQuery(decimal monthlyPaymentAmount, int numberOfInstallments) :IQuery<decimal>
    {
    }
}
