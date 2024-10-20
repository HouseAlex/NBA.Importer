using Bullseye;
using static SimpleExec.Command;

namespace NBA.Importer.Build.Definitions;

internal class LintTargetDefinition : IBuildTargetDefinition
{
    private static readonly Linter[] RootLinters =
        [
            new("markdown", "markdownlint", "."),
            new("prettier", "prettier", "--check .", "--write ."),
            new("yaml", "yamllint", "--string ."),
        ];

    public void Define(Targets targets)
    {
        targets.Add(
            BuildTarget.LintRoot,
            "Performs static code analysis scope to the repository root.",
            forEach: RootLinters,
            action: async linter
                => await RunAsync(linter.Executable, Constants.FixLinterIssues ? linter.FixArguments : linter.Arguments)
                    .ConfigureAwait(false));

        targets.Add(
            BuildTarget.Lint,
            "Perform static code analysis for all configured scopes.",
            Targets.DependsOn(BuildTarget.LintRoot));
    }
}
