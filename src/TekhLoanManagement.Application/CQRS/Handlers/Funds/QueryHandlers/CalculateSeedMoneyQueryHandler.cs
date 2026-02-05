using System;
using System.Collections.Generic;
using System.Text;
using TekhLoanManagement.Application.CQRS.Interfaces;
using TekhLoanManagement.Application.CQRS.Queries.Funds;

namespace TekhLoanManagement.Application.CQRS.Handlers.Funds.QueryHandlers
{
    public class CalculateSeedMoneyQueryHandler : IQueryHandler<CalculateSeedMoneyQuery, decimal>
    {
        public async Task<decimal> Handle(CalculateSeedMoneyQuery request, CancellationToken cancellationToken)
        {
            var seed = (request.monthlyPaymentAmount +
             (request.monthlyPaymentAmount / request.numberOfInstallments)) *
             (request.numberOfInstallments / 2m);
            Console.WriteLine(seed);
            return seed;
        }
    }
}
