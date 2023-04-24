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

internal sealed class CompanyService : ICompanyService
{
    private readonly IRepositoryManager repositoryManager;
    private readonly ILoggerManager loggerManager;
    private readonly IMapper mapper;

    public CompanyService(IRepositoryManager repositoryManager, ILoggerManager loggerManager, IMapper mapper)
    {
        this.repositoryManager = repositoryManager;
        this.loggerManager = loggerManager;
        this.mapper = mapper;
    }

    public async Task<IEnumerable<CompanyDto>> GetAllCompaniesAsync(bool trackChanges) 
    {
        var companies = await repositoryManager.CompanyRepository.GetAllCompaniesAsync(trackChanges);
        var companiesDto = mapper.Map<IEnumerable<CompanyDto>>(companies);
        return companiesDto;        
    }

    public async Task<CompanyDto> GetCompanyAsync(Guid companyId, bool trackChanges)
    {
        var company = await repositoryManager.CompanyRepository.GetCompanyAsync(companyId, trackChanges) ?? throw new CompanyNotFoundException(companyId);
        var companyDto = mapper.Map<CompanyDto>(company); 
        return companyDto; 
    }

    public async Task<CompanyDto> CreateCompanyAsync(CompanyForCreationDto company) 
    { 
        var companyEntity = mapper.Map<Company>(company); 
        repositoryManager.CompanyRepository.CreateCompany(companyEntity); 
        await repositoryManager.SaveAsync(); 
        var companyToReturn = mapper.Map<CompanyDto>(companyEntity); 
        return companyToReturn; 
    }

    public async Task<IEnumerable<CompanyDto>> GetByIdsAsync(IEnumerable<Guid> companyIds, bool trackChanges) 
    { 
        if (companyIds is null) throw new IdParametersBadRequestException(); 
        var companyEntities = await repositoryManager.CompanyRepository.GetByIdsAsync(companyIds, trackChanges); 
        if (companyIds.Count() != companyEntities.Count()) throw new CollectionByIdsBadRequestException(); 
        var companiesToReturn = mapper.Map<IEnumerable<CompanyDto>>(companyEntities); 
        return companiesToReturn; 
    }

    public async Task<(IEnumerable<CompanyDto> companies, string companyIds)> CreateCompanyCollectionAsync(IEnumerable<CompanyForCreationDto> companyCollection) 
    { 
        if (companyCollection is null) throw new CompanyCollectionBadRequest(); 
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

    public async Task DeleteCompanyAsync(Guid companyId, bool trackChanges)
    {
        var company = await repositoryManager.CompanyRepository.GetCompanyAsync(companyId, trackChanges) ?? throw new CompanyNotFoundException(companyId);
        repositoryManager.CompanyRepository.DeleteCompany(company);
        await repositoryManager.SaveAsync();
    }

    public async Task UpdateCompanyAsync(Guid companyId, CompanyForUpdateDto companyForUpdate, bool trackChanges)
    {
        var companyEntity = await repositoryManager.CompanyRepository.GetCompanyAsync(companyId, trackChanges) ?? throw new CompanyNotFoundException(companyId);
        mapper.Map(companyForUpdate, companyEntity);
        await repositoryManager.SaveAsync();
    }
}