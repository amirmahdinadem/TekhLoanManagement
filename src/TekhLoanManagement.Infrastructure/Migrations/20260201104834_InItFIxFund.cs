using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TekhLoanManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InItFIxFund : Migration
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

            migrationBuilder.DropIndex(
                name: "IX_Loans_FundId",
                table: "Loans");

            migrationBuilder.DropColumn(
                name: "LoanAmountLimit",
                table: "Funds");

            migrationBuilder.AlterColumn<int>(
                name: "NumberOfInstallments",
                table: "Funds",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Funds",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "SeedMoney",
                table: "Funds",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddForeignKey(
                name: "FK_Funds_WalletAccounts_WalletAccountId",
                table: "Funds",
                column: "WalletAccountId",
                principalTable: "WalletAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Funds_WalletAccounts_WalletAccountId",
                table: "Funds");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Funds");

            migrationBuilder.DropColumn(
                name: "SeedMoney",
                table: "Funds");

            migrationBuilder.AlterColumn<double>(
                name: "NumberOfInstallments",
                table: "Funds",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<double>(
                name: "LoanAmountLimit",
                table: "Funds",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateIndex(
                name: "IX_Loans_FundId",
                table: "Loans",
                column: "FundId");

            migrationBuilder.AddForeignKey(
                name: "FK_Funds_WalletAccounts_WalletAccountId",
                table: "Funds",
                column: "WalletAccountId",
                principalTable: "WalletAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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
