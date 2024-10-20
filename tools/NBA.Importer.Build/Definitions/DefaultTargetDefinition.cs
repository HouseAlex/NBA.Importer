using Bullseye;

namespace NBA.Importer.Build.Definitions;

internal class DefaultTargetDefinition : IBuildTargetDefinition
{
    public void Define(Targets targets)
        => targets.Add(
            BuildTarget.Default,
            "Executes the default build process.",
            Targets.DependsOn(BuildTarget.Test, BuildTarget.Bundle));  // Add BuildTarget.Export
}
