using Entities.Models;
using System.Collections.Generic;

namespace Repository.Contracts;

public interface ICompanyRepository
{
    IEnumerable<Company> GetAllCompanies(bool trackChanges);
}
