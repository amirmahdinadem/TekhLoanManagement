using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using TekhLoanManagement.Domain.Abstractions;
using TekhLoanManagement.Domain.Exceptions;

namespace TekhLoanManagement.Domain.Entities
{
    public class Loan : BaseEntity<Guid> //Vam
    {
        protected Loan() { } //Ef
        public Loan(Guid fundId, decimal amount, int installmentCount)
        {
            Guard(amount, installmentCount);
            FundId = fundId;
            Amount = amount;
            StartDate = DateOnly.FromDateTime(DateTime.Now);
            InstallmentCount = installmentCount;
        }

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

        public void CreateLoanInstallment()
        {
            for (int i = 0; i < InstallmentCount; i++)
            {
                var installment = new Installment(Id, Amount / InstallmentCount, StartDate.AddMonths(i));

            }
        }
        public void Guard(decimal amount, int installmentCount)
        {
            if (amount < 0)
                throw new DomainException("Amount must not be less than zero.");
            if (installmentCount < 0)
                throw new DomainException("Installment Count must not be less than zero.");
        }
    }
}
