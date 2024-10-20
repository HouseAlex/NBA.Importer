using Bullseye;
using static SimpleExec.Command;

namespace NBA.Importer.Build.Definitions;
internal class PublishTargetDefinition : IBuildTargetDefinition
{
    public void Define(Targets targets)
        => targets.Add(
            BuildTarget.Publish,
            "Published application executables to a directory for release.",
            Targets.DependsOn(BuildTarget.BuildDotnet),
            forEach: Constants.ExecutableProjects,
            action: async project
                =>
            {
                var executablePath = string.Format(ArtifactPaths.PublishedExecutableFormat, project);
                var args = new[]
                {
                    "publish",
                    project.Path,
                    $"--output {executablePath}",
                    "--configuration Release",
                    "--no-build",
                    "--nologo",
                };

                await RunAsync("dotnet", string.Join(' ', args))
                    .ConfigureAwait(false);
            });
}
