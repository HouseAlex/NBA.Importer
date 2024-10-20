namespace NBA.Importer.Build;

internal abstract record TestProject(string Name, string Path)
{
    public abstract Task Execute();
}
