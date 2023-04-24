using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;
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

	[HttpGet("{employeeId:guid}", Name = "GetEmployeeForCompany")]
	public IActionResult GetEmployeeForCompany(Guid companyId, Guid employeeId)
	{
		var employee = service.EmployeeService.GetEmployee(companyId, employeeId, trackChanges: false);
		return Ok(employee);
	}

    [HttpPost] 
	public IActionResult CreateEmployeeForCompany(Guid companyId, [FromBody] EmployeeForCreationDto employee) 
	{ 
		if (employee is null) 
			return BadRequest("EmployeeForCreationDto object is null"); 
		var employeeToReturn = service.EmployeeService.CreateEmployeeForCompany(companyId, employee, trackChanges: false); 
		return CreatedAtRoute("GetEmployeeForCompany", new { companyId, employeeId = employeeToReturn.Id }, employeeToReturn); 
	}
}
