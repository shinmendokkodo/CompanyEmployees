using Contracts;
using Repository.Contracts;
using Service.Contracts;
using System.Collections.Generic;
using System;
using Shared.DataTransferObjects;
using AutoMapper;
using Entities.Exceptions;
using Entities.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Service;

/// <summary>
/// Provides services related to managing companies.
/// </summary>
internal sealed class CompanyService : BaseService, ICompanyService
{

    /// <summary>
    /// Initializes a new instance of the <see cref="CompanyService"/> class.
    /// </summary>
    /// <param name="repositoryManager">The repository manager.</param>
    /// <param name="loggerManager">The logger manager.</param>
    /// <param name="mapper">The AutoMapper instance used for mapping between data transfer objects and entity models.</param>
    public CompanyService(IRepositoryManager repositoryManager, ILoggerManager loggerManager, IMapper mapper)
        : base(repositoryManager, loggerManager, mapper)
    {
    }

    /// <inheritdoc/>
    public async Task<IEnumerable<CompanyDto>> GetAllCompaniesAsync(bool trackChanges) 
    {
        var companies = await repositoryManager.CompanyRepository.GetAllCompaniesAsync(trackChanges);

        var companiesDto = mapper.Map<IEnumerable<CompanyDto>>(companies);

        return companiesDto;        
    }

    /// <inheritdoc/>
    public async Task<CompanyDto> GetCompanyAsync(Guid companyId, bool trackChanges)
    {
        var company = await GetCompanyAndCheckIfItExistsAsync(companyId, trackChanges);
        
        var companyDto = mapper.Map<CompanyDto>(company); 
        return companyDto; 
    }

    /// <inheritdoc/>
    public async Task<CompanyDto> CreateCompanyAsync(CompanyForCreationDto company) 
    { 
        var companyEntity = mapper.Map<Company>(company); 
        
        repositoryManager.CompanyRepository.CreateCompany(companyEntity); 
       
        await repositoryManager.SaveAsync(); 
        
        var companyToReturn = mapper.Map<CompanyDto>(companyEntity); 
        return companyToReturn; 
    }

    /// <inheritdoc/>
    public async Task<IEnumerable<CompanyDto>> GetByIdsAsync(IEnumerable<Guid> companyIds, bool trackChanges) 
    {
        if (companyIds is null)
        {
            throw new IdParametersBadRequestException();
        }

        var companyEntities = await repositoryManager.CompanyRepository.GetByIdsAsync(companyIds, trackChanges);

        if (companyIds.Count() != companyEntities.Count())
        {
            throw new CollectionByIdsBadRequestException();
        }

        var companiesToReturn = mapper.Map<IEnumerable<CompanyDto>>(companyEntities);    
        return companiesToReturn;
    }

    /// <inheritdoc/>
    public async Task<(IEnumerable<CompanyDto> companies, string companyIds)> CreateCompanyCollectionAsync(IEnumerable<CompanyForCreationDto> companyCollection) 
    {
        if (companyCollection is null)
        {
            throw new CompanyCollectionBadRequest();
        }
        
        var companyEntities = mapper.Map<IEnumerable<Company>>(companyCollection);
        foreach (var company in companyEntities)
        {
            repositoryManager.CompanyRepository.CreateCompany(company);
        }

        await repositoryManager.SaveAsync();
        var companyCollectionToReturn = mapper.Map<IEnumerable<CompanyDto>>(companyEntities);
        
        var companyIds = string.Join(",", companyCollectionToReturn.Select(c => c.Id));
        return (companies: companyCollectionToReturn, companyIds: companyIds);
    }

    /// <inheritdoc/>
    public async Task DeleteCompanyAsync(Guid companyId, bool trackChanges)
    {
        Company company = await GetCompanyAndCheckIfItExistsAsync(companyId, trackChanges);

        repositoryManager.CompanyRepository.DeleteCompany(company);
        await repositoryManager.SaveAsync();
    }

    /// <inheritdoc/>
    public async Task UpdateCompanyAsync(Guid companyId, CompanyForUpdateDto companyForUpdate, bool trackChanges)
    {
        var companyEntity = await GetCompanyAndCheckIfItExistsAsync(companyId, trackChanges);
        
        mapper.Map(companyForUpdate, companyEntity);
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
}