using System;
using System.Collections.Generic;
using System.Text;
using TekhLoanManagement.Application.CQRS.Interfaces;
namespace TekhLoanManagement.Application.CQRS.Commands.Funds
{
    public record AddLoanCommand(Guid FundId,Guid LoanId ) : ICommand;
    
}
