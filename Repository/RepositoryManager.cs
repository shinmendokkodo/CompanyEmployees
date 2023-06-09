﻿using Repository.Contracts;
using System;
using System.Threading.Tasks;

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
   
    public ICompanyRepository CompanyRepository => companyRepository.Value; 
    public IEmployeeRepository EmployeeRepository => employeeRepository.Value; 
    public async Task SaveAsync() => await repositoryContext.SaveChangesAsync();
}
