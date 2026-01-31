using System;
using System.Collections.Generic;
using System.Text;
using TekhLoanManagement.Application.CQRS.Interfaces;

namespace TekhLoanManagement.Application.CQRS.Commands.Funds
{
    public record CreateFundCommand(decimal MonthlyPaymentAmount , int NumberOfInstallments , double ProfitRate , Guid WalletAccountId):ICommand<Guid> ;     
}
