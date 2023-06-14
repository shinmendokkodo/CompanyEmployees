using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CompanyEmployees.Migrations
{
    /// <inheritdoc />
    public partial class InitialDataSeedData2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "Age", "CompanyId", "Name", "Position" },
                values: new object[,]
                {
                    { new Guid("061e682f-5987-41a1-97c5-0a8b6f83e673"), 30, new Guid("e1bce704-7cbb-4b10-beda-d97e9aef9147"), "Frank Sinatra", "IT Consultant" },
                    { new Guid("0baee42d-cb8f-4d67-8a82-c91335d479b8"), 30, new Guid("d69a6a59-a7e8-4c8f-b802-95d2b4b58ac7"), "Oliver Smith", "Web Developer" },
                    { new Guid("0d6a92bf-8c8c-4a6e-8b56-86e8742d2479"), 29, new Guid("d69a6a59-a7e8-4c8f-b802-95d2b4b58ac7"), "Jacob Thomas", "IT Support Specialist" },
                    { new Guid("10d5c76c-4754-41f6-9220-9326a4e1a583"), 41, new Guid("f9a92769-354f-4d23-85b2-16f6af0b84a1"), "Andrea Bocelli", "UI/UX Designer" },
                    { new Guid("12fa66df-1dd2-4112-93cd-c31014a0b777"), 28, new Guid("ba56711f-692a-4ed6-9451-b3f229f9f468"), "Amelia Davis", "Software Developer" },
                    { new Guid("20b3f781-88e0-42c5-b678-e8b3a625f22d"), 26, new Guid("ba56711f-692a-4ed6-9451-b3f229f9f468"), "Harry Williams", "Software Engineer" },
                    { new Guid("56fa03f4-49fb-44ba-b045-9bc13c8c5821"), 33, new Guid("d69a6a59-a7e8-4c8f-b802-95d2b4b58ac7"), "Charlie Parker", "Backend Developer" },
                    { new Guid("5b5ffbef-e367-4294-b847-3e3b7a8e84e8"), 35, new Guid("7304a687-8970-4a37-b3e7-0bf74a5b6456"), "Ian Freeman", "Data Analyst" },
                    { new Guid("66f9f41a-0d7f-4df3-9b9a-c7533b57c742"), 33, new Guid("7304a687-8970-4a37-b3e7-0bf74a5b6456"), "Ethan Evans", "Network Engineer" },
                    { new Guid("85daff91-dffa-47f1-922d-b8c994733fb3"), 27, new Guid("f9a92769-354f-4d23-85b2-16f6af0b84a1"), "Sarah Vaughan", "QA Engineer" },
                    { new Guid("87cb4988-a5d2-4b36-b5d3-71184f6e3f75"), 26, new Guid("d69a6a59-a7e8-4c8f-b802-95d2b4b58ac7"), "Liam Johnson", "Network Administrator" },
                    { new Guid("8a34cfdd-8c59-4303-9a81-4fdbe7ecb26b"), 29, new Guid("e1bce704-7cbb-4b10-beda-d97e9aef9147"), "Ella Fitzgerald", "Frontend Developer" },
                    { new Guid("8bc3a24d-7337-4c55-b8c9-c9b96b9c8a8e"), 28, new Guid("7304a687-8970-4a37-b3e7-0bf74a5b6456"), "James Wilson", "Data Scientist" },
                    { new Guid("93547f13-d909-4ca9-9696-22dcbc9b0ee9"), 31, new Guid("e1bce704-7cbb-4b10-beda-d97e9aef9147"), "Noah Patterson", "IT Consultant" },
                    { new Guid("ad24c897-1cde-4b0b-828d-b15c4a07a24d"), 28, new Guid("d69a6a59-a7e8-4c8f-b802-95d2b4b58ac7"), "George Johnson", "Data Analyst" },
                    { new Guid("bc8903a5-cb9e-4b28-a5aa-3c7598289f66"), 36, new Guid("ba56711f-692a-4ed6-9451-b3f229f9f468"), "Dizzy Gillespie", "Project Manager" },
                    { new Guid("c72e7e23-2761-42cf-8962-896ada4425c1"), 32, new Guid("ba56711f-692a-4ed6-9451-b3f229f9f468"), "Jack Jones", "Systems Administrator" },
                    { new Guid("c951255a-0e8c-4f6a-9836-8dd3a8d0c3d7"), 31, new Guid("d69a6a59-a7e8-4c8f-b802-95d2b4b58ac7"), "William Taylor", "Software Tester" },
                    { new Guid("ce14b1d1-8133-4279-a407-6bda3a3a8b92"), 25, new Guid("f9a92769-354f-4d23-85b2-16f6af0b84a1"), "Charlie Brown", "Database Administrator" },
                    { new Guid("e09b94d2-d5dd-4f80-90d7-35353c49a07f"), 34, new Guid("f9a92769-354f-4d23-85b2-16f6af0b84a1"), "Thomas Davies", "QA Engineer" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("061e682f-5987-41a1-97c5-0a8b6f83e673"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("0baee42d-cb8f-4d67-8a82-c91335d479b8"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("0d6a92bf-8c8c-4a6e-8b56-86e8742d2479"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("10d5c76c-4754-41f6-9220-9326a4e1a583"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("12fa66df-1dd2-4112-93cd-c31014a0b777"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("20b3f781-88e0-42c5-b678-e8b3a625f22d"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("56fa03f4-49fb-44ba-b045-9bc13c8c5821"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("5b5ffbef-e367-4294-b847-3e3b7a8e84e8"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("66f9f41a-0d7f-4df3-9b9a-c7533b57c742"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("85daff91-dffa-47f1-922d-b8c994733fb3"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("87cb4988-a5d2-4b36-b5d3-71184f6e3f75"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("8a34cfdd-8c59-4303-9a81-4fdbe7ecb26b"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("8bc3a24d-7337-4c55-b8c9-c9b96b9c8a8e"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("93547f13-d909-4ca9-9696-22dcbc9b0ee9"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("ad24c897-1cde-4b0b-828d-b15c4a07a24d"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("bc8903a5-cb9e-4b28-a5aa-3c7598289f66"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("c72e7e23-2761-42cf-8962-896ada4425c1"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("c951255a-0e8c-4f6a-9836-8dd3a8d0c3d7"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("ce14b1d1-8133-4279-a407-6bda3a3a8b92"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("e09b94d2-d5dd-4f80-90d7-35353c49a07f"));
        }
    }
}
