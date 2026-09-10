using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CompanyManagement.Entity.Migrations
{
    public partial class AddProductOrServiceImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "ProductOrServiceImage",
                table: "ProductsOrServices",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductOrServiceImage",
                table: "ProductsOrServices");
        }
    }
}
