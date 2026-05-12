namespace ApiVerse.UI.Models
{
    public class EarthquakeSearchViewModel
    {
        public DateTime StartDate { get; set; } = DateTime.Now.AddDays(-1);
        public DateTime EndDate { get; set; } = DateTime.Now;
    }
}
