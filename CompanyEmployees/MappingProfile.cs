using AutoMapper;
using Entities.Models;
using Shared.DataTransferObjects;

namespace CompanyEmployees;

/// <summary>
/// The MappingProfile class extends the AutoMapper Profile class and defines the mapping configurations for various entities and DTOs.
/// </summary>
public class MappingProfile : Profile
{
    /// <summary>
    /// Initializes a new instance of the MappingProfile class and sets up the mapping configurations.
    /// </summary>
    public MappingProfile()
    {
        // Map Company to CompanyDto, and create FullAddress from Address and Country properties.
        CreateMap<Company, CompanyDto>()
            .ForMember(c => c.FullAddress,
                opt => opt.MapFrom(x => string.Join(' ', x.Address, x.Country)));

        // Map Employee to EmployeeDto.
        CreateMap<Employee, EmployeeDto>();

        // Map CompanyForCreationDto to Company.
        CreateMap<CompanyForCreationDto, Company>();

        // Map EmployeeForCreationDto to Employee.
        CreateMap<EmployeeForCreationDto, Employee>();

        // Map EmployeeForUpdateDto to Employee and reverse the mapping.
        CreateMap<EmployeeForUpdateDto, Employee>().ReverseMap();

        // Map CompanyForUpdateDto to Company.
        CreateMap<CompanyForUpdateDto, Company>();
    }
}
