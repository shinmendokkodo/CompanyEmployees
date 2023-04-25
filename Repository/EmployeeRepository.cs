using Entities.Models;
using Repository.Contracts;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shared.RequestFeatures;
using Repository.Extensions;

namespace Repository;

internal sealed class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
{
    public EmployeeRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public async Task<PagedList<Employee>> GetEmployeesAsync(Guid companyId, EmployeeParameters employeeParameters, bool trackChanges)
    {
        List<Employee> employees = await FindByCondition(e => e.CompanyId.Equals(companyId), trackChanges)
            .Filter(employeeParameters.MinAge, employeeParameters.MaxAge)
            .Search(employeeParameters.SearchTerm)
            .Sort(employeeParameters.OrderBy)
            .Paginate(employeeParameters.PageNumber, employeeParameters.PageSize)
            .ToListAsync();

        int count = await FindByCondition(e => e.CompanyId.Equals(companyId), trackChanges).CountAsync();

        return new PagedList<Employee>(employees, count, employeeParameters.PageNumber, employeeParameters.PageSize);
    }

    public async Task<Employee> GetEmployeeAsync(Guid companyId, Guid employeeId, bool trackChanges) => 
        await FindByCondition(e => e.CompanyId.Equals(companyId) && e.Id.Equals(employeeId), trackChanges)
        .SingleOrDefaultAsync();

    public void CreateEmployeeForCompany(Guid companyId, Employee employee) 
    { 
        employee.CompanyId = companyId; 
        Create(employee); 
    }

    public void DeleteEmployee(Employee employee) => Delete(employee);
}
