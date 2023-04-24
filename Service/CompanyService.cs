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

    public IEnumerable<CompanyDto> GetAllCompanies(bool trackChanges) 
    {
        var companies = repositoryManager.CompanyRepository.GetAllCompanies(trackChanges);
        var companiesDto = mapper.Map<IEnumerable<CompanyDto>>(companies);
        return companiesDto;        
    }

    public CompanyDto GetCompany(Guid companyId, bool trackChanges)
    {
        var company = repositoryManager.CompanyRepository.GetCompany(companyId, trackChanges) ?? throw new CompanyNotFoundException(companyId);
        var companyDto = mapper.Map<CompanyDto>(company); 
        return companyDto; 
    }

    public CompanyDto CreateCompany(CompanyForCreationDto company) 
    { 
        var companyEntity = mapper.Map<Company>(company); 
        repositoryManager.CompanyRepository.CreateCompany(companyEntity); 
        repositoryManager.Save(); 
        var companyToReturn = mapper.Map<CompanyDto>(companyEntity); 
        return companyToReturn; 
    }

    public IEnumerable<CompanyDto> GetByIds(IEnumerable<Guid> companyIds, bool trackChanges) 
    { 
        if (companyIds is null) throw new IdParametersBadRequestException(); 
        var companyEntities = repositoryManager.CompanyRepository.GetByIds(companyIds, trackChanges); 
        if (companyIds.Count() != companyEntities.Count()) throw new CollectionByIdsBadRequestException(); 
        var companiesToReturn = mapper.Map<IEnumerable<CompanyDto>>(companyEntities); 
        return companiesToReturn; 
    }

    public (IEnumerable<CompanyDto> companies, string companyIds) CreateCompanyCollection(IEnumerable<CompanyForCreationDto> companyCollection) 
    { 
        if (companyCollection is null) throw new CompanyCollectionBadRequest(); 
        var companyEntities = mapper.Map<IEnumerable<Company>>(companyCollection); 
        
        foreach (var company in companyEntities) 
        { 
            repositoryManager.CompanyRepository.CreateCompany(company);
        } 
        repositoryManager.Save(); 
        var companyCollectionToReturn = mapper.Map<IEnumerable<CompanyDto>>(companyEntities); 
        
        var companyIds = string.Join(",", companyCollectionToReturn.Select(c => c.Id)); 
        return (companies: companyCollectionToReturn, companyIds: companyIds); 
    }

    public void DeleteCompany(Guid companyId, bool trackChanges)
    {
        var company = repositoryManager.CompanyRepository.GetCompany(companyId, trackChanges) ?? throw new CompanyNotFoundException(companyId);
        repositoryManager.CompanyRepository.DeleteCompany(company);
        repositoryManager.Save();
    }

    public void UpdateCompany(Guid companyId, CompanyForUpdateDto companyForUpdate, bool trackChanges)
    {
        var companyEntity = repositoryManager.CompanyRepository.GetCompany(companyId, trackChanges);
        if (companyEntity is null)
            throw new CompanyNotFoundException(companyId);
        mapper.Map(companyForUpdate, companyEntity);
        repositoryManager.Save();
    }
}