using Bullseye;
using static SimpleExec.Command;

namespace NBA.Importer.Build.Definitions;
internal class ImageTargetDefinition : IBuildTargetDefinition
{
    public void Define(Targets targets)
        => targets.Add(
            BuildTarget.Image,
            "Builds container images for executable projects.",
            Targets.DependsOn(BuildTarget.Publish),
            forEach: Constants.ExecutableProjects.Where(project => project.IsContainer),
            action: async project
                =>
            {
                var commitId = await GitUtility.GetCommitId()
                    .ConfigureAwait(false);

                var execitablePath = string.Format(ArtifactPaths.PublishedExecutableFormat, project.Name);
                var args = new[]
                {
                    "build",
                    $"--file {project.Path}{Path.AltDirectorySeparatorChar}Dockerfile",
                    $"--tag nbaimporter/{project.Name}:{commitId}",
                    $"./{execitablePath}",
                };

                await RunAsync(
                    Constants.VirtualizationPlatform ?? "docker",
                    string.Join(' ', args))
                    .ConfigureAwait(false);
            });
}
