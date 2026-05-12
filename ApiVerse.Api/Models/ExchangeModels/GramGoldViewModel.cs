namespace ApiVerse.Api.Models.ExchangeModels
{
    public class GramGoldViewModel
    {
        public Datum[] data { get; set; }
        public class Datum
        {
            public string key { get; set; }
            public string buy { get; set; }
            public string sell { get; set; }
            public string percent { get; set; }
            public string arrow { get; set; }
            public string last_update { get; set; }
        }

    }
}
