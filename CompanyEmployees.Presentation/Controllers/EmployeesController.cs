using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;
using System;
using System.Threading.Tasks;

namespace CompanyEmployees.Presentation.Controllers;

[Route("api/companies/{companyId}/employees")]
[ApiController]
public class EmployeesController : ControllerBase
{
	private readonly IServiceManager serviceManager;

	public EmployeesController(IServiceManager serviceManager) => this.serviceManager = serviceManager;

	[HttpGet]
    public async Task<IActionResult> GetEmployeesForCompany(Guid companyId)
	{
		var employees = await serviceManager.EmployeeService.GetEmployeesAsync(companyId, trackChanges: false);
		
        return Ok(employees);
	}

	[HttpGet("{employeeId:guid}", Name = "GetEmployeeForCompany")]
    public async Task<IActionResult> GetEmployeeForCompanyAsync(Guid companyId, Guid employeeId)
	{
		var employee = await serviceManager.EmployeeService.GetEmployeeAsync(companyId, employeeId, trackChanges: false);
		
        return Ok(employee);
	}

    [HttpPost]
    public async Task<IActionResult> CreateEmployeeForCompanyAsync(Guid companyId, [FromBody] EmployeeForCreationDto employee) 
	{
        if (employee is null)
        {
            return BadRequest("EmployeeForCreationDto object is null");
        }

        if (!ModelState.IsValid)
        {
            return UnprocessableEntity(ModelState);
        }

        var employeeToReturn = await serviceManager.EmployeeService.CreateEmployeeForCompanyAsync(companyId, employee, trackChanges: false); 

		return CreatedAtRoute("GetEmployeeForCompany", new { companyId, employeeId = employeeToReturn.Id }, employeeToReturn); 
	}

    [HttpDelete("{employeeId:guid}")]
    public async Task<IActionResult> DeleteEmployeeForCompany(Guid companyId, Guid employeeId)
    {
        await serviceManager.EmployeeService.DeleteEmployeeForCompanyAsync(companyId, employeeId, trackChanges: false);

        return NoContent();
    }

    [HttpPut("{employeeId:guid}")]
    public async Task<IActionResult> UpdateEmployeeForCompanyAsync(Guid companyId, Guid employeeId, [FromBody] EmployeeForUpdateDto employee)
    {
        if (employee is null)
        {
            return BadRequest("EmployeeForUpdateDto object is null");
        }
        
        await serviceManager.EmployeeService.UpdateEmployeeForCompanyAsync(companyId, employeeId, employee, compTrackChanges: false, empTrackChanges: true);
        
        return NoContent();
    }

    [HttpPatch("{employeeId:guid}")]
    public async Task<IActionResult> PartiallyUpdateEmployeeForCompanyAsync(Guid companyId, Guid employeeId, [FromBody] JsonPatchDocument<EmployeeForUpdateDto> patchDoc)
    {
        if (patchDoc is null)
        {
            return BadRequest("patchDoc object sent from client is null.");
        }
        
        var (employeeToPatch, employeeEntity) = await serviceManager.EmployeeService.GetEmployeeForPatchAsync(companyId, employeeId, compTrackChanges: false, empTrackChanges: true);
        
        patchDoc.ApplyTo(employeeToPatch, ModelState);

        TryValidateModel(employeeToPatch);

        if (!ModelState.IsValid)
        {
            return UnprocessableEntity(ModelState);
        }
        
        await serviceManager.EmployeeService.SaveChangesForPatchAsync(employeeToPatch, employeeEntity);

        return NoContent();
    }
}
