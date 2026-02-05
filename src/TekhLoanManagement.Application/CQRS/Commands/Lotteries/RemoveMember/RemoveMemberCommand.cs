using System;
using System.Collections.Generic;
using System.Text;
using TekhLoanManagement.Application.CQRS.Interfaces;
using TekhLoanManagement.Application.CQRS.Queries.Installments.GetById;

namespace TekhLoanManagement.Application.CQRS.Commands.Lotteries.RemoveMember
{
    public record RemoveMemberCommand(Guid MemberId, Guid LotteryId) : ICommand
    {
    }
}
