using NBA.Importer.Business.Services.Interfaces;

namespace NBA.Importer.Business.Services;

public class BoxScores : IBoxScores
{
    private readonly ITextDataReader textDataReader;

    public BoxScores(ITextDataReader textDataReader)
    {
        this.textDataReader = textDataReader;
    }

    public void GetDataRaw()
    {
        var tempFilePath = "C:\\Users\\Alex\\Desktop\\Code\\NBA.Importer\\resources\\sample.txt";
        var boxScoreLines = textDataReader.GetFileLines(tempFilePath);

        if (boxScoreLines != null)
        {
            var headersIndex = boxScoreLines.FindIndex(x =>  x.StartsWith("date", StringComparison.InvariantCultureIgnoreCase)) + 1;
            var boxScoreData = boxScoreLines.Slice(headersIndex, boxScoreLines.Count - headersIndex);
        }

    }
}
