using Microsoft.Extensions.DependencyInjection;
using NBA.Importer.Business.Services;
using NBA.Importer.Business.Services.Interfaces;

namespace NBA.Importer.Business.Startup;

public static class StartupExtensions
{
    public static IServiceCollection AddNBAImporterBusiness(this IServiceCollection services)
        => services
            .AddScoped<ITextDataReader, TextDataReader>()
            .AddScoped<IBoxScores, BoxScores>();
}
