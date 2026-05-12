using ApiVerse.Api.Abstract.JobAbstracts;
using ApiVerse.Api.Models.JobModes;

namespace ApiVerse.Api.Services.JobService
{
    public class JobService : IJobService
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;

        public JobService(IConfiguration configuration, HttpClient httpClient)
        {
            _configuration = configuration;
            _httpClient = httpClient;
        }

        public Task<List<ResultJobModel>> SearchJobsAsync(string pozisyon, string sehir)
        {
            throw new NotImplementedException();
        }
    }
}
