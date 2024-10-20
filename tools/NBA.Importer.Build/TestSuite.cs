namespace NBA.Importer.Build;

internal sealed record TestSuite(string Name, string Description, IEnumerable<TestProject> Projects)
{
    public override string ToString() => Name;
}
