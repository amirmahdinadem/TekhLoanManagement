using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using TekhLoanManagement.Domain.Abstractions;
using TekhLoanManagement.Domain.Enums;

namespace TekhLoanManagement.Domain.Entities
{
    public class Lottery : BaseEntity<Guid>
    {
        public ICollection<Member>? Members { get; set; } = new List<Member>();
        public Loan? Loan { get; set; }
        public LotteryStatus Status { get; set; }
    }
}
