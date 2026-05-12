namespace ApiVerse.Api.Models.SocialMediaModels
{
    public class YoutubeVideoModel
    {
        public Item[] items { get; set; }

        public class Item
        {
            public string id { get; set; }
            public Snippet snippet { get; set; }
        }

        public class Snippet
        {
            public DateTime publishedAt { get; set; }
            public string channelId { get; set; }
            public string title { get; set; }
            public Thumbnails thumbnails { get; set; }
            public string channelTitle { get; set; }
        }

        public class Thumbnails
        {
            public High high { get; set; }
        }

        public class High
        {
            public string url { get; set; }
        }
    }
}