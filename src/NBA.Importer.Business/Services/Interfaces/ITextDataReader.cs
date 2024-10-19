namespace NBA.Importer.Business.Services.Interfaces;

public interface ITextDataReader
{
    /// <summary>
    /// Reads a file.
    /// </summary>
    /// <param name="path">The path to the file.</param>
    /// <returns>An array of lines.</returns>
    List<string> GetFileLines(string path);
}
