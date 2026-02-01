using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using TekhLoanManagement.Domain.Abstractions;
using TekhLoanManagement.Domain.Enums;

namespace TekhLoanManagement.Domain.Entities
{
    public class Member : BaseEntity<Guid> //Karmand
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateOnly BirthDate { get; set; }
        public DateTime JoinDate { get; set; }
        public ICollection<Loan>? Loans { get; set; } = new List<Loan>();
        public ICollection<Fund>? Funds { get; set; } = new List<Fund>();
        public ICollection<Lottery>? Lotteries { get; set; } = new List<Lottery>();
        public Guid WalletAccountId { get; set; }
        public WalletAccount? WalletAccount { get; set; }
        public User? User { get; set; }
        public int Point { get; set; } = 1;
        public void ResetPoint()
        {
            Point = 1;
        }

        public void IncreasePoint()
        {
            Point += 1;
        }



       
    }
}
