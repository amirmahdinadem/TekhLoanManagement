using System;
using System.Collections.Generic;
using System.Text;
using TekhLoanManagement.Domain.Abstractions;
using TekhLoanManagement.Domain.Enums;

namespace TekhLoanManagement.Domain.Entities
{
    public class Installment : BaseEntity<Guid> //Ghest
    {
        public Guid LoanId { get; set; }
        public Loan? Loan { get; set; }
        public decimal Amount { get; set; }
        public DateOnly DueDate { get; set; }
        public InstallmentStatus Status { get; set; } = InstallmentStatus.NotPaid;
        public Guid? TransactionId { get; set; }
        public Transaction? Transaction { get; set; }
    }
}
