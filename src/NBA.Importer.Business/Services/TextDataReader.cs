using NBA.Importer.Business.Services.Interfaces;

namespace NBA.Importer.Business.Services;

public class TextDataReader : ITextDataReader
{
    public TextDataReader()
    {
    }

    public List<string> GetFileLines(string path) // Will eventually take in link to file.
    {
        List<string> lines = [];
        if (File.Exists(path))
        {
            lines = File.ReadAllLines(path).ToList();
        }

        return lines;
    }
}
