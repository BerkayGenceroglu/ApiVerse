namespace ApiVerse.Api.Models.ExchangeModels
{
    public class CurrencyApiResponse
    {
        public Rates rates { get; set; }
        public Time_Update time_update { get; set; }

        public class Rates
        {
            public decimal EUR { get; set; }
            public decimal USD { get; set; }
        
        }
        public class Time_Update
        {
            public int time_unix { get; set; }
            public DateTime time_utc { get; set; }
            public string time_zone { get; set; }
        }

    }
}
