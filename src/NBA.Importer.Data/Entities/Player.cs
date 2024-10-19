namespace NBA.Importer.Data.Entities;

public class Player
{
    public int Id { get; set; }

    public int NBAId { get; set; }

    public string FirstName { get; set; } = default!;

    public string LastName { get; set; } = default!;
}
