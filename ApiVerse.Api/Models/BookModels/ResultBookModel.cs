namespace ApiVerse.Api.Models.BookModels
{
    public class ResultBookModel
    {
            public string Kind { get; set; }
            public int TotalItems { get; set; }
            public List<BookItem> Items { get; set; }

        public class BookItem
        {
            public string Id { get; set; }
            public VolumeInfo VolumeInfo { get; set; }
        }

        public class VolumeInfo
        {
            public string Title { get; set; }
            public List<string> Authors { get; set; }
            public string Publisher { get; set; }
            public string PublishedDate { get; set; }
            public string Description { get; set; }
            public ImageLinks ImageLinks { get; set; }
            public string PreviewLink { get; set; }
        }

        public class ImageLinks
        {
            public string SmallThumbnail { get; set; }
            public string Thumbnail { get; set; }
        }
    }
}
