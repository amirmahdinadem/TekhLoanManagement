using System;
using System.Collections.Generic;
using System.Text;
using TekhLoanManagement.Application.CQRS.Interfaces;

namespace TekhLoanManagement.Application.CQRS.Commands.Lotteries.Celebrate
{
    public record CelebrateLotteryCommand(Guid LotteryId) : ICommand
    {
    }
}
