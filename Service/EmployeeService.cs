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

namespace Service;

internal sealed class EmployeeService : IEmployeeService
{
    private readonly IRepositoryManager repositoryManager;
    private readonly ILoggerManager loggerManager;
    private readonly IMapper mapper;

    public EmployeeService(IRepositoryManager repositoryManager, ILoggerManager loggerManager, IMapper mapper)
    {
        this.repositoryManager = repositoryManager;
        this.loggerManager = loggerManager;
        this.mapper = mapper;
    }

    public async Task<IEnumerable<EmployeeDto>> GetEmployeesAsync(Guid companyId, bool trackChanges)
    {
        var company = await repositoryManager.CompanyRepository.GetCompanyAsync(companyId, trackChanges) ?? throw new CompanyNotFoundException(companyId);
        var employeesFromDb = await repositoryManager.EmployeeRepository.GetEmployeesAsync(company.Id, trackChanges); 
        var employeesDto = mapper.Map<IEnumerable<EmployeeDto>>(employeesFromDb); 
        return employeesDto;
    }

    public async Task<EmployeeDto> GetEmployeeAsync(Guid companyId, Guid employeeId, bool trackChanges) 
    { 
        var company = await repositoryManager.CompanyRepository.GetCompanyAsync(companyId, trackChanges) ?? throw new CompanyNotFoundException(companyId);
        var employeeDb = await repositoryManager.EmployeeRepository.GetEmployeeAsync(company.Id, employeeId, trackChanges) ?? throw new EmployeeNotFoundException(employeeId);
        var employee = mapper.Map<EmployeeDto>(employeeDb); 
        return employee; 
    }

    public async Task<EmployeeDto> CreateEmployeeForCompanyAsync(Guid companyId, EmployeeForCreationDto employeeForCreation, bool trackChanges) 
    { 
        var company = await repositoryManager.CompanyRepository.GetCompanyAsync(companyId, trackChanges) ?? throw new CompanyNotFoundException(companyId);
        var employeeEntity = mapper.Map<Employee>(employeeForCreation); 
        repositoryManager.EmployeeRepository.CreateEmployeeForCompany(company.Id, employeeEntity); 
        await repositoryManager.SaveAsync(); 
        var employeeToReturn = mapper.Map<EmployeeDto>(employeeEntity); 
        return employeeToReturn; 
    }

    public async Task DeleteEmployeeForCompanyAsync(Guid companyId, Guid employeeId, bool trackChanges)
    {
        var company = await repositoryManager.CompanyRepository.GetCompanyAsync(companyId, trackChanges) ?? throw new CompanyNotFoundException(companyId);
        var employeeForCompany = await repositoryManager.EmployeeRepository.GetEmployeeAsync(company.Id, employeeId, trackChanges) ?? throw new EmployeeNotFoundException(employeeId);
        repositoryManager.EmployeeRepository.DeleteEmployee(employeeForCompany);
        await repositoryManager.SaveAsync();
    }

    public async Task UpdateEmployeeForCompanyAsync(Guid companyId, Guid employeeId, EmployeeForUpdateDto employeeForUpdate, bool compTrackChanges, bool empTrackChanges)
    {
        var company = await repositoryManager.CompanyRepository.GetCompanyAsync(companyId, compTrackChanges) ?? throw new CompanyNotFoundException(companyId);
        var employeeEntity = await repositoryManager.EmployeeRepository.GetEmployeeAsync(company.Id, employeeId, empTrackChanges) ?? throw new EmployeeNotFoundException(employeeId);
        mapper.Map(employeeForUpdate, employeeEntity);
        await repositoryManager.SaveAsync();
    }

    public async Task<(EmployeeForUpdateDto employeeToPatch, Employee employeeEntity)> GetEmployeeForPatchAsync(Guid companyId, Guid employeeId, bool compTrackChanges, bool empTrackChanges)
    {
        var company = await repositoryManager.CompanyRepository.GetCompanyAsync(companyId, compTrackChanges) ?? throw new CompanyNotFoundException(companyId);
        var employeeEntity = await repositoryManager.EmployeeRepository.GetEmployeeAsync(company.Id, employeeId, empTrackChanges) ?? throw new EmployeeNotFoundException(companyId);
        var employeeToPatch = mapper.Map<EmployeeForUpdateDto>(employeeEntity);
        return (employeeToPatch, employeeEntity);
    }
    public async Task SaveChangesForPatchAsync(EmployeeForUpdateDto employeeToPatch, Employee employeeEntity)
    {
        mapper.Map(employeeToPatch, employeeEntity);
        await repositoryManager.SaveAsync();
    }
}