namespace ApiVerse.Api.Models.FootballModels
{
    public class FixtureApiResponse
    {
        public string Status { get; set; }
        public FixtureResponseData Response { get; set; }

    public class FixtureResponseData
    {
        public List<FixtureMatch> Matches { get; set; }
    }
    }
}
