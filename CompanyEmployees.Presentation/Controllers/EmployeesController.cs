using CompanyEmployees.Presentation.ActionFilters;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace CompanyEmployees.Presentation.Controllers;

[Route("api/companies/{companyId}/employees")]
[ApiController]
public class EmployeesController : ControllerBase
{
	private readonly IServiceManager serviceManager;

	public EmployeesController(IServiceManager serviceManager) => this.serviceManager = serviceManager;

	[HttpGet]
    public async Task<IActionResult> GetEmployeesForCompanyAsync(Guid companyId, [FromQuery] EmployeeParameters employeeParameters)
	{
        var (employees, metaData) = await serviceManager.EmployeeService.GetEmployeesAsync(companyId, employeeParameters, trackChanges: false);

        Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(metaData));

        return Ok(employees);
	}

	[HttpGet("{employeeId:guid}", Name = "GetEmployeeForCompany")]
    public async Task<IActionResult> GetEmployeeForCompanyAsync(Guid companyId, Guid employeeId)
	{
		var employee = await serviceManager.EmployeeService.GetEmployeeAsync(companyId, employeeId, trackChanges: false);
		
        return Ok(employee);
	}

    [HttpPost]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> CreateEmployeeForCompanyAsync(Guid companyId, [FromBody] EmployeeForCreationDto employee) 
	{
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
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> UpdateEmployeeForCompanyAsync(Guid companyId, Guid employeeId, [FromBody] EmployeeForUpdateDto employee)
    {       
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
