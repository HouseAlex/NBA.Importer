namespace NBA.Importer.Build;

internal sealed record ExecutableProject(string Name, string Path, bool IsContainer)
{
    public override string ToString() => Name;
}
