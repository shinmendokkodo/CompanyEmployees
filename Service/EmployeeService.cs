using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Repository.Contracts;
using Service.Contracts;
using Shared.DataTransferObjects;
using System.Collections.Generic;
using System;
using Entities.Models;
using System.Threading.Tasks;
using Shared.RequestFeatures;

namespace Service;

/// <summary>
/// The EmployeeService class provides implementation for the IEmployeeService interface.
/// </summary>
internal sealed class EmployeeService : BaseService, IEmployeeService
{
    /// <summary>
    /// Initializes a new instance of the <see cref="EmployeeService"/> class.
    /// </summary>
    /// <param name="repositoryManager">The repository manager.</param>
    /// <param name="loggerManager">The logger manager.</param>
    /// <param name="mapper">The AutoMapper instance used for mapping between data transfer objects and entity models.</param>
    public EmployeeService(IRepositoryManager repositoryManager, ILoggerManager loggerManager, IMapper mapper)
        : base(repositoryManager, loggerManager, mapper)
    {
    }

    /// <inheritdoc/>
    public async Task<(IEnumerable<EmployeeDto> employees, MetaData metaData)> GetEmployeesAsync(Guid companyId, EmployeeParameters employeeParameters, bool trackChanges)
    {
        if (!employeeParameters.ValidAgeRange)
        {
            throw new MaxAgeRangeBadRequestException();
        }
        var company = await GetCompanyAndCheckIfItExistsAsync(companyId, trackChanges);

        var employeesWithMetaData = await repositoryManager.EmployeeRepository.GetEmployeesAsync(company.Id, employeeParameters, trackChanges);

        var employeesDto = mapper.Map<IEnumerable<EmployeeDto>>(employeesWithMetaData);

        return (employees: employeesDto, metaData: employeesWithMetaData.MetaData);
    }

    /// <inheritdoc/>
    public async Task<EmployeeDto> GetEmployeeAsync(Guid companyId, Guid employeeId, bool trackChanges) 
    { 
        var company = await GetCompanyAndCheckIfItExistsAsync(companyId, trackChanges);

        var employeeDb = await GetEmployeeForCompanyAndCheckIfItExistsAsync(company.Id, employeeId, trackChanges);

        var employee = mapper.Map<EmployeeDto>(employeeDb);

        return employee;
    }

    /// <inheritdoc/>
    public async Task<EmployeeDto> CreateEmployeeForCompanyAsync(Guid companyId, EmployeeForCreationDto employeeForCreation, bool trackChanges) 
    { 
        var company = await GetCompanyAndCheckIfItExistsAsync(companyId, trackChanges);
        
        var employeeEntity = mapper.Map<Employee>(employeeForCreation); 
        
        repositoryManager.EmployeeRepository.CreateEmployeeForCompany(company.Id, employeeEntity); 
        
        await repositoryManager.SaveAsync(); 
        
        var employeeToReturn = mapper.Map<EmployeeDto>(employeeEntity); 
        
        return employeeToReturn; 
    }

    /// <inheritdoc/>
    public async Task DeleteEmployeeForCompanyAsync(Guid companyId, Guid employeeId, bool trackChanges)
    {
        var company = await GetCompanyAndCheckIfItExistsAsync(companyId, trackChanges);
        
        var employeeForCompany = await GetEmployeeForCompanyAndCheckIfItExistsAsync(company.Id, employeeId, trackChanges);
        
        repositoryManager.EmployeeRepository.DeleteEmployee(employeeForCompany);
        
        await repositoryManager.SaveAsync();
    }

    /// <inheritdoc/>
    public async Task UpdateEmployeeForCompanyAsync(Guid companyId, Guid employeeId, EmployeeForUpdateDto employeeForUpdate, bool compTrackChanges, bool empTrackChanges)
    {
        var company = await GetCompanyAndCheckIfItExistsAsync(companyId, compTrackChanges);

        var employeeEntity = await GetEmployeeForCompanyAndCheckIfItExistsAsync(company.Id, employeeId, empTrackChanges);
        
        mapper.Map(employeeForUpdate, employeeEntity);
        
        await repositoryManager.SaveAsync();
    }

    /// <inheritdoc/>
    public async Task<(EmployeeForUpdateDto employeeToPatch, Employee employeeEntity)> GetEmployeeForPatchAsync(Guid companyId, Guid employeeId, bool compTrackChanges, bool empTrackChanges)
    {
        var company = await GetCompanyAndCheckIfItExistsAsync(companyId, compTrackChanges);

        var employeeEntity = await GetEmployeeForCompanyAndCheckIfItExistsAsync(company.Id, employeeId, empTrackChanges);
        
        var employeeToPatch = mapper.Map<EmployeeForUpdateDto>(employeeEntity);
        
        return (employeeToPatch, employeeEntity);
    }

    /// <inheritdoc/>
    public async Task SaveChangesForPatchAsync(EmployeeForUpdateDto employeeToPatch, Employee employeeEntity)
    {
        mapper.Map(employeeToPatch, employeeEntity);
        
        await repositoryManager.SaveAsync();
    }

    /// <summary>
    /// Retrieves a Company by its ID and throws an exception if the company does not exist.
    /// </summary>
    /// <param name="companyId">The ID of the company to retrieve.</param>
    /// <param name="trackChanges">Whether to track changes in the retrieved entity.</param>
    /// <returns>A Company instance if it exists, otherwise an exception is thrown.</returns>
    private async Task<Company> GetCompanyAndCheckIfItExistsAsync(Guid companyId, bool trackChanges)
    {
        return await repositoryManager.CompanyRepository.GetCompanyAsync(companyId, trackChanges)
                    ?? throw new CompanyNotFoundException(companyId);
    }

    /// <summary>
    /// Retrieves an Employee by its ID and the associated company ID, and throws an exception if the employee does not exist.
    /// </summary>
    /// <param name="companyId">The ID of the associated company.</param>
    /// <param name="employeeId">The ID of the employee to retrieve.</param>
    /// <param name="trackChanges">Whether to track changes in the retrieved entity.</param>
    /// <returns>An Employee instance if it exists, otherwise an exception is thrown.</returns>
    private async Task<Employee> GetEmployeeForCompanyAndCheckIfItExistsAsync(Guid companyId, Guid employeeId, bool trackChanges) 
    { 
        return await repositoryManager.EmployeeRepository.GetEmployeeAsync(companyId, employeeId, trackChanges) ?? throw new EmployeeNotFoundException(employeeId); 
    }
}