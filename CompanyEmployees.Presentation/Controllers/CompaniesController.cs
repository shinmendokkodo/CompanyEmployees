using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using System;

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

    [HttpGet("{companyId:guid}")] 
	public IActionResult GetCompany(Guid companyId) 
	{ 
		var company = service.CompanyService.GetCompany(companyId, trackChanges: false); 
		return Ok(company); 
	}
}
