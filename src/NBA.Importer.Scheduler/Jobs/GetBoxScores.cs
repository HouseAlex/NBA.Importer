using NBA.Importer.Business.Services.Interfaces;
using Quartz;

namespace NBA.Importer.Scheduler.Jobs;

public class GetBoxScores : IJob
{
    private readonly IBoxScores boxScores;

    public GetBoxScores(IBoxScores boxScores)
    {
        this.boxScores = boxScores;
    }

    public Task Execute(IJobExecutionContext context) // Make async ?
    {
        boxScores.Get();
        return Task.CompletedTask;
    }
}
