using ApiVerse.Api.Models.JobModes;

namespace ApiVerse.Api.Abstract.JobAbstracts
{
    public interface IJobService
    {
        Task<List<ResultJobModel>> SearchJobsAsync(string pozisyon, string sehir);
    }
}
