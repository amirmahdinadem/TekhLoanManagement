using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TekhLoanManagement.Domain.Entities;

namespace TekhLoanManagement.Infrastructure.Configurations
{
    public class FundConfiguration : IEntityTypeConfiguration<Fund>
    {
        public void Configure(EntityTypeBuilder<Fund> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd().IsRequired();
            builder.Property(x => x.MonthlyPaymentAmount).IsRequired();
            builder.Property(x => x.NumberOfInstallments).IsRequired();
            builder.Property(x => x.StartDate).IsRequired().HasDefaultValue(DateOnly.FromDateTime(DateTime.Now));
            builder.Property(x => x.ProfitRate).IsRequired();
            builder.Property(x => x.SeedMoney).IsRequired();

            builder.HasOne(x => x.WalletAccount).WithOne(x => x.Fund);
            builder.HasMany(x => x.Members).WithMany(x => x.Funds);




        }
    }
}
