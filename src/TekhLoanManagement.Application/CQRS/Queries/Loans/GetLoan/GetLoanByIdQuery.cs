using System;
using System.Collections.Generic;
using System.Text;
using TekhLoanManagement.Application.CQRS.Interfaces;
using TekhLoanManagement.Application.DTOs.Responses.Loans;

namespace TekhLoanManagement.Application.CQRS.Queries.Loans.GetLoan
{
    public record GetLoanByIdQuery(Guid LoanId) : IQuery<LoanDto>
    {
    }
}
