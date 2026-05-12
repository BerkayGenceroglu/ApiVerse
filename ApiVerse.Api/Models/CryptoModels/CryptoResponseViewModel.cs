namespace ApiVerse.Api.Models.CryptoModels
{
    public class CryptoResponseViewModel
    {
        public List<CryptoResult> Results { get; set; }

        public class CryptoResult
        {
            public int Rank { get; set; }
            public string Symbol { get; set; }
            public string Name { get; set; }
            public string Slug { get; set; }
            public string Id { get; set; }
            public double Price { get; set; }
            public string Image { get; set; }
            public double MarketCap { get; set; }
            public double Change24hPercent { get; set; }
        }
    }
}
