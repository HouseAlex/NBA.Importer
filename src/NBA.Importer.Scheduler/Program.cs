using NBA.Importer.Business.Startup;
using NBA.Importer.Scheduler.Extensions;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddNBAImporterBusiness();
builder.Services.AddQuartzScheduler(builder.Configuration);

var host = builder.Build();
host.Run();
