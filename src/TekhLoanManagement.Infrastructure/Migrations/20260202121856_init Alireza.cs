using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TekhLoanManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initAlireza : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "ProfitRate",
                table: "Loans",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfitRate",
                table: "Loans");
        }
    }
}
