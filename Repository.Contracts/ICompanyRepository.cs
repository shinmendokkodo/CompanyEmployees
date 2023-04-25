using Entities.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Contracts;

/// <summary>
/// The ICompanyRepository interface defines the contract for a repository that provides access to Company entities.
/// </summary>
public interface ICompanyRepository
{
    /// <summary>
    /// Asynchronously retrieves all Company entities from the repository.
    /// </summary>
    /// <param name="trackChanges">A boolean indicating whether or not to track changes to the entities.</param>
    /// <returns>An asynchronous operation that returns a collection of Company entities.</returns>
    Task<IEnumerable<Company>> GetAllCompaniesAsync(bool trackChanges);

    /// <summary>
    /// Asynchronously retrieves a single Company entity with the specified ID from the repository.
    /// </summary>
    /// <param name="companyId">The ID of the company to retrieve.</param>
    /// <param name="trackChanges">A boolean indicating whether or not to track changes to the entity.</param>
    /// <returns>An asynchronous operation that returns a single Company entity.</returns>
    Task<Company> GetCompanyAsync(Guid companyId, bool trackChanges);

    /// <summary>
    /// Adds a new Company entity to the repository.
    /// </summary>
    /// <param name="company">The Company entity to add to the repository.</param>
    void CreateCompany(Company company);

    /// <summary>
    /// Asynchronously retrieves a collection of Company entities with the specified IDs from the repository.
    /// </summary>
    /// <param name="companyIds">The IDs of the companies to retrieve.</param>
    /// <param name="trackChanges">A boolean indicating whether or not to track changes to the entities.</param>
    /// <returns>An asynchronous operation that returns a collection of Company entities.</returns>
    Task<IEnumerable<Company>> GetByIdsAsync(IEnumerable<Guid> companyIds, bool trackChanges);

    /// <summary>
    /// Deletes the specified Company entity from the repository.
    /// </summary>
    /// <param name="company">The Company entity to delete.</param>
    void DeleteCompany(Company company);
}
