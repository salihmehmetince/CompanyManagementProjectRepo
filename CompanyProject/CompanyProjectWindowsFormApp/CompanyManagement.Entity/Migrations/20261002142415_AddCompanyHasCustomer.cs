using Microsoft.EntityFrameworkCore.Migrations;

namespace CompanyManagement.Entity.Migrations
{
    public partial class AddCompanyHasCustomer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "CompanyHasCustomers",
                columns: table => new
                {
                    CompanyHasCustomerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),

                    CompanyId = table.Column<int>(nullable: false),

                    CustomerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey(
                        "PK_CompanyHasCustomers",
                        x => x.CompanyHasCustomerId);

                    table.ForeignKey(
                        name: "FK_CompanyHasCustomers_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Restrict);

                    table.ForeignKey(
                        name: "FK_CompanyHasCustomers_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompanyHasCustomers_CompanyId",
                table: "CompanyHasCustomers",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyHasCustomers_CustomerId",
                table: "CompanyHasCustomers",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyHasCustomers");

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "Customers",
                nullable: false,
                defaultValue: 0);

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
    }
}

