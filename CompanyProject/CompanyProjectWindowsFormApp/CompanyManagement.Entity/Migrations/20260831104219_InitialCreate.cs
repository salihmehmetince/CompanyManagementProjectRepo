using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CompanyManagement.Entity.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CompanyOwners",
                columns: table => new
                {
                    CompanyOwnerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyOwnerIdentityNumber = table.Column<string>(maxLength: 15, nullable: false),
                    CompanyOwnerName = table.Column<string>(maxLength: 30, nullable: false),
                    CompanyOwnerSurname = table.Column<string>(maxLength: 30, nullable: false),
                    CompanyOwnerBirthday = table.Column<DateTime>(nullable: false),
                    CompanyOwnerTelephoneNumber = table.Column<string>(maxLength: 15, nullable: false),
                    CompanyOwnerEmail = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyOwners", x => x.CompanyOwnerId);
                });

            migrationBuilder.CreateTable(
                name: "CompanyTypes",
                columns: table => new
                {
                    CompanyTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyTypeName = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyTypes", x => x.CompanyTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(maxLength: 30, nullable: false),
                    CustomerSurname = table.Column<string>(maxLength: 30, nullable: false),
                    CustomerTelephoneNumber = table.Column<string>(maxLength: 15, nullable: false),
                    CustomerEmail = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "DepartmentTypes",
                columns: table => new
                {
                    DepartmentTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentTypes", x => x.DepartmentTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Meetings",
                columns: table => new
                {
                    MeetingId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MeetingPlot = table.Column<string>(maxLength: 150, nullable: false),
                    MeetingDetail = table.Column<string>(maxLength: 1000, nullable: true),
                    MeetingPlace = table.Column<string>(maxLength: 200, nullable: false),
                    MeetingDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meetings", x => x.MeetingId);
                });

            migrationBuilder.CreateTable(
                name: "PaymentTypes",
                columns: table => new
                {
                    PaymentTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentTypeName = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentTypes", x => x.PaymentTypeId);
                });

            migrationBuilder.CreateTable(
                name: "ProductOrServiceTypes",
                columns: table => new
                {
                    ProductOrServiceTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductOrServiceTypeName = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductOrServiceTypes", x => x.ProductOrServiceTypeId);
                });

            migrationBuilder.CreateTable(
                name: "ProfessionTypes",
                columns: table => new
                {
                    ProfessionTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfessionName = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfessionTypes", x => x.ProfessionTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    TaskId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaskName = table.Column<string>(maxLength: 150, nullable: false),
                    TaskDetails = table.Column<string>(maxLength: 1000, nullable: true),
                    TaskBeginningDate = table.Column<DateTime>(nullable: false),
                    IsCompleted = table.Column<bool>(nullable: false),
                    DaysPassedToComplete = table.Column<int>(nullable: false),
                    TaskFinishDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.TaskId);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    CompanyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(maxLength: 30, nullable: false),
                    CompanyAddress = table.Column<string>(maxLength: 250, nullable: false),
                    CompanyOwnerTelephoneNumber = table.Column<string>(maxLength: 15, nullable: true),
                    CompanyOwnerEmail = table.Column<string>(maxLength: 100, nullable: true),
                    CompanyTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.CompanyId);
                    table.ForeignKey(
                        name: "FK_Companies_CompanyTypes_CompanyTypeId",
                        column: x => x.CompanyTypeId,
                        principalTable: "CompanyTypes",
                        principalColumn: "CompanyTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MeetingHasCompanyOwners",
                columns: table => new
                {
                    MeetingHasCompanyOwnerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MeetingId = table.Column<int>(nullable: false),
                    CompanyOwnerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeetingHasCompanyOwners", x => x.MeetingHasCompanyOwnerId);
                    table.ForeignKey(
                        name: "FK_MeetingHasCompanyOwners_CompanyOwners_CompanyOwnerId",
                        column: x => x.CompanyOwnerId,
                        principalTable: "CompanyOwners",
                        principalColumn: "CompanyOwnerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MeetingHasCompanyOwners_Meetings_MeetingId",
                        column: x => x.MeetingId,
                        principalTable: "Meetings",
                        principalColumn: "MeetingId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductsOrServices",
                columns: table => new
                {
                    ProductOrServiceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductOrServiceName = table.Column<string>(maxLength: 150, nullable: false),
                    IsProductOrService = table.Column<bool>(nullable: false),
                    ProductOrServiceTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductsOrServices", x => x.ProductOrServiceId);
                    table.ForeignKey(
                        name: "FK_ProductsOrServices_ProductOrServiceTypes_ProductOrServiceTypeId",
                        column: x => x.ProductOrServiceTypeId,
                        principalTable: "ProductOrServiceTypes",
                        principalColumn: "ProductOrServiceTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeName = table.Column<string>(maxLength: 30, nullable: false),
                    EmployeeSurname = table.Column<string>(maxLength: 30, nullable: false),
                    EmployeeIdentityNumber = table.Column<string>(maxLength: 15, nullable: false),
                    EmployeeBirthday = table.Column<DateTime>(nullable: false),
                    EmployeeTelephoneNumber = table.Column<string>(maxLength: 15, nullable: false),
                    EmployeeEmail = table.Column<string>(maxLength: 100, nullable: false),
                    EmployeeAddress = table.Column<string>(maxLength: 250, nullable: true),
                    EmployeeSalary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EmployeeYearsSpent = table.Column<int>(nullable: false),
                    EmployeeProfessionTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Employees_ProfessionTypes_EmployeeProfessionTypeId",
                        column: x => x.EmployeeProfessionTypeId,
                        principalTable: "ProfessionTypes",
                        principalColumn: "ProfessionTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TaskHasCompanyOwners",
                columns: table => new
                {
                    TaskHasCompanyOwnerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaskId = table.Column<int>(nullable: false),
                    CompanyOwnerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskHasCompanyOwners", x => x.TaskHasCompanyOwnerId);
                    table.ForeignKey(
                        name: "FK_TaskHasCompanyOwners_CompanyOwners_CompanyOwnerId",
                        column: x => x.CompanyOwnerId,
                        principalTable: "CompanyOwners",
                        principalColumn: "CompanyOwnerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TaskHasCompanyOwners_Tasks_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Tasks",
                        principalColumn: "TaskId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CompanyHasDepartmentTypes",
                columns: table => new
                {
                    CompanyHasDepartmentTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(nullable: false),
                    DepartmentTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyHasDepartmentTypes", x => x.CompanyHasDepartmentTypeId);
                    table.ForeignKey(
                        name: "FK_CompanyHasDepartmentTypes_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CompanyHasDepartmentTypes_DepartmentTypes_DepartmentTypeId",
                        column: x => x.DepartmentTypeId,
                        principalTable: "DepartmentTypes",
                        principalColumn: "DepartmentTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CompanyOwnerHasCompanies",
                columns: table => new
                {
                    CompanyOwnerHasCompanyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyOwnerId = table.Column<int>(nullable: false),
                    CompanyOwnerPercent = table.Column<int>(nullable: false),
                    CompanyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyOwnerHasCompanies", x => x.CompanyOwnerHasCompanyId);
                    table.ForeignKey(
                        name: "FK_CompanyOwnerHasCompanies_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CompanyOwnerHasCompanies_CompanyOwners_CompanyOwnerId",
                        column: x => x.CompanyOwnerId,
                        principalTable: "CompanyOwners",
                        principalColumn: "CompanyOwnerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CompanyHasProductOrServices",
                columns: table => new
                {
                    CompanyHasProductOrServiceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(nullable: false),
                    ProductOrServiceId = table.Column<int>(nullable: false),
                    CompanyHasProductOrServiceQuantity = table.Column<decimal>(nullable: false),
                    CompanyHasProductOrServicePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyHasProductOrServices", x => x.CompanyHasProductOrServiceId);
                    table.ForeignKey(
                        name: "FK_CompanyHasProductOrServices_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CompanyHasProductOrServices_ProductsOrServices_ProductOrServiceId",
                        column: x => x.ProductOrServiceId,
                        principalTable: "ProductsOrServices",
                        principalColumn: "ProductOrServiceId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CompanyGivesBonusToEmployees",
                columns: table => new
                {
                    CompanyGivesBonusToEmployeeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: false),
                    CompanyGivesBonusToEmployeeDate = table.Column<DateTime>(nullable: false),
                    CompanyGivesBonusToEmployeeQuantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyGivesBonusToEmployees", x => x.CompanyGivesBonusToEmployeeId);
                    table.ForeignKey(
                        name: "FK_CompanyGivesBonusToEmployees_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CompanyGivesBonusToEmployees_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MeetingHasEmployees",
                columns: table => new
                {
                    MeetingHasEmployeeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MeetingId = table.Column<int>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeetingHasEmployees", x => x.MeetingHasEmployeeId);
                    table.ForeignKey(
                        name: "FK_MeetingHasEmployees_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MeetingHasEmployees_Meetings_MeetingId",
                        column: x => x.MeetingId,
                        principalTable: "Meetings",
                        principalColumn: "MeetingId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TaskHasEmployees",
                columns: table => new
                {
                    TaskHasEmployeeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaskId = table.Column<int>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskHasEmployees", x => x.TaskHasEmployeeId);
                    table.ForeignKey(
                        name: "FK_TaskHasEmployees_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TaskHasEmployees_Tasks_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Tasks",
                        principalColumn: "TaskId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeHasCompanyHasDepartmentTypes",
                columns: table => new
                {
                    EmployeeHasCompanyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(nullable: false),
                    CompanyHasDepartmentTypeId = table.Column<int>(nullable: false),
                    CompanyId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeHasCompanyHasDepartmentTypes", x => x.EmployeeHasCompanyId);
                    table.ForeignKey(
                        name: "FK_EmployeeHasCompanyHasDepartmentTypes_CompanyHasDepartmentTypes_CompanyHasDepartmentTypeId",
                        column: x => x.CompanyHasDepartmentTypeId,
                        principalTable: "CompanyHasDepartmentTypes",
                        principalColumn: "CompanyHasDepartmentTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmployeeHasCompanyHasDepartmentTypes_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmployeeHasCompanyHasDepartmentTypes_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CustomerBuysCompanyHasProductOrServices",
                columns: table => new
                {
                    CustomerBuysCompanyHasProductOrServiceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(nullable: false),
                    CompanyHasProductOrServiceId = table.Column<int>(nullable: false),
                    PaymentTypeId = table.Column<int>(nullable: false),
                    CustomerBuysCompanyHasProductOrServiceQuantity = table.Column<decimal>(nullable: false),
                    CustomerBuysCompanyHasProductOrServiceDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerBuysCompanyHasProductOrServices", x => x.CustomerBuysCompanyHasProductOrServiceId);
                    table.ForeignKey(
                        name: "FK_CustomerBuysCompanyHasProductOrServices_CompanyHasProductOrServices_CompanyHasProductOrServiceId",
                        column: x => x.CompanyHasProductOrServiceId,
                        principalTable: "CompanyHasProductOrServices",
                        principalColumn: "CompanyHasProductOrServiceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CustomerBuysCompanyHasProductOrServices_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CustomerBuysCompanyHasProductOrServices_PaymentTypes_PaymentTypeId",
                        column: x => x.PaymentTypeId,
                        principalTable: "PaymentTypes",
                        principalColumn: "PaymentTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Companies_CompanyTypeId",
                table: "Companies",
                column: "CompanyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyGivesBonusToEmployees_CompanyId",
                table: "CompanyGivesBonusToEmployees",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyGivesBonusToEmployees_EmployeeId",
                table: "CompanyGivesBonusToEmployees",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyHasDepartmentTypes_CompanyId",
                table: "CompanyHasDepartmentTypes",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyHasDepartmentTypes_DepartmentTypeId",
                table: "CompanyHasDepartmentTypes",
                column: "DepartmentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyHasProductOrServices_CompanyId",
                table: "CompanyHasProductOrServices",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyHasProductOrServices_ProductOrServiceId",
                table: "CompanyHasProductOrServices",
                column: "ProductOrServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyOwnerHasCompanies_CompanyId",
                table: "CompanyOwnerHasCompanies",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyOwnerHasCompanies_CompanyOwnerId",
                table: "CompanyOwnerHasCompanies",
                column: "CompanyOwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerBuysCompanyHasProductOrServices_CompanyHasProductOrServiceId",
                table: "CustomerBuysCompanyHasProductOrServices",
                column: "CompanyHasProductOrServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerBuysCompanyHasProductOrServices_CustomerId",
                table: "CustomerBuysCompanyHasProductOrServices",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerBuysCompanyHasProductOrServices_PaymentTypeId",
                table: "CustomerBuysCompanyHasProductOrServices",
                column: "PaymentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeHasCompanyHasDepartmentTypes_CompanyHasDepartmentTypeId",
                table: "EmployeeHasCompanyHasDepartmentTypes",
                column: "CompanyHasDepartmentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeHasCompanyHasDepartmentTypes_CompanyId",
                table: "EmployeeHasCompanyHasDepartmentTypes",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeHasCompanyHasDepartmentTypes_EmployeeId",
                table: "EmployeeHasCompanyHasDepartmentTypes",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_EmployeeProfessionTypeId",
                table: "Employees",
                column: "EmployeeProfessionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MeetingHasCompanyOwners_CompanyOwnerId",
                table: "MeetingHasCompanyOwners",
                column: "CompanyOwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_MeetingHasCompanyOwners_MeetingId",
                table: "MeetingHasCompanyOwners",
                column: "MeetingId");

            migrationBuilder.CreateIndex(
                name: "IX_MeetingHasEmployees_EmployeeId",
                table: "MeetingHasEmployees",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_MeetingHasEmployees_MeetingId",
                table: "MeetingHasEmployees",
                column: "MeetingId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsOrServices_ProductOrServiceTypeId",
                table: "ProductsOrServices",
                column: "ProductOrServiceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskHasCompanyOwners_CompanyOwnerId",
                table: "TaskHasCompanyOwners",
                column: "CompanyOwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskHasCompanyOwners_TaskId",
                table: "TaskHasCompanyOwners",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskHasEmployees_EmployeeId",
                table: "TaskHasEmployees",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskHasEmployees_TaskId",
                table: "TaskHasEmployees",
                column: "TaskId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyGivesBonusToEmployees");

            migrationBuilder.DropTable(
                name: "CompanyOwnerHasCompanies");

            migrationBuilder.DropTable(
                name: "CustomerBuysCompanyHasProductOrServices");

            migrationBuilder.DropTable(
                name: "EmployeeHasCompanyHasDepartmentTypes");

            migrationBuilder.DropTable(
                name: "MeetingHasCompanyOwners");

            migrationBuilder.DropTable(
                name: "MeetingHasEmployees");

            migrationBuilder.DropTable(
                name: "TaskHasCompanyOwners");

            migrationBuilder.DropTable(
                name: "TaskHasEmployees");

            migrationBuilder.DropTable(
                name: "CompanyHasProductOrServices");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "PaymentTypes");

            migrationBuilder.DropTable(
                name: "CompanyHasDepartmentTypes");

            migrationBuilder.DropTable(
                name: "Meetings");

            migrationBuilder.DropTable(
                name: "CompanyOwners");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "ProductsOrServices");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "DepartmentTypes");

            migrationBuilder.DropTable(
                name: "ProfessionTypes");

            migrationBuilder.DropTable(
                name: "ProductOrServiceTypes");

            migrationBuilder.DropTable(
                name: "CompanyTypes");
        }
    }
}
