using NBA.Importer.Scheduler.Extensions;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddQuartzScheduler(builder.Configuration);

var host = builder.Build();
host.Run();
