using CompanyEmployees.Presentation.ActionFilters;
using CompanyEmployees.Presentation.ModelBinders;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CompanyEmployees.Presentation.Controllers;

[Route("api/companies")]
[ApiController]
public class CompaniesController : ControllerBase
{
    private readonly IServiceManager serviceManager;

    public CompaniesController(IServiceManager service) => this.serviceManager = service;

    [HttpGet]
    public async Task<IActionResult> GetCompaniesAsync()
    {
        var companies = await serviceManager.CompanyService.GetAllCompaniesAsync(trackChanges: false);
        return Ok(companies);
    }

    [HttpGet("{companyId:guid}", Name = "CompanyById")]
    public async Task<IActionResult> GetCompanyAsync(Guid companyId)
    {
        var company = await serviceManager.CompanyService.GetCompanyAsync(companyId, trackChanges: false);
        return Ok(company);
    }

    [HttpPost]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> CreateCompanyAsync([FromBody] CompanyForCreationDto company)
    {
        var createdCompany = await serviceManager.CompanyService.CreateCompanyAsync(company);
        return CreatedAtRoute("CompanyById", new { companyId = createdCompany.Id }, createdCompany);
    }

    [HttpGet("collection/({companyIds})", Name = "CompanyCollection")]
    public async Task<IActionResult> GetCompanyCollectionAsync([ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<Guid> companyIds)
    {
        var companies = await serviceManager.CompanyService.GetByIdsAsync(companyIds, trackChanges: false);
        return Ok(companies);
    }

    [HttpPost("collection")]
    public async Task<IActionResult> CreateCompanyCollectionAsync([FromBody] IEnumerable<CompanyForCreationDto> companyCollection)
    {
        var (companies, companyIds) = await serviceManager.CompanyService.CreateCompanyCollectionAsync(companyCollection);
        return CreatedAtRoute("CompanyCollection", new { companyIds }, companies);
    }

    [HttpDelete("{companyId:guid}")]
    public async Task<IActionResult> DeleteCompanyAsync(Guid companyId)
    {
        await serviceManager.CompanyService.DeleteCompanyAsync(companyId, trackChanges: false);
        return NoContent();
    }

    [HttpPut("{companyId:guid}")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> UpdateCompany(Guid companyId, [FromBody] CompanyForUpdateDto company)
    {
        await serviceManager.CompanyService.UpdateCompanyAsync(companyId, company, trackChanges: true);
        return NoContent();
    }
}
