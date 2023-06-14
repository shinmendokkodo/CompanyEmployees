using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CompanyEmployees.Migrations
{
    /// <inheritdoc />
    public partial class InitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.CompanyId);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Employees_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "CompanyId", "Address", "Country", "Name" },
                values: new object[,]
                {
                    { new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), "312 Forest Avenue, BF 923", "USA", "Admin Solutions Ltd" },
                    { new Guid("7e9f0f5c-58ef-4a77-913f-3e408054e1bb"), "45 Ocean Street, Sydney, NSW 2000", "Australia", "Oceanic Software Ltd" },
                    { new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "583 Wall Dr. Gwynn Oak, MD 21207", "USA", "IT Solutions Ltd" },
                    { new Guid("eb23df43-47b3-4675-9b84-2788574e2e95"), "Suite 1, 1 Baker Street, London, W1U 6WG", "UK", "CloudNet Technologies" },
                    { new Guid("f91d276d-2488-4e68-bf2f-85996f029daf"), "987 Maple Drive, Los Angeles, CA 90210", "USA", "Vector Digital Corp" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "Age", "CompanyId", "Name", "Position" },
                values: new object[,]
                {
                    { new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"), 35, new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), "Kane Miller", "Administrator" },
                    { new Guid("3c4cd4f9-913f-41e1-a9dd-5c8f8b2b6c2a"), 35, new Guid("eb23df43-47b3-4675-9b84-2788574e2e95"), "Oliver Brown", "System Analyst" },
                    { new Guid("80abbca8-664d-4b20-b5de-024705497d4a"), 26, new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "Sam Raiden", "Software developer" },
                    { new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"), 30, new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "Jana McLeaf", "Software developer" },
                    { new Guid("a5a65b91-b3e6-4f78-a40c-6b72a5a1f827"), 29, new Guid("7e9f0f5c-58ef-4a77-913f-3e408054e1bb"), "Emily Parker", "UI/UX Designer" },
                    { new Guid("aee7b7f5-345c-4a46-8aec-0c6c9a6f9b1b"), 32, new Guid("f91d276d-2488-4e68-bf2f-85996f029daf"), "Adam Scott", "Software Developer" },
                    { new Guid("cb4b5c89-35f1-4bb6-b810-66a6f2c6b2db"), 27, new Guid("f91d276d-2488-4e68-bf2f-85996f029daf"), "Sophia Davis", "Data Analyst" },
                    { new Guid("f0e2058c-8745-4a3a-9fdc-058a4f55a802"), 33, new Guid("7e9f0f5c-58ef-4a77-913f-3e408054e1bb"), "Liam Smith", "IT Support Specialist" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_CompanyId",
                table: "Employees",
                column: "CompanyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}
