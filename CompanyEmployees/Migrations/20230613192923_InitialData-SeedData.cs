using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CompanyEmployees.Migrations
{
    /// <inheritdoc />
    public partial class InitialDataSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "CompanyId", "Address", "Country", "Name" },
                values: new object[,]
                {
                    { new Guid("7304a687-8970-4a37-b3e7-0bf74a5b6456"), "742 Evergreen Terrace, Springfield, IL 62701", "USA", "Stratosphere Technologies" },
                    { new Guid("ba56711f-692a-4ed6-9451-b3f229f9f468"), "2-11-3 Meguro, Meguro-ku, Tokyo 153-0063", "Japan", "Helix AI" },
                    { new Guid("d69a6a59-a7e8-4c8f-b802-95d2b4b58ac7"), "6782 Pine St. Toronto, ON M4B 1V6", "Canada", "Polaris Software" },
                    { new Guid("e1bce704-7cbb-4b10-beda-d97e9aef9147"), "210 Great Portland Street, London, W1W 5AF", "UK", "Equinox Digital" },
                    { new Guid("f9a92769-354f-4d23-85b2-16f6af0b84a1"), "Rua da Consolação, 2222, São Paulo - SP, 01302-000", "Brazil", "Nimbus Innovations" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "Age", "CompanyId", "Name", "Position" },
                values: new object[,]
                {
                    { new Guid("0d3a45e6-876b-4ca3-92eb-4167eb7ef621"), 34, new Guid("d69a6a59-a7e8-4c8f-b802-95d2b4b58ac7"), "Evelyn Clarke", "Backend Developer" },
                    { new Guid("1e7f9e6c-3fab-4d37-8b48-6922a60e799a"), 29, new Guid("ba56711f-692a-4ed6-9451-b3f229f9f468"), "Jessica Scott", "Cloud Architect" },
                    { new Guid("234fd123-89a2-4a47-a4c9-5b7e4f7e59e6"), 32, new Guid("ba56711f-692a-4ed6-9451-b3f229f9f468"), "Zachary Martin", "IT Manager" },
                    { new Guid("23b5e303-96d6-4ba2-8d52-2e2a8c30ab67"), 36, new Guid("f9a92769-354f-4d23-85b2-16f6af0b84a1"), "Lucas Garcia", "Data Analyst" },
                    { new Guid("265f40c3-0cb7-4a3d-9169-32b110dbb557"), 30, new Guid("f9a92769-354f-4d23-85b2-16f6af0b84a1"), "George Lewis", "Data Engineer" },
                    { new Guid("3785fa0b-8106-4c53-9053-ef9b2a3a9308"), 27, new Guid("d69a6a59-a7e8-4c8f-b802-95d2b4b58ac7"), "Leo Hall", "Web Designer" },
                    { new Guid("3edc9737-b355-4a6a-9ecf-c8eac566c1b8"), 35, new Guid("f9a92769-354f-4d23-85b2-16f6af0b84a1"), "Lucas Alves", "Data Scientist" },
                    { new Guid("42d5b53a-9dba-46ef-8127-72c5ec75cb4a"), 34, new Guid("ba56711f-692a-4ed6-9451-b3f229f9f468"), "William Thomas", "Software Developer" },
                    { new Guid("5a98cd2d-bb8d-4021-8b21-d45551d3c288"), 32, new Guid("d69a6a59-a7e8-4c8f-b802-95d2b4b58ac7"), "Jake Mitchell", "Web Developer" },
                    { new Guid("5b34df28-fdc8-4a2b-a9a6-1f8b06248831"), 27, new Guid("7304a687-8970-4a37-b3e7-0bf74a5b6456"), "Elijah Davis", "Software Engineer" },
                    { new Guid("64a183c9-93d7-4372-bef8-a2f40f7e520d"), 29, new Guid("e1bce704-7cbb-4b10-beda-d97e9aef9147"), "Noah Williams", "System Analyst" },
                    { new Guid("6e6d4c1f-b025-47c2-9e73-e84e5c42bc21"), 33, new Guid("d69a6a59-a7e8-4c8f-b802-95d2b4b58ac7"), "James Wilson", "IT Support Specialist" },
                    { new Guid("756b50c1-853f-4c07-b495-304f7164118a"), 35, new Guid("f9a92769-354f-4d23-85b2-16f6af0b84a1"), "Theo Taylor", "Data Scientist" },
                    { new Guid("7dc92c9f-6ad1-4117-9677-27a45f1a9a35"), 30, new Guid("7304a687-8970-4a37-b3e7-0bf74a5b6456"), "Henry Rodriguez", "Systems Engineer" },
                    { new Guid("8233b39a-2c0b-4cf2-8bca-48f3728eb6a3"), 26, new Guid("e1bce704-7cbb-4b10-beda-d97e9aef9147"), "Sophia Wright", "Network Engineer" },
                    { new Guid("891bb83c-b2f6-4c88-830a-1b7681f50fe0"), 33, new Guid("ba56711f-692a-4ed6-9451-b3f229f9f468"), "Haruto Yamada", "IT Support Specialist" },
                    { new Guid("9d7e8df3-55d9-4596-987c-6a3d0469aae3"), 32, new Guid("ba56711f-692a-4ed6-9451-b3f229f9f468"), "Isla Walker", "UI/UX Designer" },
                    { new Guid("9db9db79-3434-4db6-925d-bb3ed6e6b213"), 32, new Guid("d69a6a59-a7e8-4c8f-b802-95d2b4b58ac7"), "Alexander Martinez", "IT Coordinator" },
                    { new Guid("9f47d9c4-70eb-4662-a3cd-ec5fa1c602a7"), 27, new Guid("7304a687-8970-4a37-b3e7-0bf74a5b6456"), "Emily Clarke", "Project Manager" },
                    { new Guid("abd7b2f7-8cb8-40c3-a6d6-ae6196cde283"), 31, new Guid("d69a6a59-a7e8-4c8f-b802-95d2b4b58ac7"), "Owen Baker", "Backend Developer" },
                    { new Guid("abf0ed9e-c23a-4a8e-97ea-d1486d837972"), 36, new Guid("e1bce704-7cbb-4b10-beda-d97e9aef9147"), "Freddie Harris", "Product Manager" },
                    { new Guid("b3d702fc-a551-40b2-b333-7ae0979c8b5e"), 37, new Guid("7304a687-8970-4a37-b3e7-0bf74a5b6456"), "Jacob Turner", "Frontend Developer" },
                    { new Guid("b3fa5067-e7c5-4618-9f34-3a8a6e8827ed"), 32, new Guid("ba56711f-692a-4ed6-9451-b3f229f9f468"), "Liam Johnson", "Web Developer" },
                    { new Guid("bb8a2f24-8b36-44b7-bca4-c593aadd5f9e"), 37, new Guid("7304a687-8970-4a37-b3e7-0bf74a5b6456"), "Oscar King", "Database Administrator" },
                    { new Guid("cd145578-9e91-4d08-9a00-4b3cbe9c5c47"), 28, new Guid("d69a6a59-a7e8-4c8f-b802-95d2b4b58ac7"), "Matilda Young", "Scrum Master" },
                    { new Guid("d859f253-8eb0-43be-9480-911210b6ca00"), 34, new Guid("f9a92769-354f-4d23-85b2-16f6af0b84a1"), "Harrison Campbell", "System Administrator" },
                    { new Guid("e2dcedf3-51b8-4a7b-853b-9d2954e2ef32"), 27, new Guid("e1bce704-7cbb-4b10-beda-d97e9aef9147"), "Olivia Baker", "Software Engineer" },
                    { new Guid("e8a79a80-23cd-42d1-88b2-c8e68e484a43"), 28, new Guid("7304a687-8970-4a37-b3e7-0bf74a5b6456"), "Charlie White", "DevOps Engineer" },
                    { new Guid("f5eaeb2f-b2f2-4fdb-9358-a6e582f27f2c"), 26, new Guid("e1bce704-7cbb-4b10-beda-d97e9aef9147"), "Mason Phillips", "Quality Assurance" },
                    { new Guid("f8c9f6fa-61ba-45f6-9107-0a3d688ba2d9"), 28, new Guid("e1bce704-7cbb-4b10-beda-d97e9aef9147"), "Benjamin Martinez", "Network Administrator" },
                    { new Guid("fb133c53-33a6-4f94-9623-4896fd4527cf"), 35, new Guid("f9a92769-354f-4d23-85b2-16f6af0b84a1"), "Oliver Brown", "Data Scientist" },
                    { new Guid("fbdf89c3-66af-455b-9b26-3b1c8b2a3f9d"), 29, new Guid("7304a687-8970-4a37-b3e7-0bf74a5b6456"), "Jessica Walters", "System Analyst" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("0d3a45e6-876b-4ca3-92eb-4167eb7ef621"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("1e7f9e6c-3fab-4d37-8b48-6922a60e799a"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("234fd123-89a2-4a47-a4c9-5b7e4f7e59e6"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("23b5e303-96d6-4ba2-8d52-2e2a8c30ab67"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("265f40c3-0cb7-4a3d-9169-32b110dbb557"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("3785fa0b-8106-4c53-9053-ef9b2a3a9308"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("3edc9737-b355-4a6a-9ecf-c8eac566c1b8"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("42d5b53a-9dba-46ef-8127-72c5ec75cb4a"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("5a98cd2d-bb8d-4021-8b21-d45551d3c288"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("5b34df28-fdc8-4a2b-a9a6-1f8b06248831"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("64a183c9-93d7-4372-bef8-a2f40f7e520d"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("6e6d4c1f-b025-47c2-9e73-e84e5c42bc21"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("756b50c1-853f-4c07-b495-304f7164118a"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("7dc92c9f-6ad1-4117-9677-27a45f1a9a35"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("8233b39a-2c0b-4cf2-8bca-48f3728eb6a3"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("891bb83c-b2f6-4c88-830a-1b7681f50fe0"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("9d7e8df3-55d9-4596-987c-6a3d0469aae3"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("9db9db79-3434-4db6-925d-bb3ed6e6b213"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("9f47d9c4-70eb-4662-a3cd-ec5fa1c602a7"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("abd7b2f7-8cb8-40c3-a6d6-ae6196cde283"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("abf0ed9e-c23a-4a8e-97ea-d1486d837972"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("b3d702fc-a551-40b2-b333-7ae0979c8b5e"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("b3fa5067-e7c5-4618-9f34-3a8a6e8827ed"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("bb8a2f24-8b36-44b7-bca4-c593aadd5f9e"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("cd145578-9e91-4d08-9a00-4b3cbe9c5c47"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("d859f253-8eb0-43be-9480-911210b6ca00"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("e2dcedf3-51b8-4a7b-853b-9d2954e2ef32"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("e8a79a80-23cd-42d1-88b2-c8e68e484a43"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("f5eaeb2f-b2f2-4fdb-9358-a6e582f27f2c"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("f8c9f6fa-61ba-45f6-9107-0a3d688ba2d9"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("fb133c53-33a6-4f94-9623-4896fd4527cf"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("fbdf89c3-66af-455b-9b26-3b1c8b2a3f9d"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: new Guid("7304a687-8970-4a37-b3e7-0bf74a5b6456"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: new Guid("ba56711f-692a-4ed6-9451-b3f229f9f468"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: new Guid("d69a6a59-a7e8-4c8f-b802-95d2b4b58ac7"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: new Guid("e1bce704-7cbb-4b10-beda-d97e9aef9147"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: new Guid("f9a92769-354f-4d23-85b2-16f6af0b84a1"));
        }
    }
}
