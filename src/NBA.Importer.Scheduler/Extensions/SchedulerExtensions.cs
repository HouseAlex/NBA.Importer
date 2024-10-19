using NBA.Importer.Scheduler.Jobs;
using NBA.Importer.Scheduler.Options;
using Quartz;
using Quartz.AspNetCore;

namespace NBA.Importer.Scheduler.Extensions;

public static class SchedulerExtensions
{
    internal static void AddQuartzScheduler(this IServiceCollection services, IConfiguration config)
        => services
            .AddQuartz(q =>
            {
                q.Job<GetBoxScores>(JobConstants.GetBoxScores, JobConstants.Daily5AM);
            })
            .AddQuartzServer(options =>
            {
                options.WaitForJobsToComplete = true;
            });

    internal static void Job<T>(this IServiceCollectionQuartzConfigurator quartz, string name, string cronExpression)
        where T : class, IJob
    {
        var jobKey = new JobKey(name);
        quartz.AddJob<T>(options => options.WithIdentity(jobKey));

        //Cron trigger
        quartz.AddTrigger(options => options
            .ForJob(jobKey)
            .WithIdentity($"{name}-trigger")
            .WithCronSchedule(cronExpression)); // Is this UTC ?

        // Startup trigger
        quartz.AddTrigger(options => options
            .ForJob(jobKey)
            .WithIdentity($"{name}-trigger-startup")
            .WithSchedule(SimpleScheduleBuilder.RepeatSecondlyForTotalCount(1)));



    }
}
