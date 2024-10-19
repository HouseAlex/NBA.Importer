namespace NBA.Importer.Data.Entities
{
    public class BoxScore
    {
        public int Id { get; set; }

        public int PlayerId { get; set; }

        public int TeamId { get; set; }

        public int OpponentTeamId { get; set; }

        public string Position { get; set; } = default!;

        public int MinutesPlayed { get; set; }

        public int FieldGoalsMade { get; set; }

        public int FieldGoalsAttempted { get; set; }

        public int ThreePointFieldGoalsMade { get; set; }

        public int ThreePointFieldGoalsAttempted { get; set; }

        public int FreeThrowsMade { get; set; }

        public int FreeThrowsAttempted { get; set; }

        public int OffensiveRebounds { get; set; }

        public int DefensiveRebounds { get; set; }

        public int TotalRebounds { get; set; }

        public int Assists {  get; set; }

        public int PersonalFouls { get; set; }

        public bool Disqualification { get; set; }

        public int Steals { get; set; }

        public int Turnovers { get; set; }

        public int Blocks { get; set; }

        public int Points { get; set; }

        public DateOnly GameDate { get; set; }
    }
}
