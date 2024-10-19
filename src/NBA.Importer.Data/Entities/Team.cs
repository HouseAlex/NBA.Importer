namespace NBA.Importer.Data.Entities;

public class Team
{
    public int Id { get; set; }
    
    public string Name { get; set; } = default!;

    public string Abbreviation { get; set; } = default!;
}
