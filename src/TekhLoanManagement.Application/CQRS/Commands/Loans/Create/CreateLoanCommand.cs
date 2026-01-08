using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using TekhLoanManagement.Application.CQRS.Interfaces;
using TekhLoanManagement.Application.DTOs.Responses.Loans;

namespace TekhLoanManagement.Application.CQRS.Commands.Loans.Create
{
    public record CreateLoanCommand(Guid FundId, decimal Amount, int InstallmentCount , int StartMonth, int StartYear) : ICommand<LoanDto> { } 
    
}
