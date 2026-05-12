using ApiVerse.Api.Abstract.FootballAbstracts;
using ApiVerse.Api.Models.FootballModels;
using System.Text.Json;

public class FootballService : IFootballService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IConfiguration _configuration;

    public FootballService(IHttpClientFactory httpClientFactory, IConfiguration configuration)
    {
        _httpClientFactory = httpClientFactory;
        _configuration = configuration;
    }

    private async Task<List<FixtureMatch>> GetAllMatchesAsync()
    {
        var client = _httpClientFactory.CreateClient("FootballClient");
        var leagueId = _configuration["FootballApi:SuperLigId"];

        var response = await client.GetAsync($"/football-get-all-matches-by-league?leagueid={leagueId}");
        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        var result = JsonSerializer.Deserialize<FixtureApiResponse>(json, options);

        return result?.Response?.Matches ?? new List<FixtureMatch>();
    }

    private DateTime ParseDate(string utcTime) =>
    DateTime.Parse(utcTime, null, System.Globalization.DateTimeStyles.RoundtripKind);

    private DateTime GetStartOfWeek(DateTime date)
    {
        var diff = (7 + (date.DayOfWeek - DayOfWeek.Friday)) % 7;
        return date.AddDays(-diff).Date;
    }

    public async Task<List<FixtureMatch>> GetLastWeekMatchesAsync()
    {
        var matches = await GetAllMatchesAsync();
        var startOfThisWeek = GetStartOfWeek(DateTime.UtcNow.Date);
        var startOfLastWeek = startOfThisWeek.AddDays(-7);
        var endOfLastWeek = startOfLastWeek.AddDays(4); // Pazartesi dahil (Cuma+4=Pazartesi)

        return matches
            .Where(m => m.Status?.UtcTime != null)
            .Where(m => ParseDate(m.Status.UtcTime).Date >= startOfLastWeek &&
                        ParseDate(m.Status.UtcTime).Date <= endOfLastWeek)
            .OrderBy(m => ParseDate(m.Status.UtcTime))
            .ToList();
    }

    public async Task<List<FixtureMatch>> GetThisWeekMatchesAsync()
    {
        var matches = await GetAllMatchesAsync();
        var startOfThisWeek = GetStartOfWeek(DateTime.UtcNow.Date);
        var endOfThisWeek = startOfThisWeek.AddDays(4); // Pazartesi dahil

        return matches
            .Where(m => m.Status?.UtcTime != null)
            .Where(m => ParseDate(m.Status.UtcTime).Date >= startOfThisWeek &&
                        ParseDate(m.Status.UtcTime).Date <= endOfThisWeek)
            .OrderBy(m => ParseDate(m.Status.UtcTime))
            .ToList();
    }

    public async Task<List<FixtureMatch>> GetNextWeekMatchesAsync()
    {
        var matches = await GetAllMatchesAsync();
        var startOfNextWeek = GetStartOfWeek(DateTime.UtcNow.Date).AddDays(7);
        var endOfNextWeek = startOfNextWeek.AddDays(4); // Pazartesi dahil

        return matches
            .Where(m => m.Status?.UtcTime != null)
            .Where(m => ParseDate(m.Status.UtcTime).Date >= startOfNextWeek &&
                        ParseDate(m.Status.UtcTime).Date <= endOfNextWeek)
            .OrderBy(m => ParseDate(m.Status.UtcTime))
            .ToList();
    }
}