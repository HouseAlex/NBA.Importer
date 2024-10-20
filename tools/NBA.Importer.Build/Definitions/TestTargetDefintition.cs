using Bullseye;

namespace NBA.Importer.Build.Definitions;
internal class TestTargetDefintition : IBuildTargetDefinition
{
    private static readonly TestSuite[] TestSuites =
    {
        new(
            BuildTarget.TestUnit,
            "Tests isolated parts of a single subsystem.",
            new TestProject[]
            {
                ////new DotnetTestProject("business", "tests/NBA.Importer.Business.Facts") // Add back when unit tests are added.
            })
    };

    public void Define(Targets targets)
    {
        foreach (var testSuite in TestSuites)
        {
            targets.Add(
                testSuite.Name,
                testSuite.Description,
                Targets.DependsOn(BuildTarget.BuildDotnet),
                forEach: testSuite.Projects,
                action: async project => await project.Execute()
                    .ConfigureAwait(false));
        }

        targets.Add(
            BuildTarget.Test,
            "Tests all configured suites.",
            Targets.DependsOn(TestSuites.Select(testSuite => testSuite.Name)
                .ToArray()));
    }
}
