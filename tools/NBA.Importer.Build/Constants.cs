namespace NBA.Importer.Build;

internal static class Constants
{
    public static readonly string? VirtualizationPlatform = Environment.GetEnvironmentVariable("NBA_VIRTUALIZATION_PLATFORM");
    public static readonly bool FixLinterIssues = Environment.GetEnvironmentVariable("LINT_FIX") == "1";
    public static readonly IEnumerable<ExecutableProject> ExecutableProjects =
        [
            new("api", "src/NBA.Importer.Api", IsContainer: false), // false temporarily till containerization is setup
            new("scheduler", "src/NBA.Importer.Scheduler", IsContainer: false), // false temporarily till containerization is setup
        ];
}
