using System;
using System.Collections.Generic;
using System.Text;
using TekhLoanManagement.Domain.Abstractions;

namespace TekhLoanManagement.Domain.Entities
{
    public class Member : BaseEntity<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly BirthDate { get; set; }
        public DateTime JoinDate { get; set; }
        public bool IsActive { get; set; } = true;
        public ICollection<Loan>? Loans { get; set; } = new List<Loan>();
        public ICollection<Fund>? Funds { get; set; } = new List<Fund>();
        public Guid WalletAccountId { get; set; }
        public WalletAccount WalletAccount { get; set; }
        public User? User { get; set; }

    }
}
