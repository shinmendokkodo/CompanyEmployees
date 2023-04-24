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
internal sealed class CompanyService : ICompanyService
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly ILoggerManager _loggerManager;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of the <see cref="CompanyService"/> class.
    /// </summary>
    /// <param name="repositoryManager">The repository manager.</param>
    /// <param name="loggerManager">The logger manager.</param>
    /// <param name="mapper">The AutoMapper instance used for mapping between data transfer objects and entity models.</param>
    public CompanyService(IRepositoryManager repositoryManager, ILoggerManager loggerManager, IMapper mapper)
    {
        _repositoryManager = repositoryManager;
        _loggerManager = loggerManager;
        _mapper = mapper;
    }

    /// <summary>
    /// Retrieves all companies asynchronously.
    /// </summary>
    /// <param name="trackChanges">Indicates whether to track changes in the DbContext.</param>
    /// <returns>A collection of CompanyDto objects.</returns>
    public async Task<IEnumerable<CompanyDto>> GetAllCompaniesAsync(bool trackChanges) 
    {
        var companies = await _repositoryManager.CompanyRepository.GetAllCompaniesAsync(trackChanges);

        var companiesDto = _mapper.Map<IEnumerable<CompanyDto>>(companies);

        return companiesDto;        
    }

    /// <summary>
    /// Retrieves a company by its identifier asynchronously.
    /// </summary>
    /// <param name="companyId">The company identifier.</param>
    /// <param name="trackChanges">Indicates whether to track changes in the DbContext.</param>
    /// <returns>A CompanyDto object.</returns>
    /// <exception cref="CompanyNotFoundException">Thrown when the company is not found.</exception>
    public async Task<CompanyDto> GetCompanyAsync(Guid companyId, bool trackChanges)
    {
        var company = await _repositoryManager.CompanyRepository.GetCompanyAsync(companyId, trackChanges) 
            ?? throw new CompanyNotFoundException(companyId);
        
        var companyDto = _mapper.Map<CompanyDto>(company); 
        return companyDto; 
    }

    /// <summary>
    /// Creates a new company asynchronously.
    /// </summary>
    /// <param name="company">The CompanyForCreationDto object containing the company details.</param>
    /// <returns>A CompanyDto object representing the created company.</returns>
    public async Task<CompanyDto> CreateCompanyAsync(CompanyForCreationDto company) 
    { 
        var companyEntity = _mapper.Map<Company>(company); 
        
        _repositoryManager.CompanyRepository.CreateCompany(companyEntity); 
       
        await _repositoryManager.SaveAsync(); 
        
        var companyToReturn = _mapper.Map<CompanyDto>(companyEntity); 
        return companyToReturn; 
    }

    /// <summary>
    /// Retrieves a collection of companies by their identifiers asynchronously.
    /// </summary>
    /// <param name="companyIds">A collection of company identifiers.</param>
    /// <param name="trackChanges">Indicates whether to track changes in the DbContext.</param>
    /// <returns>A collection of CompanyDto objects.</returns>
    /// <exception cref="IdParametersBadRequestException">Thrown when the companyIds parameter is null.</exception>
    /// <exception cref="CollectionByIdsBadRequestException">Thrown when the number of requested company identifiers does not match the number of retrieved companies.</exception>
    public async Task<IEnumerable<CompanyDto>> GetByIdsAsync(IEnumerable<Guid> companyIds, bool trackChanges) 
    {
        if (companyIds is null)
        {
            throw new IdParametersBadRequestException();
        }

        var companyEntities = await _repositoryManager.CompanyRepository.GetByIdsAsync(companyIds, trackChanges);

        if (companyIds.Count() != companyEntities.Count())
        {
            throw new CollectionByIdsBadRequestException();
        }

        var companiesToReturn = _mapper.Map<IEnumerable<CompanyDto>>(companyEntities);    
        return companiesToReturn;
    }

    /// <summary>
    /// Creates a collection of companies asynchronously.
    /// </summary>
    /// <param name="companyCollection">A collection of CompanyForCreationDto objects containing the company details.</param>
    /// <returns>A tuple containing a collection of created CompanyDto objects and a comma-separated string of their identifiers.</returns>
    /// <exception cref="CompanyCollectionBadRequest">Thrown when the companyCollection parameter is null.</exception>
    public async Task<(IEnumerable<CompanyDto> companies, string companyIds)> CreateCompanyCollectionAsync(IEnumerable<CompanyForCreationDto> companyCollection) 
    {
        if (companyCollection is null)
        {
            throw new CompanyCollectionBadRequest();
        }
        
        var companyEntities = _mapper.Map<IEnumerable<Company>>(companyCollection);
        foreach (var company in companyEntities)
        {
            _repositoryManager.CompanyRepository.CreateCompany(company);
        }

        await _repositoryManager.SaveAsync();
        var companyCollectionToReturn = _mapper.Map<IEnumerable<CompanyDto>>(companyEntities);
        
        var companyIds = string.Join(",", companyCollectionToReturn.Select(c => c.Id));
        return (companies: companyCollectionToReturn, companyIds: companyIds);
    }

    /// <summary>
    /// Deletes a company by its identifier asynchronously.
    /// </summary>
    /// <param name="companyId">The company identifier.</param>
    /// <param name="trackChanges">Indicates whether to track changes in the DbContext.</param>
    /// <exception cref="CompanyNotFoundException">Thrown when the company is not found.</exception>
    public async Task DeleteCompanyAsync(Guid companyId, bool trackChanges)
    {
        var company = await _repositoryManager.CompanyRepository.GetCompanyAsync(companyId, trackChanges) 
            ?? throw new CompanyNotFoundException(companyId);
        
        _repositoryManager.CompanyRepository.DeleteCompany(company);
        await _repositoryManager.SaveAsync();
    }

    /// <summary>
    /// Updates a company's details asynchronously.
    /// </summary>
    /// <param name="companyId">The company identifier.</param>
    /// <param name="companyForUpdate">A CompanyForUpdateDto object containing the updated company details.</param>
    /// <param name="trackChanges">Indicates whether to track changes in the DbContext.</param>
    /// <exception cref="CompanyNotFoundException">Thrown when the company is not found.</exception>
    public async Task UpdateCompanyAsync(Guid companyId, CompanyForUpdateDto companyForUpdate, bool trackChanges)
    {
        var companyEntity = await _repositoryManager.CompanyRepository.GetCompanyAsync(companyId, trackChanges) 
            ?? throw new CompanyNotFoundException(companyId);
        
        _mapper.Map(companyForUpdate, companyEntity);
        await _repositoryManager.SaveAsync();
    }
}