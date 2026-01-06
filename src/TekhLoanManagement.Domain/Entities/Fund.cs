using System;
using System.Collections.Generic;
using System.Text;
using TekhLoanManagement.Domain.Abstractions;

namespace TekhLoanManagement.Domain.Entities
{
    public class Fund : BaseEntity<Guid> //Sandogh
    {
        public ICollection<Member> Members { get; set; } = new List<Member>();
        public ICollection<Loan> Loans { get; set; } = new List<Loan>();
        public double ProfitRate { get; set; }
        public decimal MonthlyPaymentAmount { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly? EndDate { get; set; }
        public double Rate { get; set; }
        public Guid WalletAccountId { get; set; }
        public WalletAccount WalletAccount { get; set; }

    }
}
