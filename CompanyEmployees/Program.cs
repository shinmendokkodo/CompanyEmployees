using CompanyEmployees.Extensions;
using Contracts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NLog;
using System.IO;

namespace CompanyEmployees;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));

        // Add services to the container.
        
        // Configure Cors
        builder.Services.ConfigureCors();
        
        // Configure IIS
        builder.Services.ConfigureIISIntegration();

        // Configure Logging
        builder.Services.ConfigureLoggerService();
        
        // Configure Repositories
        builder.Services.ConfigureRepositoryManager();

        // Configure Services
        builder.Services.ConfigureServiceManager();

        // Configure DB Context
        builder.Services.ConfigureSqlContext(builder.Configuration);

        builder.Services.Configure<ApiBehaviorOptions>(options => options.SuppressModelStateInvalidFilter = true);

        builder.Services.AddControllers(config =>
        {
            config.RespectBrowserAcceptHeader = true;
            config.ReturnHttpNotAcceptable = true;
        })
        .AddXmlDataContractSerializerFormatters()
        .AddCustomCSVFormatter()
        .AddApplicationPart(typeof(Presentation.AssemblyReference).Assembly);
        
        // AutoMapper
        builder.Services.AddAutoMapper(typeof(Program));

        var app = builder.Build();

        var logger = app.Services.GetRequiredService<ILoggerManager>();

        app.ConfigureExceptionHandler(logger);

        if (app.Environment.IsProduction())
        {
            app.UseHsts();
        }

        // Configure the HTTP request pipeline.

        app.UseHttpsRedirection();

        app.UseStaticFiles();

        app.UseForwardedHeaders(new ForwardedHeadersOptions
        {
            ForwardedHeaders = ForwardedHeaders.All
        });

        app.UseCors("CorsPolicy");

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}