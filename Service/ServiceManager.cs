using AutoMapper;
using Contracts;
using Repository.Contracts;
using Service.Contracts;
using System;

namespace Service;

/// <summary>
/// The ServiceManager class implements the IServiceManager interface and provides access to the CompanyService and EmployeeService objects.
/// </summary>
public sealed class ServiceManager : IServiceManager
{
    private readonly Lazy<ICompanyService> companyService;
    private readonly Lazy<IEmployeeService> employeeService;

    /// <summary>
    /// Initializes a new instance of the ServiceManager class.
    /// </summary>
    /// <param name="repositoryManager">The IRepositoryManager instance that will be used by the services.</param>
    /// <param name="logger">The ILoggerManager instance that will be used by the services.</param>
    /// <param name="mapper">The IMapper instance that will be used by the services.</param>
    public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper)
    {
        companyService = new Lazy<ICompanyService>(() => new CompanyService(repositoryManager, logger, mapper));
        employeeService = new Lazy<IEmployeeService>(() => new EmployeeService(repositoryManager, logger, mapper));
    }

    /// <summary>
    /// Gets the ICompanyService instance created by the ServiceManager class.
    /// </summary>
    public ICompanyService CompanyService => companyService.Value;

    /// <summary>
    /// Gets the IEmployeeService instance created by the ServiceManager class.
    /// </summary>
    public IEmployeeService EmployeeService => employeeService.Value;
}
