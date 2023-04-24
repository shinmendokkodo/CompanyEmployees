using Repository.Contracts;
using Entities.Models;
using System.Collections.Generic;
using System.Linq;

namespace Repository;

internal sealed class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
{
    public CompanyRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public IEnumerable<Company> GetAllCompanies(bool trackChanges) => 
        FindAll(trackChanges).OrderBy(c => c.Name).ToList();
}
