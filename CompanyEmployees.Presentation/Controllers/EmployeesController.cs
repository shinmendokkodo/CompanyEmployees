using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;
using System;

namespace CompanyEmployees.Presentation.Controllers;

[Route("api/companies/{companyId}/employees")]
[ApiController]
public class EmployeesController : ControllerBase
{
	private readonly IServiceManager serviceManager;

	public EmployeesController(IServiceManager serviceManager) => this.serviceManager = serviceManager;

	[HttpGet]
	public IActionResult GetEmployeesForCompany(Guid companyId)
	{
		var employees = serviceManager.EmployeeService.GetEmployees(companyId, trackChanges: false);
		return Ok(employees);
	}

	[HttpGet("{employeeId:guid}", Name = "GetEmployeeForCompany")]
	public IActionResult GetEmployeeForCompany(Guid companyId, Guid employeeId)
	{
		var employee = serviceManager.EmployeeService.GetEmployee(companyId, employeeId, trackChanges: false);
		return Ok(employee);
	}

    [HttpPost] 
	public IActionResult CreateEmployeeForCompany(Guid companyId, [FromBody] EmployeeForCreationDto employee) 
	{ 
		if (employee is null) return BadRequest("EmployeeForCreationDto object is null");
        if (!ModelState.IsValid) return UnprocessableEntity(ModelState);
        var employeeToReturn = serviceManager.EmployeeService.CreateEmployeeForCompany(companyId, employee, trackChanges: false); 
		return CreatedAtRoute("GetEmployeeForCompany", new { companyId, employeeId = employeeToReturn.Id }, employeeToReturn); 
	}

    [HttpDelete("{employeeId:guid}")]
    public IActionResult DeleteEmployeeForCompany(Guid companyId, Guid employeeId)
    {
        serviceManager.EmployeeService.DeleteEmployeeForCompany(companyId, employeeId, trackChanges: false);
        return NoContent();
    }

    [HttpPut("{employeeId:guid}")]
    public IActionResult UpdateEmployeeForCompany(Guid companyId, Guid employeeId, [FromBody] EmployeeForUpdateDto employee)
    {
        if (employee is null) return BadRequest("EmployeeForUpdateDto object is null");
        serviceManager.EmployeeService.UpdateEmployeeForCompany(companyId, employeeId, employee, compTrackChanges: false, empTrackChanges: true);
        return NoContent();
    }

    [HttpPatch("{employeeId:guid}")]
    public IActionResult PartiallyUpdateEmployeeForCompany(Guid companyId, Guid employeeId, [FromBody] JsonPatchDocument<EmployeeForUpdateDto> patchDoc)
    {
        if (patchDoc is null) return BadRequest("patchDoc object sent from client is null.");
        var (employeeToPatch, employeeEntity) = serviceManager.EmployeeService.GetEmployeeForPatch(companyId, employeeId, compTrackChanges: false, empTrackChanges: true);
        patchDoc.ApplyTo(employeeToPatch, ModelState);

        TryValidateModel(employeeToPatch);
        if (!ModelState.IsValid) return UnprocessableEntity(ModelState);
        
        serviceManager.EmployeeService.SaveChangesForPatch(employeeToPatch, employeeEntity);
        return NoContent();
    }
}
