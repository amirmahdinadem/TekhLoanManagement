using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using TekhLoanManagement.Domain.Abstractions;
using TekhLoanManagement.Domain.Enums;
using TekhLoanManagement.Domain.Exceptions;

namespace TekhLoanManagement.Domain.Entities
{
    public class Lottery : BaseEntity<Guid>
    {
        public ICollection<Member>? Members { get; set; } = new List<Member>();
        public Loan? Loan { get; set; } = null;
        public LotteryStatus Status { get; set; } = LotteryStatus.NotHeld;

        public void AddMember(Member member)
        {
            if (Members.Any(x => x.Id == member.Id))
                throw new DomainException("You Joined Before");
            Members.Add(member);
        }
        public void Celebration()
        {

        }
    }

}
