namespace ApiVerse.Api.Models.FootballModels
{
    public class FixtureStatus
    {
        public string UtcTime { get; set; }
        public bool Finished { get; set; }
        public bool Started { get; set; }
        public bool Cancelled { get; set; }
        public string ScoreStr { get; set; }
        public FixtureReason Reason { get; set; }

        public class FixtureReason
        {
            public string Short { get; set; }
            public string Long { get; set; }
        }
    }
}
