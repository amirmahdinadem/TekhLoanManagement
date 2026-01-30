using System;
using System.Collections.Generic;
using System.Text;
using TekhLoanManagement.Domain.Abstractions;
using TekhLoanManagement.Domain.Enums;
using TekhLoanManagement.Domain.Exceptions;

namespace TekhLoanManagement.Domain.Entities
{
    public class Installment : BaseEntity<Guid> //Ghest
    {
        private Installment() { } //Ef
        public Installment(Guid loanId, decimal amount, DateOnly dueDate)
        {
            Guard(amount);
            LoanId = loanId;
            Amount = amount;
            DueDate = dueDate;
        }
        public Guid LoanId { get; set; }
        public Loan? Loan { get; set; }
        public decimal Amount { get; set; }
        public DateOnly DueDate { get; set; }
        public InstallmentStatus Status { get; set; } = InstallmentStatus.NotPaid;
        public Guid? TransactionId { get; set; }
        public Transaction? Transaction { get; set; }

        public void Payment(Guid transactionId)
        {
            Status = InstallmentStatus.Paid;
            TransactionId = transactionId;
        }
        public void Guard(decimal amount)
        {
            if (amount < 0)
                throw new DomainException("Amount must not be less than zero.");
        }
    }
}
