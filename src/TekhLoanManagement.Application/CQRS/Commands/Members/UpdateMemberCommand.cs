using System;
using System.Collections.Generic;
using System.Text;
using TekhLoanManagement.Application.CQRS.Interfaces;


namespace TekhLoanManagement.Application.CQRS.Commands.Members
{
    public record UpdateMemberCommand : ICommand
    {
        public Guid Id { get; set; }
       
    }
}
