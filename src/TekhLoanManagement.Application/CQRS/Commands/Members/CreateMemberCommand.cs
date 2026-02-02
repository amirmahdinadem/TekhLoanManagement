using System;
using System.Collections.Generic;
using System.Text;
using TekhLoanManagement.Application.CQRS.Interfaces;
using TekhLoanManagement.Application.DTOs.Responses.Members;

using TekhLoanManagement.Domain.Enums;

namespace TekhLoanManagement.Application.CQRS.Commands.Members
{
    public record CreateMemberCommand
        (string firstName,
        string lastName,
        DateOnly birthdate


        )
        : ICommand<MemberResponseDto>
    {
        public Guid userId { get; set; }
    }
}
