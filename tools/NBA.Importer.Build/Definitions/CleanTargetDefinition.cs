using Bullseye;
using static SimpleExec.Command;

namespace NBA.Importer.Build.Definitions;
internal class CleanTargetDefinition : IBuildTargetDefinition
{
    public void Define(Targets targets)
        => targets.Add(
            BuildTarget.Clean,
            "Removes leftover build artifacts from previous executions.",
            async ()
                =>
            {
                await RunAsync("dotnet", "clean --configuration Release --verbosity minimal --nologo")
                    .ConfigureAwait(false);
            });
}
