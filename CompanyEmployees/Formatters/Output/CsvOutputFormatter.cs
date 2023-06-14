using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompanyEmployees.Formatters.Output;

/// <summary>
/// CsvOutputFormatter is a custom output formatter for converting CompanyDto objects to CSV format.
/// </summary>
public class CsvOutputFormatter : TextOutputFormatter
{
    public CsvOutputFormatter()
    {
        SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("text/csv"));
        SupportedEncodings.Add(Encoding.UTF8);
        SupportedEncodings.Add(Encoding.Unicode);
    }

    /// <summary>
    /// Determines if the formatter can write the specified type.
    /// </summary>
    /// <param name="type">The type to check.</param>
    /// <returns>True if the type is supported, otherwise false.</returns>
    protected override bool CanWriteType(Type type)
    {
        if (typeof(CompanyDto).IsAssignableFrom(type)
            || typeof(IEnumerable<CompanyDto>).IsAssignableFrom(type))
        {
            return base.CanWriteType(type);
        }

        return false;
    }

    /// <summary>
    /// Asynchronously writes the body of the response.
    /// </summary>
    /// <param name="context">The output formatter write context.</param>
    /// <param name="selectedEncoding">The selected encoding.</param>
    /// <returns>A Task that represents the asynchronous operation.</returns>
    public override async Task WriteResponseBodyAsync(OutputFormatterWriteContext context,
        Encoding selectedEncoding)
    {
        var response = context.HttpContext.Response;
        var buffer = new StringBuilder();

        if (context.Object is IEnumerable<CompanyDto> companies)
        {
            foreach (var company in companies)
            {
                FormatCsv(buffer, company);
            }
        }
        else
        {
            FormatCsv(buffer, (CompanyDto)context.Object);
        }

        await response.WriteAsync(buffer.ToString());
    }

    /// <summary>
    /// Formats the CompanyDto object as a CSV string and appends it to the provided StringBuilder.
    /// </summary>
    /// <param name="buffer">The StringBuilder to append the formatted CSV string to.</param>
    /// <param name="company">The CompanyDto object to format as CSV.</param>
    private static void FormatCsv(StringBuilder buffer, CompanyDto company)
    {
        buffer.AppendLine($"{company.Id},\"{company.Name},\"{company.FullAddress}\"");
    }
}
