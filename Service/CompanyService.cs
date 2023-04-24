using Contracts;
using Entities.Models;
using Repository.Contracts;
using Service.Contracts;
using System.Collections.Generic;
using System;
using Shared.DataTransferObjects;
using System.Linq;
using AutoMapper;
using Entities.Exceptions;

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
        throw new Exception();
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
}