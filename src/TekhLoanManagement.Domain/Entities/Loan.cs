using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using TekhLoanManagement.Domain.Abstractions;
using TekhLoanManagement.Domain.Enums;
using TekhLoanManagement.Domain.Exceptions;

namespace TekhLoanManagement.Domain.Entities
{
    public class Loan : BaseEntity<Guid> //Vam
    {
        protected Loan() { } //Ef
        public Loan(Guid fundId, decimal amount, int installmentCount, int startMonth, int startYear, double profitRate)
        {
            Guard(amount, installmentCount, startMonth, startYear);
            FundId = fundId;
            Amount = amount;
            StartDate = new DateOnly(startYear, startMonth, 1);
            InstallmentCount = installmentCount;
            ProfitRate = profitRate;
        }

        public DateOnly StartDate { get; set; }
        public Guid? MemberId { get; set; }
        public Member? Member { get; set; }
        public Guid FundId { get; set; }
        public Guid LotteryId { get; set; }
        public Lottery? Lottery { get; set; }
        public decimal Amount { get; set; }
        public double ProfitRate { get; set; }
        public int InstallmentCount { get; set; }
        public ICollection<Installment>? Installments { get; set; } = new List<Installment>();

        public void CreateLoanInstallment()
        {
            for (int i = 1; i <= InstallmentCount; i++)
            {
                Installments.Add(new Installment(Id, (Amount + ((Amount * (decimal)(ProfitRate / 100))) / InstallmentCount), StartDate.AddMonths(i)));
            }
        }
        public void CreateLottery()
        {
            var lottery = new Lottery();
            LotteryId = lottery.Id;
            Lottery = lottery;
        }
        public void Guard(decimal amount, int installmentCount, int stratMonth, int startYear)
        {
            if (stratMonth > 12 || startYear <= 0)
                throw new DomainException("Month cannot be less than zero and greater than 12.");
            if (startYear < DateTime.Now.Month)
                throw new DomainException("The year cannot be less than this year.");
            if (amount < 0)
                throw new DomainException("Amount must not be less than zero.");
            if (installmentCount < 0)
                throw new DomainException("Installment Count must not be less than zero.");
        }

    }
}
