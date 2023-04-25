using Entities.Models;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;

namespace Service.Contracts;

/// <summary>
/// The IEmployeeService interface defines the contract for a service that handles operations on Employee entities.
/// </summary>
public interface IEmployeeService 
{
    /// <summary>
    /// Retrieves  a collection of EmployeeDto objects representing all employees for the specified company.
    /// </summary>
    /// <param name="companyId">The ID of the company to retrieve employees for.</param>
    /// <param name="trackChanges">A boolean indicating whether or not to track changes to the entities.</param>
    /// <returns>A collection of EmployeeDto objects.</returns>
    Task<(IEnumerable<EmployeeDto> employees, MetaData metaData)> GetEmployeesAsync(Guid companyId, EmployeeParameters employeeParameters, bool trackChanges);

    /// <summary>
    /// Retrieves a single EmployeeDto object representing the employee with the specified ID for the specified company.
    /// </summary>
    /// <param name="companyId">The ID of the company that the employee belongs to.</param>
    /// <param name="employeeId">The ID of the employee to retrieve.</param>
    /// <param name="trackChanges">A boolean indicating whether or not to track changes to the entity.</param>
    /// <returns>A single EmployeeDto object.</returns>
    Task<EmployeeDto> GetEmployeeAsync(Guid companyId, Guid employeeId, bool trackChanges);

    /// <summary>
    /// Creates a new Employee entity for the specified company using the specified EmployeeForCreationDto object.
    /// </summary>
    /// <param name="companyId">The ID of the company to create the employee for.</param>
    /// <param name="employeeForCreation">The EmployeeForCreationDto object that specifies the data for the new entity.</param>
    /// <param name="trackChanges">A boolean indicating whether or not to track changes to the entities.</param>
    /// <returns>An EmployeeDto object representing the newly created entity.</returns>
    Task<EmployeeDto> CreateEmployeeForCompanyAsync(Guid companyId, EmployeeForCreationDto employeeForCreation, bool trackChanges);

    /// <summary>
    /// Deletes the Employee entity with the specified ID for the specified company.
    /// </summary>
    /// <param name="companyId">The ID of the company that the employee belongs to.</param>
    /// <param name="employeeId">The ID of the employee to delete.</param>
    /// <param name="trackChanges">A boolean indicating whether or not to track changes to the entities.</param>
    Task DeleteEmployeeForCompanyAsync(Guid companyId, Guid employeeId, bool trackChanges);

    /// <summary>
    /// Updates the Employee entity with the specified ID for the specified company using the specified EmployeeForUpdateDto object.
    /// </summary>
    /// <param name="companyId">The ID of the company that the employee belongs to.</param>
    /// <param name="employeeId">The ID of the employee to update.</param>
    /// <param name="employeeForUpdate">The EmployeeForUpdateDto object that specifies the updated data for the entity.</param>
    /// <param name="compTrackChanges">A boolean indicating whether or not to track changes to the company entity.</param>
    /// <param name="empTrackChanges">A boolean indicating whether or not to track changes to the employee entity.</param>
    Task UpdateEmployeeForCompanyAsync(Guid companyId, Guid employeeId, EmployeeForUpdateDto employeeForUpdate, bool compTrackChanges, bool empTrackChanges);

    /// <summary>
    /// Returns a tuple containing an EmployeeForUpdateDto object representing the employee with the specified ID for the specified company, and the corresponding Employee entity. 
    /// This method is used for partially updating an employee using HTTP PATCH.
    /// </summary>
    /// <param name="companyId">The ID of the company that the employee belongs to.</param>
    /// <param name="employeeId">The ID of the employee to retrieve.</param>
    /// <param name="compTrackChanges">A boolean indicating whether or not to track changes to the company entity.</param>
    /// <param name="empTrackChanges">A boolean indicating whether or not to track changes to the employee entity.</param>
    /// <returns>A tuple containing an EmployeeForUpdateDto object for patching and the corresponding Employee entity.</returns>
    Task<(EmployeeForUpdateDto employeeToPatch, Employee employeeEntity)> GetEmployeeForPatchAsync(Guid companyId, Guid employeeId, bool compTrackChanges, bool empTrackChanges);

    /// <summary>
    /// Saves the changes after patching an employee.
    /// </summary>
    /// <param name="employeeToPatch">The EmployeeForUpdateDto object that contains the updated data.</param>
    /// <param name="employeeEntity">The corresponding Employee entity that will be updated.</param>
    /// <returns>An asynchronous operation.</returns>
    Task SaveChangesForPatchAsync(EmployeeForUpdateDto employeeToPatch, Employee employeeEntity);
}