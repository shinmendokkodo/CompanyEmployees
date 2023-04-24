using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Moq;
using Repository.Contracts;
using Service.Contracts;
using Shared.DataTransferObjects;
using Xunit;

namespace Service.Tests
{
    public class EmployeeServiceTests
    {
        private readonly IServiceManager _serviceManager;
        private readonly Mock<IRepositoryManager> _repositoryManagerMock;
        private readonly Mock<ILoggerManager> _loggerManagerMock;
        private readonly Mock<IMapper> _mapperMock;

        public EmployeeServiceTests()
        {
            _repositoryManagerMock = new Mock<IRepositoryManager>();
            _loggerManagerMock = new Mock<ILoggerManager>();
            _mapperMock = new Mock<IMapper>();
            _serviceManager = new ServiceManager(_repositoryManagerMock.Object, _loggerManagerMock.Object, _mapperMock.Object);
        }
        /*
        [Fact]
        public async Task GetEmployeesAsync_ReturnsEmployeeDtoList()
        {
            // Arrange
            var companyId = Guid.NewGuid();
            var company = new Company { Id = companyId };
            var employees = new List<Employee>
            {
                new Employee { Id = Guid.NewGuid(), Name = "John Doe" },
                new Employee { Id = Guid.NewGuid(), Name = "Jane Doe" }
            };

            _repositoryManagerMock.Setup(r => r.CompanyRepository.GetCompanyAsync(companyId, false))
                .ReturnsAsync(company);
            _repositoryManagerMock.Setup(r => r.EmployeeRepository.GetEmployeesAsync(companyId, false))
                .ReturnsAsync(employees);
            _mapperMock.Setup(m => m.Map<IEnumerable<EmployeeDto>>(It.IsAny<IEnumerable<Employee>>()))
                .Returns(new List<EmployeeDto>
                {
                    new EmployeeDto { Id = employees[0].Id, Name = employees[0].Name },
                    new EmployeeDto { Id = employees[1].Id, Name = employees[1].Name }
                });

            // Act
            var result = await _serviceManager.EmployeeService.GetEmployeesAsync(companyId, false);

            // Assert
            Assert.NotNull(result);
            Assert.IsAssignableFrom<IEnumerable<EmployeeDto>>(result);
            Assert.Equal(2, (result as IList<EmployeeDto>).Count);
        }*/

        [Fact]
        public async Task GetEmployeesAsync_ReturnsEmployees_Success()
        {
            // Arrange
            Guid companyId = Guid.NewGuid();
            Company company = new() { Id = companyId };
            
            _repositoryManagerMock.Setup(repo => repo.CompanyRepository
                .GetCompanyAsync(companyId, false))
                .ReturnsAsync(company);

            var employees = new List<Employee>
            {
                new Employee { Id = Guid.NewGuid(), CompanyId = companyId },
                new Employee { Id = Guid.NewGuid(), CompanyId = companyId }
            };

            _repositoryManagerMock.Setup(repo => repo.EmployeeRepository
                .GetEmployeesAsync(companyId, false))
                .ReturnsAsync(employees);

            _mapperMock.Setup(m => m.Map<IEnumerable<EmployeeDto>>(It.IsAny<IEnumerable<Employee>>()))
                .Returns(new List<EmployeeDto>
                {
                    new EmployeeDto { Id = employees[0].Id },
                    new EmployeeDto { Id = employees[1].Id }
                });


            // Act
            var result = await _serviceManager.EmployeeService.GetEmployeesAsync(companyId, false);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task GetEmployeesAsync_ThrowsCompanyNotFoundException()
        {
            // Arrange
            Guid companyId = Guid.NewGuid();
            _repositoryManagerMock.Setup(repo => repo.CompanyRepository.GetCompanyAsync(companyId, false))
                .ReturnsAsync((Company)null);

            // Act & Assert
            await Assert.ThrowsAsync<CompanyNotFoundException>(() => _serviceManager.EmployeeService.GetEmployeesAsync(companyId, false));
        }

        [Fact]
        public async Task GetEmployeeAsync_ReturnsEmployee_Success()
        {
            // Arrange
            Guid companyId = Guid.NewGuid();
            Guid employeeId = Guid.NewGuid();
            Company company = new() { Id = companyId };
            
            _repositoryManagerMock.Setup(repo => repo.CompanyRepository
                .GetCompanyAsync(companyId, false))
                .ReturnsAsync(company);

            Employee employee = new Employee { Id = employeeId, CompanyId = companyId };
            
            _repositoryManagerMock.Setup(repo => repo.EmployeeRepository
                .GetEmployeeAsync(companyId, employeeId, false))
                .ReturnsAsync(employee);

            _mapperMock.Setup(m => m.Map<EmployeeDto>(It.IsAny<Employee>()))
                .Returns(new EmployeeDto { Id = employee.Id });

            // Act
            var result = await _serviceManager.EmployeeService.GetEmployeeAsync(companyId, employeeId, false);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(employeeId, result.Id);
        }

        [Fact]
        public async Task GetEmployeeAsync_ThrowsCompanyNotFoundException()
        {
            // Arrange
            Guid companyId = Guid.NewGuid();
            Guid employeeId = Guid.NewGuid();
            _repositoryManagerMock.Setup(repo => repo.CompanyRepository
                .GetCompanyAsync(companyId, false))
                .ReturnsAsync((Company)null);

            // Act & Assert
            await Assert.ThrowsAsync<CompanyNotFoundException>(() => _serviceManager.EmployeeService.GetEmployeeAsync(companyId, employeeId, false));
        }
    }
}
