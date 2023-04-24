using CompanyEmployees.Presentation.ModelBinders;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;

namespace CompanyEmployees.Presentation.Controllers;

[Route("api/companies")]
[ApiController]
public class CompaniesController : ControllerBase
{
	private readonly IServiceManager serviceManager;

	public CompaniesController(IServiceManager service) => this.serviceManager = service;

	[HttpGet]
	public IActionResult GetCompanies()
	{
        var companies = serviceManager.CompanyService.GetAllCompanies(trackChanges: false);
		return Ok(companies);
	}

    [HttpGet("{companyId:guid}", Name = "CompanyById")] 
	public IActionResult GetCompany(Guid companyId) 
	{ 
		var company = serviceManager.CompanyService.GetCompany(companyId, trackChanges: false); 
		return Ok(company); 
	}

    [HttpPost] 
	public IActionResult CreateCompany([FromBody] CompanyForCreationDto company) 
	{ 
		if (company is null) 
			return BadRequest("CompanyForCreationDto object is null"); 
		var createdCompany = serviceManager.CompanyService.CreateCompany(company); 
		return CreatedAtRoute("CompanyById", new { companyId = createdCompany.Id }, createdCompany); 
	}

    [HttpGet("collection/({companyIds})", Name = "CompanyCollection")]
    public IActionResult GetCompanyCollection([ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<Guid> companyIds)
    { 
		var companies = serviceManager.CompanyService.GetByIds(companyIds, trackChanges: false); 
		return Ok(companies); 
	}

    [HttpPost("collection")] 
	public IActionResult CreateCompanyCollection([FromBody] IEnumerable<CompanyForCreationDto> companyCollection) 
	{ 
		var (companies, companyIds) = serviceManager.CompanyService.CreateCompanyCollection(companyCollection); 
		return CreatedAtRoute("CompanyCollection", new { companyIds }, companies); 
	}

    [HttpDelete("{companyId:guid}")]
    public IActionResult DeleteCompany(Guid companyId)
    {
        serviceManager.CompanyService.DeleteCompany(companyId, trackChanges: false);
        return NoContent();
    }

    [HttpPut("{companyId:guid}")]
    public IActionResult UpdateCompany(Guid companyId, [FromBody] CompanyForUpdateDto company)
    {
        if (company is null) return BadRequest("CompanyForUpdateDto object is null");
        serviceManager.CompanyService.UpdateCompany(companyId, company, trackChanges: true);
        return NoContent();
    }
}
