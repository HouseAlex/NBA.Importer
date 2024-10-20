using static SimpleExec.Command;

namespace NBA.Importer.Build;

internal static class GitUtility
{
    public static async Task<string> GetCommitId()
    {
        var (id, _) = await ReadAsync("git", "rev-parse HEAD")
            .ConfigureAwait(false);

        return id.Replace("\n", string.Empty, StringComparison.OrdinalIgnoreCase);
    }
}
