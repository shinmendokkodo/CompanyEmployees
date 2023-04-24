﻿using Entities.Models;
using Repository.Contracts;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Repository;

internal sealed class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
{
    public EmployeeRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public IEnumerable<Employee> GetEmployees(Guid companyId, bool trackChanges) => 
        FindByCondition(e => e.CompanyId.Equals(companyId), trackChanges)
        .OrderBy(e => e.Name)
        .ToList();

    public Employee GetEmployee(Guid companyId, Guid employeeId, bool trackChanges) => 
        FindByCondition(e => e.CompanyId.Equals(companyId) && e.Id.Equals(employeeId), trackChanges)
        .SingleOrDefault();

    public void CreateEmployeeForCompany(Guid companyId, Employee employee) 
    { 
        employee.CompanyId = companyId; 
        Create(employee); 
    }
}
