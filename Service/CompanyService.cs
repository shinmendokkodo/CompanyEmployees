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
    private readonly IRepositoryManager repository;
    private readonly ILoggerManager logger;
    private readonly IMapper mapper;

    public CompanyService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
    {
        this.repository = repository;
        this.logger = logger;
        this.mapper = mapper;
    }

    public IEnumerable<CompanyDto> GetAllCompanies(bool trackChanges) 
    {
        var companies = repository.Company.GetAllCompanies(trackChanges);
        var companiesDto = mapper.Map<IEnumerable<CompanyDto>>(companies);
        return companiesDto;        
    }

    public CompanyDto GetCompany(Guid companyId, bool trackChanges)
    {
        var company = repository.Company.GetCompany(companyId, trackChanges) ?? throw new CompanyNotFoundException(companyId);
        var companyDto = mapper.Map<CompanyDto>(company); 
        return companyDto; 
    }

    public CompanyDto CreateCompany(CompanyForCreationDto company) 
    { 
        var companyEntity = mapper.Map<Company>(company); 
        repository.Company.CreateCompany(companyEntity); 
        repository.Save(); 
        var companyToReturn = mapper.Map<CompanyDto>(companyEntity); 
        return companyToReturn; 
    }

    public IEnumerable<CompanyDto> GetByIds(IEnumerable<Guid> companyIds, bool trackChanges) 
    { 
        if (companyIds is null) throw new IdParametersBadRequestException(); 
        var companyEntities = repository.Company.GetByIds(companyIds, trackChanges); 
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
            repository.Company.CreateCompany(company);
        } 
        repository.Save(); 
        var companyCollectionToReturn = mapper.Map<IEnumerable<CompanyDto>>(companyEntities); 
        
        var companyIds = string.Join(",", companyCollectionToReturn.Select(c => c.Id)); 
        return (companies: companyCollectionToReturn, companyIds: companyIds); 
    }
}