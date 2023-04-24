using Contracts;
using Repository.Contracts;
using Service.Contracts;

namespace Service;

internal sealed class CompanyService : ICompanyService
{
    private readonly IRepositoryManager repository;
    private readonly ILoggerManager logger;

    public CompanyService(IRepositoryManager repository, ILoggerManager logger)
    {
        this.repository = repository;
        this.logger = logger;
    }
}