using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Repository.Contracts;
using Service.Contracts;
using Shared.DataTransferObjects;
using System.Collections.Generic;
using System;
using Entities.Models;

namespace Service;

internal sealed class EmployeeService : IEmployeeService
{
    private readonly IRepositoryManager repositoryManager;
    private readonly ILoggerManager loggerManager;
    private readonly IMapper mapper;

    public EmployeeService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
    {
        this.repositoryManager = repository;
        this.loggerManager = logger;
        this.mapper = mapper;
    }

    public IEnumerable<EmployeeDto> GetEmployees(Guid companyId, bool trackChanges)
    {
        var company = repositoryManager.CompanyRepository.GetCompany(companyId, trackChanges) ?? throw new CompanyNotFoundException(companyId);
        var employeesFromDb = repositoryManager.EmployeeRepository.GetEmployees(company.Id, trackChanges); 
        var employeesDto = mapper.Map<IEnumerable<EmployeeDto>>(employeesFromDb); 
        return employeesDto;
    }

    public EmployeeDto GetEmployee(Guid companyId, Guid employeeId, bool trackChanges) 
    { 
        var company = repositoryManager.CompanyRepository.GetCompany(companyId, trackChanges) ?? throw new CompanyNotFoundException(companyId);
        var employeeDb = repositoryManager.EmployeeRepository.GetEmployee(company.Id, employeeId, trackChanges) ?? throw new EmployeeNotFoundException(employeeId);
        var employee = mapper.Map<EmployeeDto>(employeeDb); 
        return employee; 
    }

    public EmployeeDto CreateEmployeeForCompany(Guid companyId, EmployeeForCreationDto employeeForCreation, bool trackChanges) 
    { 
        var company = repositoryManager.CompanyRepository.GetCompany(companyId, trackChanges) ?? throw new CompanyNotFoundException(companyId);
        var employeeEntity = mapper.Map<Employee>(employeeForCreation); 
        repositoryManager.EmployeeRepository.CreateEmployeeForCompany(company.Id, employeeEntity); 
        repositoryManager.Save(); 
        var employeeToReturn = mapper.Map<EmployeeDto>(employeeEntity); 
        return employeeToReturn; 
    }

    public void DeleteEmployeeForCompany(Guid companyId, Guid employeeId, bool trackChanges)
    {
        var company = repositoryManager.CompanyRepository.GetCompany(companyId, trackChanges) ?? throw new CompanyNotFoundException(companyId);
        var employeeForCompany = repositoryManager.EmployeeRepository.GetEmployee(company.Id, employeeId, trackChanges) ?? throw new EmployeeNotFoundException(employeeId);
        repositoryManager.EmployeeRepository.DeleteEmployee(employeeForCompany);
        repositoryManager.Save();
    }

    public void UpdateEmployeeForCompany(Guid companyId, Guid employeeId, EmployeeForUpdateDto employeeForUpdate, bool compTrackChanges, bool empTrackChanges)
    {
        var company = repositoryManager.CompanyRepository.GetCompany(companyId, compTrackChanges) ?? throw new CompanyNotFoundException(companyId);
        var employeeEntity = repositoryManager.EmployeeRepository.GetEmployee(company.Id, employeeId, empTrackChanges) ?? throw new EmployeeNotFoundException(employeeId);
        mapper.Map(employeeForUpdate, employeeEntity);
        repositoryManager.Save();
    }

    public (EmployeeForUpdateDto employeeToPatch, Employee employeeEntity) GetEmployeeForPatch(Guid companyId, Guid employeeId, bool compTrackChanges, bool empTrackChanges)
    {
        var company = repositoryManager.CompanyRepository.GetCompany(companyId, compTrackChanges) ?? throw new CompanyNotFoundException(companyId);
        var employeeEntity = repositoryManager.EmployeeRepository.GetEmployee(company.Id, employeeId, empTrackChanges) ?? throw new EmployeeNotFoundException(companyId);
        var employeeToPatch = mapper.Map<EmployeeForUpdateDto>(employeeEntity);
        return (employeeToPatch, employeeEntity);
    }
    public void SaveChangesForPatch(EmployeeForUpdateDto employeeToPatch, Employee employeeEntity)
    {
        mapper.Map(employeeToPatch, employeeEntity);
        repositoryManager.Save();
    }
}