using ApiVerse.Api.Models.FootballModels;

namespace ApiVerse.UI.Models
{
    public class WeeklyFixturesViewModel
    {
        
            public List<FixtureMatch> LastWeek { get; set; }
            public List<FixtureMatch> ThisWeek { get; set; }
            public List<FixtureMatch> NextWeek { get; set; }
    }
}
