using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NBA.Importer.Business.Services;
using NBA.Importer.Business.Services.Interfaces;
using NBA.Importer.Data;

namespace NBA.Importer.Business.Startup;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddNBAImporterBusiness(this IServiceCollection services)
        => services
            .AddScoped<ITextDataReader, TextDataReader>()
            .AddScoped<IBoxScores, BoxScores>();

    public static IServiceCollection AddNBAImporterDatabase(this IServiceCollection services, IConfiguration config)
        => services
            .AddDbContext<ImporterDbContext>(options => options
                .UseSqlServer(connectionString: config.GetConnectionString(nameof(ImporterDbContext))));
}
