using Contracts;
using LoggerService;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repository;
using Repository.Contracts;
using Service;
using Service.Contracts;

namespace CompanyEmployees.Extensions;

/// <summary>
/// ServiceExtensions is a static class containing extension methods to simplify the configuration
/// of various services in the Startup class of the CompanyEmployees project.
/// </summary>
public static class ServiceExtensions
{
    /// <summary>
    /// Configures CORS with a permissive policy.
    /// </summary>
    public static IServiceCollection ConfigureCors(this IServiceCollection services) =>
        services.AddCors(options => options.AddPolicy("CorsPolicy", builder =>
            builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().WithExposedHeaders("X-Pagination")));

    /// <summary>
    /// Configures IIS integration options.
    /// </summary>
    public static IServiceCollection ConfigureIISIntegration(this IServiceCollection services) =>
        services.Configure<IISOptions>(options => { });

    /// <summary>
    /// Configures the LoggerManager as the implementation for the ILoggerManager interface.
    /// </summary>
    public static IServiceCollection ConfigureLoggerService(this IServiceCollection services) =>
        services.AddSingleton<ILoggerManager, LoggerManager>();

    /// <summary>
    /// Configures the RepositoryManager as the implementation for the IRepositoryManager interface.
    /// </summary>
    public static IServiceCollection ConfigureRepositoryManager(this IServiceCollection services) =>
        services.AddScoped<IRepositoryManager, RepositoryManager>();

    /// <summary>
    /// Configures the ServiceManager as the implementation for the IServiceManager interface.
    /// </summary>
    public static IServiceCollection ConfigureServiceManager(this IServiceCollection services) =>
        services.AddScoped<IServiceManager, ServiceManager>();

    /// <summary>
    /// Configures the SQL database context using the connection string from the IConfiguration object.
    /// </summary>
    public static IServiceCollection ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration) =>
        services.AddDbContext<RepositoryContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("SqlConnection")));

    /// <summary>
    /// Adds a custom CSV output formatter to the MVC options.
    /// </summary>
    public static IMvcBuilder AddCustomCSVFormatter(this IMvcBuilder builder) =>
        builder.AddMvcOptions(config =>
            config.OutputFormatters.Add(new CsvOutputFormatter()));
}
