namespace NBA.Importer.Scheduler.Extensions;

internal static class ConfigurationExtensions
{
    public static IConfigurationBuilder AddNBAImporterAppConfig(
        this IConfigurationBuilder builder)
    {
        return builder.AddJsonFile("appsettings.json", optional: true);
    }
}
