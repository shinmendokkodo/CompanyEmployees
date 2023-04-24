﻿using Repository.Contracts;
using Entities.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Repository;

internal sealed class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
{
    public CompanyRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public IEnumerable<Company> GetAllCompanies(bool trackChanges) => 
        FindAll(trackChanges).OrderBy(c => c.Name).ToList();

    public Company GetCompany(Guid companyId, bool trackChanges) => 
        FindByCondition(c => c.Id.Equals(companyId), trackChanges).SingleOrDefault();

    public void CreateCompany(Company company) => Create(company);

    public IEnumerable<Company> GetByIds(IEnumerable<Guid> companyIds, bool trackChanges) => 
        FindByCondition(c => companyIds.Contains(c.Id), trackChanges).ToList();

    public void DeleteCompany(Company company) => Delete(company);
}
