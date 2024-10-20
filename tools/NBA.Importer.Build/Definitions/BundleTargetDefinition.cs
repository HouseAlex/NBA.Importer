using Bullseye;
using static SimpleExec.Command;

namespace NBA.Importer.Build.Definitions;

internal class BundleTargetDefinition : IBuildTargetDefinition
{
    public void Define(Targets targets)
    {
        targets.Add(
            BuildTarget.Bundle,
            "Generates the entity framework bundle for migrating the db context.",
            Targets.DependsOn(BuildTarget.BuildDotnet),
            action: async ()
                =>
            {
                Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "Build");

                var args = new[]
                {
                    "ef migrations bundle",
                    "--startup-project",
                    "--project ../NBA.Importer.Data",
                    "--output ../../artifacts/db/efbundle.exe",
                    "--configuration Release",
                    "--self-contained",
                    "--no-build",
                    "--force",
                };

                // The appsettings.json is needed in the same directory that the bundle is created in so the command must be ran in the scheduler.
                await RunAsync("dotnet", string.Join(' ', args), workingDirectory: "src/NBA.Importer.Scheduler")
                    .ConfigureAwait(false);
            });
    }
}
