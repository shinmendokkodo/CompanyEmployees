using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using System;

namespace CompanyEmployees.Presentation.Controllers;

[Route("api/companies/{companyId}/employees")]
[ApiController]
public class EmployeesController : ControllerBase
{
	private readonly IServiceManager service;

	public EmployeesController(IServiceManager service) => this.service = service;

	[HttpGet]
	public IActionResult GetEmployeesForCompany(Guid companyId)
	{
		var employees = service.EmployeeService.GetEmployees(companyId, trackChanges: false);
		return Ok(employees);
	}

	[HttpGet("{employeeId:guid}")]
	public IActionResult GetEmployeeForCompany(Guid companyId, Guid employeeId)
	{
		var employee = service.EmployeeService.GetEmployee(companyId, employeeId, trackChanges: false);
		return Ok(employee);
	}
}
