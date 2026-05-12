namespace ApiVerse.Api.Models.FootballModels
{
    public class FixtureMatch
    {
        public string Id { get; set; }
        public FixtureTeam Home { get; set; }
        public FixtureTeam Away { get; set; }
        public FixtureStatus Status { get; set; }
        public bool NotStarted { get; set; }
        public DateTime MatchDate => DateTime.Parse(Status?.UtcTime ?? DateTime.MinValue.ToString());
    }
}
