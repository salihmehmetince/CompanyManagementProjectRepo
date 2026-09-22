using Microsoft.EntityFrameworkCore.Migrations;

namespace CompanyManagement.Entity.Migrations
{
    public partial class ChangeCompanyOwnerPercentageToDecimal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "CompanyOwnerPercent",
                table: "CompanyOwnerHasCompanies",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CompanyOwnerPercent",
                table: "CompanyOwnerHasCompanies",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal));
        }
    }
}
