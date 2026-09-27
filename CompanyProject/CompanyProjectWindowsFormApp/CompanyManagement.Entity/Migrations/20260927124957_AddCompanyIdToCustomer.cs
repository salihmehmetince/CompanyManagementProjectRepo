using Microsoft.EntityFrameworkCore.Migrations;

namespace CompanyManagement.Entity.Migrations
{
    public partial class AddCompanyIdToCustomer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "Customers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.Sql(@"
        UPDATE Customers
        SET CompanyId = (
            SELECT TOP 1 CompanyId
            FROM Companies
            ORDER BY NEWID()
        )
    ");
            migrationBuilder.CreateIndex(
                name: "IX_Customers_CompanyId",
                table: "Customers",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Companies_CompanyId",
                table: "Customers",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "CompanyId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Companies_CompanyId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_CompanyId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Customers");
        }
    }
}
