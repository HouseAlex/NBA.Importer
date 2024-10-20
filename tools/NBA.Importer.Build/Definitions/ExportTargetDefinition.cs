using Bullseye;
using static SimpleExec.Command;

namespace NBA.Importer.Build.Definitions;

internal class ExportTargetDefinition : IBuildTargetDefinition
{
    public void Define(Targets targets)
        => targets.Add(
            BuildTarget.Export,
            "Exports compressed container images to a directory for release.",
            Targets.DependsOn(BuildTarget.Image),
            forEach: Constants.ExecutableProjects.Where(project => project.IsContainer),
            action: async project
                =>
            {
                var createDirectoryArgs = new[]
                {
                    "-Command New-Item",
                    "-ItemType Directory",
                    $"-Path {ArtifactPaths.ContainerImageCompressions}",
                    "-Force",
                    "| Out-Null",
                };

                await RunAsync("pwsh", string.Join(' ', createDirectoryArgs))
                    .ConfigureAwait(false);

                var commitId = await GitUtility.GetCommitId()
                    .ConfigureAwait(false);

                var imagePath = string.Format(ArtifactPaths.ContainerImageFormat, project.Name);
                await RunAsync(
                    Constants.VirtualizationPlatform ?? "docker",
                    $"save nbaimporter/{project.Name}:{commitId} --output {imagePath}")
                    .ConfigureAwait(false);

                var imageCompressionPath = string.Format(ArtifactPaths.ContainerImageCompressionFormat, project.Name);
                await RunAsync("tar", $"-csf {imageCompressionPath} {imagePath}")
                    .ConfigureAwait(false);
            });
}
