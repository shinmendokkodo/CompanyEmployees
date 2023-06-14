using Entities.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;

namespace Repository.Configuration;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee> 
{
    public void Configure(EntityTypeBuilder<Employee> builder) 
    { 
        builder.HasData
        (
            new Employee 
            { 
                Id = new Guid("80abbca8-664d-4b20-b5de-024705497d4a"),
                Name = "Sam Raiden", 
                Age = 26, 
                Position = "Software developer", 
                CompanyId = 
                new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870") 
            }, 
            new Employee 
            { 
                Id = new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"), 
                Name = "Jana McLeaf", 
                Age = 30, 
                Position = "Software developer", 
                CompanyId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870") 
            }, 
            new Employee { 
                Id = new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"), 
                Name = "Kane Miller", 
                Age = 35, 
                Position = "Administrator", 
                CompanyId = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3") 
            },
            new Employee
            {
                Id = new Guid("aee7b7f5-345c-4a46-8aec-0c6c9a6f9b1b"),
                Name = "Adam Scott",
                Age = 32,
                Position = "Software Developer",
                CompanyId = new Guid("f91d276d-2488-4e68-bf2f-85996f029daf")
            },
            new Employee
            {
                Id = new Guid("a5a65b91-b3e6-4f78-a40c-6b72a5a1f827"),
                Name = "Emily Parker",
                Age = 29,
                Position = "UI/UX Designer",
                CompanyId = new Guid("7e9f0f5c-58ef-4a77-913f-3e408054e1bb")
            },
            new Employee
            {
                Id = new Guid("3c4cd4f9-913f-41e1-a9dd-5c8f8b2b6c2a"),
                Name = "Oliver Brown",
                Age = 35,
                Position = "System Analyst",
                CompanyId = new Guid("eb23df43-47b3-4675-9b84-2788574e2e95")
            },
            new Employee
            {
                Id = new Guid("cb4b5c89-35f1-4bb6-b810-66a6f2c6b2db"),
                Name = "Sophia Davis",
                Age = 27,
                Position = "Data Analyst",
                CompanyId = new Guid("f91d276d-2488-4e68-bf2f-85996f029daf")
            },
            new Employee
            {
                Id = new Guid("f0e2058c-8745-4a3a-9fdc-058a4f55a802"),
                Name = "Liam Smith",
                Age = 33,
                Position = "IT Support Specialist",
                CompanyId = new Guid("7e9f0f5c-58ef-4a77-913f-3e408054e1bb")
            },
            new Employee
            {
                Id = new Guid("5a98cd2d-bb8d-4021-8b21-d45551d3c288"),
                Name = "Jake Mitchell",
                Age = 32,
                Position = "Web Developer",
                CompanyId = new Guid("d69a6a59-a7e8-4c8f-b802-95d2b4b58ac7")
            },
            new Employee
            {
                Id = new Guid("fbdf89c3-66af-455b-9b26-3b1c8b2a3f9d"),
                Name = "Jessica Walters",
                Age = 29,
                Position = "System Analyst",
                CompanyId = new Guid("7304a687-8970-4a37-b3e7-0bf74a5b6456")
            },
            new Employee
            {
                Id = new Guid("3edc9737-b355-4a6a-9ecf-c8eac566c1b8"),
                Name = "Lucas Alves",
                Age = 35,
                Position = "Data Scientist",
                CompanyId = new Guid("f9a92769-354f-4d23-85b2-16f6af0b84a1")
            },
            new Employee
            {
                Id = new Guid("e2dcedf3-51b8-4a7b-853b-9d2954e2ef32"),
                Name = "Olivia Baker",
                Age = 27,
                Position = "Software Engineer",
                CompanyId = new Guid("e1bce704-7cbb-4b10-beda-d97e9aef9147")
            },
            new Employee
            {
                Id = new Guid("891bb83c-b2f6-4c88-830a-1b7681f50fe0"),
                Name = "Haruto Yamada",
                Age = 33,
                Position = "IT Support Specialist",
                CompanyId = new Guid("ba56711f-692a-4ed6-9451-b3f229f9f468")
            },
            new Employee
            {
                Id = new Guid("b3fa5067-e7c5-4618-9f34-3a8a6e8827ed"),
                Name = "Liam Johnson",
                Age = 32,
                Position = "Web Developer",
                CompanyId = new Guid("ba56711f-692a-4ed6-9451-b3f229f9f468")
            },
            new Employee
            {
                Id = new Guid("64a183c9-93d7-4372-bef8-a2f40f7e520d"),
                Name = "Noah Williams",
                Age = 29,
                Position = "System Analyst",
                CompanyId = new Guid("e1bce704-7cbb-4b10-beda-d97e9aef9147")
            },
            new Employee
            {
                Id = new Guid("fb133c53-33a6-4f94-9623-4896fd4527cf"),
                Name = "Oliver Brown",
                Age = 35,
                Position = "Data Scientist",
                CompanyId = new Guid("f9a92769-354f-4d23-85b2-16f6af0b84a1")
            },
            new Employee
            {
                Id = new Guid("5b34df28-fdc8-4a2b-a9a6-1f8b06248831"),
                Name = "Elijah Davis",
                Age = 27,
                Position = "Software Engineer",
                CompanyId = new Guid("7304a687-8970-4a37-b3e7-0bf74a5b6456")
            },
            new Employee
            {
                Id = new Guid("6e6d4c1f-b025-47c2-9e73-e84e5c42bc21"),
                Name = "James Wilson",
                Age = 33,
                Position = "IT Support Specialist",
                CompanyId = new Guid("d69a6a59-a7e8-4c8f-b802-95d2b4b58ac7")
            },
            new Employee
            {
                Id = new Guid("42d5b53a-9dba-46ef-8127-72c5ec75cb4a"),
                Name = "William Thomas",
                Age = 34,
                Position = "Software Developer",
                CompanyId = new Guid("ba56711f-692a-4ed6-9451-b3f229f9f468")
            },
            new Employee
            {
                Id = new Guid("f8c9f6fa-61ba-45f6-9107-0a3d688ba2d9"),
                Name = "Benjamin Martinez",
                Age = 28,
                Position = "Network Administrator",
                CompanyId = new Guid("e1bce704-7cbb-4b10-beda-d97e9aef9147")
            },
            new Employee
            {
                Id = new Guid("23b5e303-96d6-4ba2-8d52-2e2a8c30ab67"),
                Name = "Lucas Garcia",
                Age = 36,
                Position = "Data Analyst",
                CompanyId = new Guid("f9a92769-354f-4d23-85b2-16f6af0b84a1")
            },
            new Employee
            {
                Id = new Guid("7dc92c9f-6ad1-4117-9677-27a45f1a9a35"),
                Name = "Henry Rodriguez",
                Age = 30,
                Position = "Systems Engineer",
                CompanyId = new Guid("7304a687-8970-4a37-b3e7-0bf74a5b6456")
            },
            new Employee
            {
                Id = new Guid("9db9db79-3434-4db6-925d-bb3ed6e6b213"),
                Name = "Alexander Martinez",
                Age = 32,
                Position = "IT Coordinator",
                CompanyId = new Guid("d69a6a59-a7e8-4c8f-b802-95d2b4b58ac7")
            },
            new Employee
            {
                Id = new Guid("0d3a45e6-876b-4ca3-92eb-4167eb7ef621"),
                Name = "Evelyn Clarke",
                Age = 34,
                Position = "Backend Developer",
                CompanyId = new Guid("d69a6a59-a7e8-4c8f-b802-95d2b4b58ac7")
            },
            new Employee
            {
                Id = new Guid("e8a79a80-23cd-42d1-88b2-c8e68e484a43"),
                Name = "Charlie White",
                Age = 28,
                Position = "DevOps Engineer",
                CompanyId = new Guid("7304a687-8970-4a37-b3e7-0bf74a5b6456")
            },
            new Employee
            {
                Id = new Guid("abf0ed9e-c23a-4a8e-97ea-d1486d837972"),
                Name = "Freddie Harris",
                Age = 36,
                Position = "Product Manager",
                CompanyId = new Guid("e1bce704-7cbb-4b10-beda-d97e9aef9147")
            },
            new Employee
            {
                Id = new Guid("265f40c3-0cb7-4a3d-9169-32b110dbb557"),
                Name = "George Lewis",
                Age = 30,
                Position = "Data Engineer",
                CompanyId = new Guid("f9a92769-354f-4d23-85b2-16f6af0b84a1")
            },
            new Employee
            {
                Id = new Guid("9d7e8df3-55d9-4596-987c-6a3d0469aae3"),
                Name = "Isla Walker",
                Age = 32,
                Position = "UI/UX Designer",
                CompanyId = new Guid("ba56711f-692a-4ed6-9451-b3f229f9f468")
            },
            new Employee
            {
                Id = new Guid("3785fa0b-8106-4c53-9053-ef9b2a3a9308"),
                Name = "Leo Hall",
                Age = 27,
                Position = "Web Designer",
                CompanyId = new Guid("d69a6a59-a7e8-4c8f-b802-95d2b4b58ac7")
            },
            new Employee
            {
                Id = new Guid("b3d702fc-a551-40b2-b333-7ae0979c8b5e"),
                Name = "Jacob Turner",
                Age = 37,
                Position = "Frontend Developer",
                CompanyId = new Guid("7304a687-8970-4a37-b3e7-0bf74a5b6456")
            },
            new Employee
            {
                Id = new Guid("f5eaeb2f-b2f2-4fdb-9358-a6e582f27f2c"),
                Name = "Mason Phillips",
                Age = 26,
                Position = "Quality Assurance",
                CompanyId = new Guid("e1bce704-7cbb-4b10-beda-d97e9aef9147")
            },
            new Employee
            {
                Id = new Guid("d859f253-8eb0-43be-9480-911210b6ca00"),
                Name = "Harrison Campbell",
                Age = 34,
                Position = "System Administrator",
                CompanyId = new Guid("f9a92769-354f-4d23-85b2-16f6af0b84a1")
            },
            new Employee
            {
                Id = new Guid("1e7f9e6c-3fab-4d37-8b48-6922a60e799a"),
                Name = "Jessica Scott",
                Age = 29,
                Position = "Cloud Architect",
                CompanyId = new Guid("ba56711f-692a-4ed6-9451-b3f229f9f468")
            },
            new Employee
            {
                Id = new Guid("cd145578-9e91-4d08-9a00-4b3cbe9c5c47"),
                Name = "Matilda Young",
                Age = 28,
                Position = "Scrum Master",
                CompanyId = new Guid("d69a6a59-a7e8-4c8f-b802-95d2b4b58ac7")
            },
            new Employee
            {
                Id = new Guid("bb8a2f24-8b36-44b7-bca4-c593aadd5f9e"),
                Name = "Oscar King",
                Age = 37,
                Position = "Database Administrator",
                CompanyId = new Guid("7304a687-8970-4a37-b3e7-0bf74a5b6456")
            },
            new Employee
            {
                Id = new Guid("8233b39a-2c0b-4cf2-8bca-48f3728eb6a3"),
                Name = "Sophia Wright",
                Age = 26,
                Position = "Network Engineer",
                CompanyId = new Guid("e1bce704-7cbb-4b10-beda-d97e9aef9147")
            },
            new Employee
            {
                Id = new Guid("756b50c1-853f-4c07-b495-304f7164118a"),
                Name = "Theo Taylor",
                Age = 35,
                Position = "Data Scientist",
                CompanyId = new Guid("f9a92769-354f-4d23-85b2-16f6af0b84a1")
            },
            new Employee
            {
                Id = new Guid("234fd123-89a2-4a47-a4c9-5b7e4f7e59e6"),
                Name = "Zachary Martin",
                Age = 32,
                Position = "IT Manager",
                CompanyId = new Guid("ba56711f-692a-4ed6-9451-b3f229f9f468")
            },
            new Employee
            {
                Id = new Guid("abd7b2f7-8cb8-40c3-a6d6-ae6196cde283"),
                Name = "Owen Baker",
                Age = 31,
                Position = "Backend Developer",
                CompanyId = new Guid("d69a6a59-a7e8-4c8f-b802-95d2b4b58ac7")
            },
            new Employee
            {
                Id = new Guid("9f47d9c4-70eb-4662-a3cd-ec5fa1c602a7"),
                Name = "Emily Clarke",
                Age = 27,
                Position = "Project Manager",
                CompanyId = new Guid("7304a687-8970-4a37-b3e7-0bf74a5b6456")
            },
            new Employee
            {
                Id = new Guid("5b5ffbef-e367-4294-b847-3e3b7a8e84e8"),
                Name = "Ian Freeman",
                Age = 35,
                Position = "Data Analyst",
                CompanyId = new Guid("7304a687-8970-4a37-b3e7-0bf74a5b6456")
            },
            new Employee
            {
                Id = new Guid("12fa66df-1dd2-4112-93cd-c31014a0b777"),
                Name = "Amelia Davis",
                Age = 28,
                Position = "Software Developer",
                CompanyId = new Guid("ba56711f-692a-4ed6-9451-b3f229f9f468")
            },
            new Employee
            {
                Id = new Guid("93547f13-d909-4ca9-9696-22dcbc9b0ee9"),
                Name = "Noah Patterson",
                Age = 31,
                Position = "IT Consultant",
                CompanyId = new Guid("e1bce704-7cbb-4b10-beda-d97e9aef9147")
            },
            new Employee
            {
                Id = new Guid("87cb4988-a5d2-4b36-b5d3-71184f6e3f75"),
                Name = "Liam Johnson",
                Age = 26,
                Position = "Network Administrator",
                CompanyId = new Guid("d69a6a59-a7e8-4c8f-b802-95d2b4b58ac7")
            },
            new Employee
            {
                Id = new Guid("0baee42d-cb8f-4d67-8a82-c91335d479b8"),
                Name = "Oliver Smith",
                Age = 30,
                Position = "Web Developer",
                CompanyId = new Guid("d69a6a59-a7e8-4c8f-b802-95d2b4b58ac7")
            },
            new Employee
            {
                Id = new Guid("ad24c897-1cde-4b0b-828d-b15c4a07a24d"),
                Name = "George Johnson",
                Age = 28,
                Position = "Data Analyst",
                CompanyId = new Guid("d69a6a59-a7e8-4c8f-b802-95d2b4b58ac7")
            },
            new Employee
            {
                Id = new Guid("20b3f781-88e0-42c5-b678-e8b3a625f22d"),
                Name = "Harry Williams",
                Age = 26,
                Position = "Software Engineer",
                CompanyId = new Guid("ba56711f-692a-4ed6-9451-b3f229f9f468")
            },
            new Employee
            {
                Id = new Guid("c72e7e23-2761-42cf-8962-896ada4425c1"),
                Name = "Jack Jones",
                Age = 32,
                Position = "Systems Administrator",
                CompanyId = new Guid("ba56711f-692a-4ed6-9451-b3f229f9f468")
            },
            new Employee
            {
                Id = new Guid("ce14b1d1-8133-4279-a407-6bda3a3a8b92"),
                Name = "Charlie Brown",
                Age = 25,
                Position = "Database Administrator",
                CompanyId = new Guid("f9a92769-354f-4d23-85b2-16f6af0b84a1")
            },
            new Employee
            {
                Id = new Guid("e09b94d2-d5dd-4f80-90d7-35353c49a07f"),
                Name = "Thomas Davies",
                Age = 34,
                Position = "QA Engineer",
                CompanyId = new Guid("f9a92769-354f-4d23-85b2-16f6af0b84a1")
            },
            new Employee
            {
                Id = new Guid("66f9f41a-0d7f-4df3-9b9a-c7533b57c742"),
                Name = "Ethan Evans",
                Age = 33,
                Position = "Network Engineer",
                CompanyId = new Guid("7304a687-8970-4a37-b3e7-0bf74a5b6456")
            },
            new Employee
            {
                Id = new Guid("8bc3a24d-7337-4c55-b8c9-c9b96b9c8a8e"),
                Name = "James Wilson",
                Age = 28,
                Position = "Data Scientist",
                CompanyId = new Guid("7304a687-8970-4a37-b3e7-0bf74a5b6456")
            },
            new Employee
            {
                Id = new Guid("c951255a-0e8c-4f6a-9836-8dd3a8d0c3d7"),
                Name = "William Taylor",
                Age = 31,
                Position = "Software Tester",
                CompanyId = new Guid("d69a6a59-a7e8-4c8f-b802-95d2b4b58ac7")
            },
            new Employee
            {
                Id = new Guid("0d6a92bf-8c8c-4a6e-8b56-86e8742d2479"),
                Name = "Jacob Thomas",
                Age = 29,
                Position = "IT Support Specialist",
                CompanyId = new Guid("d69a6a59-a7e8-4c8f-b802-95d2b4b58ac7")
            },
            new Employee
            {
                Id = new Guid("10d5c76c-4754-41f6-9220-9326a4e1a583"),
                Name = "Andrea Bocelli",
                Age = 41,
                Position = "UI/UX Designer",
                CompanyId = new Guid("f9a92769-354f-4d23-85b2-16f6af0b84a1")
            },
            new Employee
            {
                Id = new Guid("8a34cfdd-8c59-4303-9a81-4fdbe7ecb26b"),
                Name = "Ella Fitzgerald",
                Age = 29,
                Position = "Frontend Developer",
                CompanyId = new Guid("e1bce704-7cbb-4b10-beda-d97e9aef9147")
            },
            new Employee
            {
                Id = new Guid("56fa03f4-49fb-44ba-b045-9bc13c8c5821"),
                Name = "Charlie Parker",
                Age = 33,
                Position = "Backend Developer",
                CompanyId = new Guid("d69a6a59-a7e8-4c8f-b802-95d2b4b58ac7")
            },
            new Employee
            {
                Id = new Guid("bc8903a5-cb9e-4b28-a5aa-3c7598289f66"),
                Name = "Dizzy Gillespie",
                Age = 36,
                Position = "Project Manager",
                CompanyId = new Guid("ba56711f-692a-4ed6-9451-b3f229f9f468")
            },
            new Employee
            {
                Id = new Guid("85daff91-dffa-47f1-922d-b8c994733fb3"),
                Name = "Sarah Vaughan",
                Age = 27,
                Position = "QA Engineer",
                CompanyId = new Guid("f9a92769-354f-4d23-85b2-16f6af0b84a1")
            },
            new Employee
            {
                Id = new Guid("061e682f-5987-41a1-97c5-0a8b6f83e673"),
                Name = "Frank Sinatra",
                Age = 30,
                Position = "IT Consultant",
                CompanyId = new Guid("e1bce704-7cbb-4b10-beda-d97e9aef9147")
            }
        ); 
    } 
}
