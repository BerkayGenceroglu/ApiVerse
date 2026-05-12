namespace ApiVerse.Api.Models.SocialMediaModels
{
    public class RedditPostModel
    {
        public bool success { get; set; }
        public Data data { get; set; }

        public class Data
        {
            public string cursor { get; set; }
            public PostWrapper[] posts { get; set; }
        }

        public class PostWrapper
        {
            public PostData data { get; set; }
            public string kind { get; set; }
        }

        public class PostData
        {
            public string id { get; set; }
            public string author { get; set; }
            public string title { get; set; }
            public string subreddit { get; set; }
            public string subreddit_name_prefixed { get; set; }
            public string permalink { get; set; }
            public string url { get; set; }
            public string thumbnail { get; set; }

            // Sadece küçük harfli olanları bırakıyoruz, 
            // JsonSerializerOptions.PropertyNameCaseInsensitive = true 
            // olduğu için bunlar hem "score" hem "Score" olarak eşleşebilir.
            public int score { get; set; }
            public int ups { get; set; }
            public int num_comments { get; set; }

            public double created_utc { get; set; }
            public bool is_video { get; set; }
            public string selftext { get; set; }

            // BURADAKİ BÜYÜK HARFLİ Score ve Num_Comments MÜLKİYETLERİNİ SİLDİK.
        }
    }
}