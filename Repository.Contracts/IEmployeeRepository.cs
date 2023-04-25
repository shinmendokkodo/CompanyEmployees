using Entities.Models;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using Shared.RequestFeatures;

namespace Repository.Contracts;

/// <summary>
/// The IEmployeeRepository interface defines the contract for a repository that provides access to Employee entities.
/// </summary>
public interface IEmployeeRepository
{
    /// <summary>
    /// Asynchronously retrieves a collection of Employee entities for the specified company.
    /// </summary>
    /// <param name="companyId">The ID of the company to retrieve employees for.</param>
    /// <param name="trackChanges">A boolean indicating whether or not to track changes to the entities.</param>
    /// <returns>An asynchronous operation that returns a collection of Employee entities.</returns>
    Task<PagedList<Employee>> GetEmployeesAsync(Guid companyId, EmployeeParameters employeeParameters, bool trackChanges);

    /// <summary>
    /// Asynchronously retrieves a single Employee entity with the specified ID for the specified company.
    /// </summary>
    /// <param name="companyId">The ID of the company that the employee belongs to.</param>
    /// <param name="employeeId">The ID of the employee to retrieve.</param>
    /// <param name="trackChanges">A boolean indicating whether or not to track changes to the entity.</param>
    /// <returns>An asynchronous operation that returns a single Employee entity.</returns>
    Task<Employee> GetEmployeeAsync(Guid companyId, Guid employeeId, bool trackChanges);

    /// <summary>
    /// Adds a new Employee entity to the repository for the specified company.
    /// </summary>
    /// <param name="companyId">The ID of the company to create the employee for.</param>
    /// <param name="employee">The Employee entity to add to the repository.</param>
    void CreateEmployeeForCompany(Guid companyId, Employee employee);

    /// <summary>
    /// Deletes the specified Employee entity from the repository.
    /// </summary>
    /// <param name="employee">The Employee entity to delete.</param>
    void DeleteEmployee(Employee employee);
}
