using Bullseye;
using static SimpleExec.Command;

namespace NBA.Importer.Build.Definitions;
internal class BuildDotnetTargetDefinition : IBuildTargetDefinition
{
    public void Define(Targets targets)
        => targets.Add(
            BuildTarget.BuildDotnet,
            "Builds the .NET solution into a set of binaries.",
            Targets.DependsOn(BuildTarget.Clean),
            async ()
                =>
            {
                await RunAsync("dotnet", "build --configuration Release --verbosity minimal --nologo /warnaserror")
                    .ConfigureAwait(false);
            });
}
