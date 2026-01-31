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



        public static void Configure(EntityTypeBuilder<Member> builder)
        {

            builder.ToTable("Members");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                   .ValueGeneratedOnAdd();

            builder.Property(x => x.FirstName)
                   .HasMaxLength(50);

            builder.Property(x => x.LastName)
                   .HasMaxLength(50);

            builder.Property(x => x.BirthDate)
                   .IsRequired();

            builder.Property(x => x.JoinDate)
                   .IsRequired();


            builder.HasMany(x => x.Loans)
                   .WithOne(x => x.Member)
                   .HasForeignKey(x => x.MemberId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.Funds)
                   .WithMany(x => x.Members);

            builder.HasMany(x => x.Lotteries)
                   .WithMany(x => x.Members);


            builder.HasOne(x => x.WalletAccount)
                   .WithOne(x => x.Member)
                   .HasForeignKey<Member>(x => x.WalletAccountId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.User)
                   .WithOne(x => x.Member)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
