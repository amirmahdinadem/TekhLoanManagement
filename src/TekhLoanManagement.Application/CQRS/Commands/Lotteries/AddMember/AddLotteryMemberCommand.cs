using MediatR;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using TekhLoanManagement.Application.CQRS.Interfaces;

namespace TekhLoanManagement.Application.CQRS.Commands.Lotteries.AddMember
{
    public record AddLotteryMemberCommand(Guid MemberId, Guid LoanId) : ICommand
    {
    }


}
