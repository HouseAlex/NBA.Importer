namespace NBA.Importer.Build;

internal sealed record Linter(string Name, string Executable, string Arguments, string FixArguments)
{
    public Linter(string name, string executable, string arguments)
        : this(name, executable, arguments, arguments)
    {
    }

    public override string ToString() => Name;
}
