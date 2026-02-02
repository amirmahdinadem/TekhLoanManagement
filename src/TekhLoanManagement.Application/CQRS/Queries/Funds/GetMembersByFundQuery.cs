using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Text;
using TekhLoanManagement.Application.CQRS.Interfaces;
using TekhLoanManagement.Application.DTOs.Responses.Members;

namespace TekhLoanManagement.Application.CQRS.Queries.Funds
{
    public record GetMembersByFundQuery(Guid FundId) : IQuery<IEnumerable<MemberResponseDto>>
    {
    }
}
