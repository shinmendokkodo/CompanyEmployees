using Repository.Contracts;
using System;

namespace Repository;

public sealed class RepositoryManager : IRepositoryManager
{
    private readonly RepositoryContext repositoryContext; 
    private readonly Lazy<ICompanyRepository> companyRepository; 
    private readonly Lazy<IEmployeeRepository> employeeRepository;

    public RepositoryManager(RepositoryContext repositoryContext) 
    { 
        this.repositoryContext = repositoryContext; 
        companyRepository = new Lazy<ICompanyRepository>(() => new CompanyRepository(repositoryContext)); 
        employeeRepository = new Lazy<IEmployeeRepository>(() => new EmployeeRepository(repositoryContext)); 
    }
   
    public ICompanyRepository Company => companyRepository.Value; 
    public IEmployeeRepository Employee => employeeRepository.Value; 
    public void Save() => repositoryContext.SaveChanges();
}
