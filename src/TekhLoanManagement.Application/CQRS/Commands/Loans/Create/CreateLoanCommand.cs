using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using TekhLoanManagement.Application.CQRS.Interfaces;

namespace TekhLoanManagement.Application.CQRS.Commands.Loans.Create
{
    public record CreateLoanCommand(Guid FundId, decimal Amount, int InstallmentCount) : ICommand { } 
    
}
