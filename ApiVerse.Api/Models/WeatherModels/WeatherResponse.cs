namespace ApiVerse.Api.Models.WeatherModels
{
    public class WeatherResponse
    {
        public List[] list { get; set; } // Tahmin listesi
        public City city { get; set; }
        public string AIRecommendations { get; set; }


        public class City
        {
            public string name { get; set; } // Şehir Adı
            public string country { get; set; } // Ülke Kodu (TR, US vb.)
        }

        public class List
        {
            public Main main { get; set; }
            public Weather[] weather { get; set; }
            public Wind wind { get; set; } // Rüzgar hızı şık durur
            public string dt_txt { get; set; } // Tarih/Saat bilgisi
        }

        public class Main
        {
            public float temprature { get; set; } // Ana Sıcaklık
            public float temprature_feels_like { get; set; } // Hissedilen
            public int humidity { get; set; } // Nem
        }

        public class Weather
        {
            public string description { get; set; } // "Güneşli", "Hafif Yağmurlu"
            public string icon { get; set; } // İkon kodu (01d, 02n vb.)
            public string main { get; set; } // İkon kodu (01d, 02n vb.)
        }

        public class Wind
        {
            public float speed { get; set; } // Rüzgar hızı
        }
    }
}