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

public static class ServiceExtensions
{
    public static IServiceCollection ConfigureCors(this IServiceCollection services) => 
        services.AddCors(options => options.AddPolicy("CorsPolicy", builder =>
            builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));

    public static IServiceCollection ConfigureIISIntegration(this IServiceCollection services) => 
        services.Configure<IISOptions>(options => { });

    public static IServiceCollection ConfigureLoggerService(this IServiceCollection services) => 
        services.AddSingleton<ILoggerManager, LoggerManager>();

    public static IServiceCollection ConfigureRepositoryManager(this IServiceCollection services) => 
        services.AddScoped<IRepositoryManager, RepositoryManager>();

    public static IServiceCollection ConfigureServiceManager(this IServiceCollection services) =>
        services.AddScoped<IServiceManager, ServiceManager>();

    public static IServiceCollection ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration) => 
        services.AddDbContext<RepositoryContext>(options => 
            options.UseSqlServer(configuration.GetConnectionString("SqlConnection")));

    public static IMvcBuilder AddCustomCSVFormatter(this IMvcBuilder builder) => 
        builder.AddMvcOptions(config => 
            config.OutputFormatters.Add(new CsvOutputFormatter()));
}
