using Microsoft.EntityFrameworkCore.Migrations;

namespace CompanyManagement.Entity.Migrations
{
    public partial class RemoveDaysPassedToComplete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DaysPassedToComplete",
                table: "Tasks");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DaysPassedToComplete",
                table: "Tasks",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
