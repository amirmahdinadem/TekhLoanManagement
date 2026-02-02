using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using TekhLoanManagement.Application.DTOs.Requests.Members;
using TekhLoanManagement.Application.DTOs.Requests.Transactions;
using TekhLoanManagement.Application.DTOs.Responses.Members;
using TekhLoanManagement.Application.DTOs.Responses.Transactions;

namespace TekhLoanManagement.Application.Interfaces
{
    public interface IMemberService
    {
        Task<MemberResponseDto> CreateAsync(CreateMemberRequestDto dto, ClaimsPrincipal principal, CancellationToken cancellationToken);

    }
}
