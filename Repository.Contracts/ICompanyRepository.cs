using Entities.Models;
using System;
using System.Collections.Generic;

namespace Repository.Contracts;

public interface ICompanyRepository
{
    IEnumerable<Company> GetAllCompanies(bool trackChanges);
    Company GetCompany(Guid companyId, bool trackChanges);
}
