namespace NBA.Importer.Scheduler.Options;

internal static class JobConstants
{
    // Jobs
    public const string GetBoxScores = "GetBoxScores";

    // Cron Expressions
    public const string Daily5AM = "0 0 5 ? * * *";
}
