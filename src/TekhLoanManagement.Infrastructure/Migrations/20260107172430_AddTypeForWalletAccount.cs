using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TekhLoanManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddTypeForWalletAccount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "AccountNumberSequence",
                startValue: 1000000000L);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "WalletAccounts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "WalletAccounts");

            migrationBuilder.DropSequence(
                name: "AccountNumberSequence");
        }
    }
}
