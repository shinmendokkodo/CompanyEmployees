using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Linq;

namespace CompanyEmployees;

/// <summary>
/// The JsonPatchInputFormatter class is a utility class that provides a method to obtain an instance of NewtonsoftJsonPatchInputFormatter.
/// </summary>
public static class JsonPatchInputFormatter
{
    /// <summary>
    /// Gets an instance of NewtonsoftJsonPatchInputFormatter.
    /// </summary>
    /// <returns>A NewtonsoftJsonPatchInputFormatter instance.</returns>
    public static NewtonsoftJsonPatchInputFormatter GetJsonPatchInputFormatter()
    {
        // Create a new ServiceCollection, add logging, Mvc, and NewtonsoftJson services, and build a ServiceProvider.
        var builder = new ServiceCollection()
            .AddLogging()
            .AddMvc()
            .AddNewtonsoftJson()
            .Services.BuildServiceProvider();

        // Get the MvcOptions from the ServiceProvider and retrieve the first NewtonsoftJsonPatchInputFormatter instance from the InputFormatters collection.
        return builder
            .GetRequiredService<IOptions<MvcOptions>>()
            .Value
            .InputFormatters
            .OfType<NewtonsoftJsonPatchInputFormatter>()
            .First();
    }
}
