namespace ApiVerse.Api.Models.MovieModels
{
    public class ResultMovieDto
    {
        public Item[] items { get; set; }

        public class Item
        {
            public string title { get; set; }
            public string release_date { get; set; }
            public string original_language { get; set; }
            public float popularity { get; set; }
            public string overview { get; set; }
            public float vote_average { get; set; }
        }

    }
}
