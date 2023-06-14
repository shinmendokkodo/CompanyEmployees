using Entities.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;

namespace Repository.Configuration;

public class CompanyConfiguration : IEntityTypeConfiguration<Company> 
{ 
    public void Configure(EntityTypeBuilder<Company> builder) 
    { 
        builder.HasData
        (
            new Company 
            { 
                Id = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), 
                Name = "IT Solutions Ltd", 
                Address = "583 Wall Dr. Gwynn Oak, MD 21207", 
                Country = "USA" 
            }, 
            new Company 
            { 
                Id = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
                Name = "Admin Solutions Ltd", 
                Address = "312 Forest Avenue, BF 923", 
                Country = "USA" 
            },
            new Company
            {
                Id = new Guid("f91d276d-2488-4e68-bf2f-85996f029daf"),
                Name = "Vector Digital Corp",
                Address = "987 Maple Drive, Los Angeles, CA 90210",
                Country = "USA"
            },
            new Company
            {
                Id = new Guid("7e9f0f5c-58ef-4a77-913f-3e408054e1bb"),
                Name = "Oceanic Software Ltd",
                Address = "45 Ocean Street, Sydney, NSW 2000",
                Country = "Australia"
            },
            new Company
            {
                Id = new Guid("eb23df43-47b3-4675-9b84-2788574e2e95"),
                Name = "CloudNet Technologies",
                Address = "Suite 1, 1 Baker Street, London, W1U 6WG",
                Country = "UK"
            },
            new Company
            {
                Id = new Guid("d69a6a59-a7e8-4c8f-b802-95d2b4b58ac7"),
                Name = "Polaris Software",
                Address = "6782 Pine St. Toronto, ON M4B 1V6",
                Country = "Canada"
            },
            new Company
            {
                Id = new Guid("7304a687-8970-4a37-b3e7-0bf74a5b6456"),
                Name = "Stratosphere Technologies",
                Address = "742 Evergreen Terrace, Springfield, IL 62701",
                Country = "USA"
            },
            new Company
            {
                Id = new Guid("f9a92769-354f-4d23-85b2-16f6af0b84a1"),
                Name = "Nimbus Innovations",
                Address = "Rua da Consolação, 2222, São Paulo - SP, 01302-000",
                Country = "Brazil"
            },
            new Company
            {
                Id = new Guid("e1bce704-7cbb-4b10-beda-d97e9aef9147"),
                Name = "Equinox Digital",
                Address = "210 Great Portland Street, London, W1W 5AF",
                Country = "UK"
            },
            new Company
            {
                Id = new Guid("ba56711f-692a-4ed6-9451-b3f229f9f468"),
                Name = "Helix AI",
                Address = "2-11-3 Meguro, Meguro-ku, Tokyo 153-0063",
                Country = "Japan"
            }
        ); 
    } 
}
