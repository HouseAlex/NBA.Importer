using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using NBA.Importer.Build.Definitions;

var services = new ServiceCollection();

var targetDefinitionServiceType = typeof(IBuildTargetDefinition);
var targetDefinitionImplementationTypes = Assembly.GetExecutingAssembly()
    .GetTypes()
    .Where(t => t.GetInterfaces()
        .Contains(targetDefinitionServiceType))
    .Where(t => t.IsClass)
    .Where(t => !t.IsAbstract)
    .ToArray();

foreach (var implementationType in targetDefinitionImplementationTypes)
{
    services.AddScoped(targetDefinitionServiceType, implementationType);
}

var serviceProvider = services.BuildServiceProvider();

var targets = new Bullseye.Targets();
foreach (var targetDefinition in serviceProvider.GetServices<IBuildTargetDefinition>())
{
    targetDefinition.Define(targets);
}

await targets.RunAndExitAsync(args, messageOnly: ex => ex is SimpleExec.ExitCodeException)
    .ConfigureAwait(false);
