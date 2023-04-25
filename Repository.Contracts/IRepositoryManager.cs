using System.Threading.Tasks;

namespace Repository.Contracts;

/// <summary>
/// The IRepositoryManager interface defines the contract for a repository manager that provides access to company and employee repositories.
/// </summary>
public interface IRepositoryManager
{
    /// <summary>
    /// Gets the company repository instance.
    /// </summary>
    ICompanyRepository CompanyRepository { get; }

    /// <summary>
    /// Gets the employee repository instance.
    /// </summary>
    IEmployeeRepository EmployeeRepository { get; }

    /// <summary>
    /// Asynchronously saves all changes made to the repositories.
    /// </summary>
    /// <returns>An asynchronous operation.</returns>
    Task SaveAsync();
}
