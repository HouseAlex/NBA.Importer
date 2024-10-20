using Bullseye;

namespace NBA.Importer.Build.Definitions;

/// <summary>
/// Represents the execution definition of a build target.
/// </summary>
internal interface IBuildTargetDefinition
{
    /// <summary>
    /// Defines the build target into a collection.
    /// </summary>
    /// <param name="targets">The executable collection of build targets to modify.</param>
    void Define(Targets targets);
}
