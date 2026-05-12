using System.Text.Json.Serialization;

namespace ApiVerse.UI.Models
{
    public class EqAiAnalysis
    {
        [JsonPropertyName("risk_level")] public string RiskLevel { get; set; } = "orta";
        [JsonPropertyName("durum_analizi")] public string DurumAnalizi { get; set; } = "";
        [JsonPropertyName("oneriler")] public List<string> Oneriler { get; set; } = new();
        [JsonPropertyName("acil_notlar")] public List<string> AcilNotlar { get; set; } = new();

        public static EqAiAnalysis Fallback() => new EqAiAnalysis
        {
            RiskLevel = "orta",
            DurumAnalizi = "Analiz şu an kullanılamıyor. Lütfen daha sonra tekrar deneyin.",
            Oneriler = new List<string> { "Güncel uyarıları takip edin.", "Acil çantanızı hazır tutun.", "Yetkili kaynaklardan bilgi alın." },
            AcilNotlar = new List<string>
        {
            "Sağlam bir masa veya kanepenin altına girin, başınızı koruyun.",
            "Pencerelerden ve devrilecek eşyalardan uzak durun.",
            "Sarsıntı geçene kadar içeride kalın, panikle dışarı çıkmayın.",
            "Sarsıntı bitince gaz, su ve elektriği kapatıp binayı kontrollü terk edin."
        }
        };
    }
}
