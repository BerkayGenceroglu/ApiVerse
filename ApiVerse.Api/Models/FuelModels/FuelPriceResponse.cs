namespace ApiVerse.Api.Models.FuelModels
{
    public class FuelPriceResponse
    {
        public bool Success { get; set; }
        public List<FuelPrice> Result { get; set; }

        public class FuelPrice
        {
            public string Country { get; set; }
            public string Currency { get; set; }
            public string Gasoline { get; set; }  // Benzin
            public string Diesel { get; set; }    // Motorin
            public string Lpg { get; set; }       // LPG
        }

    }
}
