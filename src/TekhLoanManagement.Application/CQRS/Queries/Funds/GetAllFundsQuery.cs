using System;
using System.Collections.Generic;
using System.Text;
using TekhLoanManagement.Application.CQRS.Interfaces;
using TekhLoanManagement.Application.DTOs.Responses.Funds;

namespace TekhLoanManagement.Application.CQRS.Queries.Funds
{
    public record GetAllFundsQuery : IQuery<FundDto>
    {
    }
}
