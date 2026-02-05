using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Text;
using TekhLoanManagement.Domain.Abstractions;
using TekhLoanManagement.Domain.Enums;
using TekhLoanManagement.Domain.Exceptions;

namespace TekhLoanManagement.Domain.Entities
{
    public class Lottery : BaseEntity<Guid>
    {
        public List<Member>? Members { get; set; } = new List<Member>();
        public Loan? Loan { get; set; } = null;
        public LotteryStatus Status { get; set; } = LotteryStatus.NotHeld;

        public void AddMember(Member member)
        {
            if (Members.Any(x => x.Id == member.Id))
                throw new DomainException("You Joined Before");
            Members.Add(member);
        }
        public void RemoveMember(Guid memberId)
        {
            var memeber = Members.FirstOrDefault(x => x.Id == memberId);
            if (memeber == null)
                throw new DomainException("Member Not Found");
            Members.Remove(memeber);
        }
        public void Celebration()
        {
            //ToDo :  increase and reset the points
            if (!Members.Any())
                throw new DomainException("Lottery Have Not Member");
            Random random = new Random();
            int index = random.Next(Members.Count);
            var member = Members[index];
            if (member == null)
                throw new DomainException("Member Not Found");
            Loan.Member = member;
            Loan.MemberId = member.Id;
            Members.ForEach(x => x.IncreasePoint());
            member.ResetPoint();
        }
    }

}
