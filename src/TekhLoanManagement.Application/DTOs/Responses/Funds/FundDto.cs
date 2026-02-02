using System;
using System.Collections.Generic;
using System.Text;
using TekhLoanManagement.Domain.Entities;

namespace TekhLoanManagement.Application.DTOs.Responses.Funds
{
    public class FundDto
    {
        public Guid Id { get; set; }    
        public decimal MonthlyPaymentAmount { get; set; }
        public int NumberOfInstallments { get; set; }
        public DateOnly StartDate { get;  set; }
        public DateOnly? EndDate { get; set; }
        public double ProfitRate { get; set; }
        public decimal SeedMoney { get; set; }
        public Guid WalletAccountId { get; set; }

        public List<Loan> _loans = new List<Loan>();

        public List<Member> _members = new List<Member>();

    }
}
