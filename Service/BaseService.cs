using AutoMapper;
using Contracts;
using Repository.Contracts;

namespace Service;

/// <summary>
/// The BaseService class serves as an abstract base class for all service classes in the application.
/// It contains common properties and methods that are shared among derived service classes.
/// </summary>
internal abstract class BaseService
{
    protected readonly IRepositoryManager repositoryManager;
    protected readonly ILoggerManager loggerManager;
    protected readonly IMapper mapper;

    /// <summary>
    /// Initializes a new instance of the BaseService class with the specified IRepositoryManager, ILoggerManager, and IMapper instances.
    /// </summary>
    /// <param name="repositoryManager">An instance of a class implementing the IRepositoryManager interface.</param>
    /// <param name="loggerManager">An instance of a class implementing the ILoggerManager interface.</param>
    /// <param name="mapper">An instance of a class implementing the IMapper interface.</param>
    protected BaseService(IRepositoryManager repositoryManager, ILoggerManager loggerManager, IMapper mapper)
    {
        this.repositoryManager = repositoryManager;
        this.loggerManager = loggerManager;
        this.mapper = mapper;
    }
}
