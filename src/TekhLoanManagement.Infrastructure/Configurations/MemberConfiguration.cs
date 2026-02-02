using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TekhLoanManagement.Domain.Entities;

namespace TekhLoanManagement.Infrastructure.Configurations
{
    public class MemberConfiguration : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> builder)
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
