using System;
using System.Collections.Generic;
using System.Text;
using TekhLoanManagement.Application.CQRS.Interfaces;
using TekhLoanManagement.Application.DTOs.Responses.Loans;

namespace TekhLoanManagement.Application.CQRS.Queries.Loans.GetLoaosByFundId
{
    public record GetLoansByFundIdQuery(Guid FundId) : IQuery<List<LoanDto>>
    {
    }
}
