using ApiVerse.Api.Models.FootballModels;

namespace ApiVerse.Api.Abstract.FootballAbstracts
{
    public interface IFootballService
    {
        Task<List<FixtureMatch>> GetLastWeekMatchesAsync();
        Task<List<FixtureMatch>> GetThisWeekMatchesAsync();
        Task<List<FixtureMatch>> GetNextWeekMatchesAsync();
    }
}
