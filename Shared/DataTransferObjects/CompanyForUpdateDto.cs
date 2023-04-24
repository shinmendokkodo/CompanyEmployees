using System.Collections.Generic;

namespace Shared.DataTransferObjects;

public record CompanyForUpdateDto : CompanyForManipulationDto
{
	public IEnumerable<EmployeeForCreationDto> Employees { get; init; }
}
