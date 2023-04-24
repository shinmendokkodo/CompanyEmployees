using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Repository.Contracts;
using Service.Contracts;
using Shared.DataTransferObjects;
using System.Collections.Generic;
using System;

namespace Service;

internal sealed class EmployeeService : IEmployeeService
{
    private readonly IRepositoryManager repository;
    private readonly ILoggerManager logger;
    private readonly IMapper mapper;

    public EmployeeService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
    {
        this.repository = repository;
        this.logger = logger;
        this.mapper = mapper;
    }

    public IEnumerable<EmployeeDto> GetEmployees(Guid companyId, bool trackChanges)
    {
        var company = repository.Company.GetCompany(companyId, trackChanges) ?? throw new CompanyNotFoundException(companyId);
        var employeesFromDb = repository.Employee.GetEmployees(company.Id, trackChanges); 
        var employeesDto = mapper.Map<IEnumerable<EmployeeDto>>(employeesFromDb); 
        return employeesDto;
    }

    public EmployeeDto GetEmployee(Guid companyId, Guid employeeId, bool trackChanges) 
    { 
        var company = repository.Company.GetCompany(companyId, trackChanges) ?? throw new CompanyNotFoundException(companyId);
        var employeeDb = repository.Employee.GetEmployee(company.Id, employeeId, trackChanges) ?? throw new EmployeeNotFoundException(employeeId);
        var employee = mapper.Map<EmployeeDto>(employeeDb); 
        return employee; 
    }
}