namespace ApiVerse.Api.Models.EarthquakeModels
{
    public class ResultEarthquakeModel
    {
            public string status { get; set; }
            public Cache cache { get; set; }
            public int total_cached { get; set; }
            public int total_returned { get; set; }
            public List<EarthquakeEvent> events { get; set; }

            public class Cache
            {
                public string updated_at { get; set; }
                public bool is_stale { get; set; }
                public int refresh_interval_sec { get; set; }
            }

            public class EarthquakeEvent
            {
                public string event_id { get; set; }
                public PreferredData preferred_data { get; set; }
            }

            public class PreferredData
            {
                public float magnitude { get; set; }
                public float depth_km { get; set; }
                public Location location { get; set; }
                public string timestamp_utc { get; set; }
                public string timestamp_local { get; set; }
                public List<string> confirmed_by { get; set; }
                public int source_count { get; set; }
                public string relative_time { get; set; }
            }

            public class Location
            {
                public string city { get; set; }
                public string district { get; set; }
                public string description { get; set; }
                public float lat { get; set; }
                public float lon { get; set; }
            }
        }
    }
