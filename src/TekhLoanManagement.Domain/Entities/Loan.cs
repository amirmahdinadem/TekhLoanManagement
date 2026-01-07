using System;
using System.Collections.Generic;
using System.Text;
using TekhLoanManagement.Domain.Abstractions;

namespace TekhLoanManagement.Domain.Entities
{
    public class Loan : BaseEntity<Guid> //Vam
    {
        public DateOnly StartDate { get; set; }
        public Guid MemberId { get; set; }
        public Member? Member { get; set; }
        public Guid FundId { get; set; }
        public Fund? Fund { get; set; }
        public Guid LotteryId { get; set; }
        public Lottery? Lottery { get; set; }
        public decimal Amount { get; set; }
        public int InstallmentCount { get; set; }
        ICollection<Installment>? Installments { get; set; } = new List<Installment>();
    }
}
