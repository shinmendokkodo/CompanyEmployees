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
	private readonly IServiceManager service;

	public CompaniesController(IServiceManager service) => this.service = service;

	[HttpGet]
	public IActionResult GetCompanies()
	{
        var companies = service.CompanyService.GetAllCompanies(trackChanges: false);
		return Ok(companies);
	}

    [HttpGet("{companyId:guid}", Name = "CompanyById")] 
	public IActionResult GetCompany(Guid companyId) 
	{ 
		var company = service.CompanyService.GetCompany(companyId, trackChanges: false); 
		return Ok(company); 
	}

    [HttpPost] 
	public IActionResult CreateCompany([FromBody] CompanyForCreationDto company) 
	{ 
		if (company is null) 
			return BadRequest("CompanyForCreationDto object is null"); 
		var createdCompany = service.CompanyService.CreateCompany(company); 
		return CreatedAtRoute("CompanyById", new { companyId = createdCompany.Id }, createdCompany); 
	}

    [HttpGet("collection/({companyIds})", Name = "CompanyCollection")]
    public IActionResult GetCompanyCollection([ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<Guid> companyIds)
    { 
		var companies = service.CompanyService.GetByIds(companyIds, trackChanges: false); 
		return Ok(companies); 
	}

    [HttpPost("collection")] 
	public IActionResult CreateCompanyCollection([FromBody] IEnumerable<CompanyForCreationDto> companyCollection) 
	{ 
		var result = service.CompanyService.CreateCompanyCollection(companyCollection); 
		return CreatedAtRoute("CompanyCollection", new { result.companyIds }, result.companies); 
	}
}
