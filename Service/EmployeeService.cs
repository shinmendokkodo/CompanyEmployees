using Contracts;
using Repository.Contracts;
using Service.Contracts;

namespace Service;

internal sealed class EmployeeService : IEmployeeService
{
    private readonly IRepositoryManager repository;
    private readonly ILoggerManager logger;

    public EmployeeService(IRepositoryManager repository, ILoggerManager logger)
    {
        this.repository = repository;
        this.logger = logger;
    }
}
