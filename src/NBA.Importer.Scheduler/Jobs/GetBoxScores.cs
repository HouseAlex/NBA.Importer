using Quartz;

namespace NBA.Importer.Scheduler.Jobs;

public class GetBoxScores : IJob
{
    public Task Execute(IJobExecutionContext context) // Make async ?
    {
        return Task.CompletedTask;
    }
}
