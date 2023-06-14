using Shared.DataTransferObjects;

namespace Service.Contracts;

/// <summary>
/// The ICompanyService interface defines the contract for a service that handles operations on Company entities.
/// </summary>
public interface ICompanyService
{
    /// <summary>
    /// Retrieves a collection of CompanyDto objects representing all companies in the system.
    /// </summary>
    /// <param name="trackChanges">A boolean indicating whether or not to track changes to the entities.</param>
    /// <returns>A collection of CompanyDto objects.</returns>
    Task<IEnumerable<CompanyDto>> GetAllCompaniesAsync(bool trackChanges);

    /// <summary>
    /// Retrieves a single CompanyDto object representing the company with the specified ID.
    /// </summary>
    /// <param name="companyId">The ID of the company to retrieve.</param>
    /// <param name="trackChanges">A boolean indicating whether or not to track changes to the entity.</param>
    /// <returns>A single CompanyDto object.</returns>
    Task<CompanyDto> GetCompanyAsync(Guid companyId, bool trackChanges);

    /// <summary>
    /// Creates a new Company entity using the specified CompanyForCreationDto object.
    /// </summary>
    /// <param name="company">The CompanyForCreationDto object that specifies the data for the new entity.</param>
    /// <returns>A CompanyDto object representing the newly created entity.</returns>
    Task<CompanyDto> CreateCompanyAsync(CompanyForCreationDto company);

    /// <summary>
    /// Retrieves a collection of CompanyDto objects representing the companies with the specified IDs.
    /// </summary>
    /// <param name="companyIds">A collection of IDs specifying the companies to retrieve.</param>
    /// <param name="trackChanges">A boolean indicating whether or not to track changes to the entities.</param>
    /// <returns>A collection of CompanyDto objects.</returns>
    Task<IEnumerable<CompanyDto>> GetByIdsAsync(IEnumerable<Guid> companyIds, bool trackChanges);

    /// <summary>
    /// Creates a collection of Company entities using the specified collection of CompanyForCreationDto objects.
    /// </summary>
    /// <param name="companyCollection">The collection of CompanyForCreationDto objects that specifies the data for the new entities.</param>
    /// <returns>A tuple containing a collection of CompanyDto objects and a string representing the IDs of the newly created entities.</returns>
    Task<(IEnumerable<CompanyDto> companies, string companyIds)> CreateCompanyCollectionAsync(IEnumerable<CompanyForCreationDto> companyCollection);

    /// <summary>
    /// Deletes the Company entity with the specified ID.
    /// </summary>
    /// <param name="companyId">The ID of the company to delete.</param>
    /// <param name="trackChanges">A boolean indicating whether or not to track changes to the entity.</param>
    Task DeleteCompanyAsync(Guid companyId, bool trackChanges);

    /// <summary>
    /// Updates the Company entity with the specified ID using the specified CompanyForUpdateDto object.
    /// </summary>
    /// <param name="companyId">The ID of the company to update.</param>
    /// <param name="companyForUpdate">The CompanyForUpdateDto object that specifies the updated data for the entity.</param>
    /// <param name="trackChanges">A boolean indicating whether or not to track changes to the entity.</param>
    Task UpdateCompanyAsync(Guid companyId, CompanyForUpdateDto companyForUpdate, bool trackChanges);
}