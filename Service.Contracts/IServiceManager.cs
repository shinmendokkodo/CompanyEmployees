namespace Service.Contracts;

/// <summary>
/// The IServiceManager interface defines the contract for a service manager that provides access to company and employee services.
/// </summary>
public interface IServiceManager
{
    /// <summary>
    /// Gets the company service instance.
    /// </summary>
    ICompanyService CompanyService { get; }

    /// <summary>
    /// Gets the employee service instance.
    /// </summary>
    IEmployeeService EmployeeService { get; }
}
