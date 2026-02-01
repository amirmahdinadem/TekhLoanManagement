using System;
using System.Collections.Generic;
using System.Text;
using TekhLoanManagement.Application.CQRS.Interfaces;

namespace TekhLoanManagement.Application.CQRS.Commands.Funds
{
    public record AddMemberCommand(Guid FundId ,Guid MemberId ):ICommand;
    
}
