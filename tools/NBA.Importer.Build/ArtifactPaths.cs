namespace NBA.Importer.Build;

internal static class ArtifactPaths
{
    public const string Root = "artifacts";

    public const string EntityFrameworkBundle = $"{Root}/efbundle.exe";

    public const string ContainerImages = $"{Root}/images";
    public const string ContainerImageFormat = $"{ContainerImages}/{{0}}.tar";
    public const string ContainerImageCompressions = $"{ContainerImages}/zip";
    public const string ContainerImageCompressionFormat = $"{ContainerImageCompressions}/{{0}}.tar.gz";

    public const string PublishedExecutables = $"{Root}/publish";
    public const string PublishedExecutableFormat = $"{PublishedExecutables}/{{0}}";

    public const string TestResults = $"{Root}/test-results";
    public const string TestResultsDotnet = $"{TestResults}/dotnet";
}
