using Microsoft.EntityFrameworkCore.Migrations;

namespace CompanyManagement.Entity.Migrations
{
    public partial class AddAffectSalaryToCompanyGivesBonusToEmployee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AffectSalary",
                table: "CompanyGivesBonusToEmployees",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AffectSalary",
                table: "CompanyGivesBonusToEmployees");
        }
    }
}
