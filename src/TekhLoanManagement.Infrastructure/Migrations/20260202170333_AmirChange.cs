using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TekhLoanManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AmirChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Funds_WalletAccounts_WalletAccountId",
                table: "Funds");

            migrationBuilder.DropForeignKey(
                name: "FK_Loans_Funds_FundId",
                table: "Loans");

            migrationBuilder.AddForeignKey(
                name: "FK_Funds_WalletAccounts_WalletAccountId",
                table: "Funds",
                column: "WalletAccountId",
                principalTable: "WalletAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Funds_WalletAccounts_WalletAccountId",
                table: "Funds");

            migrationBuilder.AddForeignKey(
                name: "FK_Funds_WalletAccounts_WalletAccountId",
                table: "Funds",
                column: "WalletAccountId",
                principalTable: "WalletAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Loans_Funds_FundId",
                table: "Loans",
                column: "FundId",
                principalTable: "Funds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
