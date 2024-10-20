using static SimpleExec.Command;

namespace NBA.Importer.Build;

internal sealed record DotnetTestProject(string Name, string Path)
    : TestProject(Name, Path)
{
    public override async Task Execute()
    {
        var args = new[]
        {
            "test",
            Path,
            "--configuration Release",
            "--collect \"XPlat Code Coverage\"",
            "--logger trx",
            $"--results-directory {ArtifactPaths.TestResultsDotnet}",
            "--no-build",
            "--nologo",
        };
        await RunAsync("dotnet", string.Join(' ', args))
            .ConfigureAwait(false);
    }
}
