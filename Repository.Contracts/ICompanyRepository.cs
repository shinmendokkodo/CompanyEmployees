using Entities.Models;
using System;
using System.Collections.Generic;

namespace Repository.Contracts;

public interface ICompanyRepository
{
    IEnumerable<Company> GetAllCompanies(bool trackChanges);
    Company GetCompany(Guid companyId, bool trackChanges);
    void CreateCompany(Company company);
    IEnumerable<Company> GetByIds(IEnumerable<Guid> companyIds, bool trackChanges);
    void DeleteCompany(Company company);
}
