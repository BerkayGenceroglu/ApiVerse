using ApiVerse.Api.Models.CryptoModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json;

namespace ApiVerse.UI.Controllers
{
    [Authorize]
    public class CryptoController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public CryptoController(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }

        public async Task<IActionResult> CryptoStatisticPage()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7239/api/Crypto/crypto");

            if (response.IsSuccessStatusCode)
            {
                var jsonstring = await response.Content.ReadAsStringAsync();
                var cryptoData = System.Text.Json.JsonSerializer.Deserialize<List<CryptoResponseViewModel.CryptoResult>>(jsonstring, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                var aiComment = await GetAiCryptoAnalysis(cryptoData);
                ViewBag.AiComment = aiComment;

                return View(cryptoData);
            }

            return View();
        }

        private async Task<string> GetAiCryptoAnalysis(List<CryptoResponseViewModel.CryptoResult> model)
        {
            var apiKey = _configuration["OpenAIApiKey:Key"];
            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");

            var topCoins = string.Join("\n", model.Take(5).Select(c =>
                $"- {c.Name} ({c.Symbol}): {c.Price:N2} ₺"));

            var prompt = $@"
                    Rolün: Deneyimli bir finans analisti ve kripto para piyasası yorumcususun.

                    Aşağıda verilen kripto para piyasası verilerini analiz et:

                     TOP 5 KRİPTO (TRY):
                    {topCoins}

                     GÖREV:
                    Aşağıdaki başlıklar altında, profesyonel ve dengeli bir piyasa değerlendirmesi yaz.
                    Her bölüm en az 2 cümle içermeli ve analitik bir dil kullanılmalıdır.

                    ÇIKTI FORMATI:
                    SADECE aşağıdaki HTML yapısını üret. Bunun dışında hiçbir açıklama, markdown veya ekstra metin ekleme.

                    <section>
                      <h6> Piyasanın Genel Seyri</h6>
                      <p>[Analiz metni]</p>
                    </section>
                    <section>
                      <h6>Bitcoin'in Piyasaya Etkisi</h6>
                      <p>[Analiz metni]</p>
                    </section>
                    <section>
                      <h6> TRY / Döviz Kuru İlişkisi</h6>
                      <p>[Analiz metni]</p>
                    </section>
                    <section>
                      <h6> Kısa Vadeli Beklenti</h6>
                      <p>[Analiz metni]</p>
                    </section>
                    <section>
                      <h6> Sorumluluk Reddi</h6>
                      <p>Bu içerik yalnızca bilgilendirme amaçlıdır ve yatırım tavsiyesi değildir.</p>
                    </section>

                    ⚠️ KURALLAR:
                    - Kesinlik içeren ifadeler kullanma (örneğin: “kesin yükselir”, “garanti düşer”).
                    - Tahminlerini olasılık ve senaryo bazlı ifade et.
                    - Profesyonel, tarafsız ve analitik bir dil kullan.
                    - Gereksiz tekrar ve yüzeysel yorumlardan kaçın.
                    - Veriye dayalı çıkarımlar yap, genellemeden uzak dur.
                    - HTML yapısı dışına çıkma. Tek bir karakter bile ekleme.
                    ";

            var requestBody = new
            {
                model = "gpt-4o",
                messages = new[] { new { role = "user", content = prompt } },
                temperature = 0.7
            };

            var response = await client.PostAsJsonAsync("https://api.openai.com/v1/chat/completions", requestBody);
            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                dynamic result = JsonConvert.DeserializeObject(jsonResponse);
                string content = result.choices[0].message.content;

                // GPT bazen ```html ... ``` sarmalıyor, temizle
                content = System.Text.RegularExpressions.Regex.Replace(
                    content,
                    @"```(?:html)?\s*|\s*```",
                    string.Empty,
                    System.Text.RegularExpressions.RegexOptions.IgnoreCase
                ).Trim();

                return content;
            }
            return "<p style='color:#e11d48;'>Kripto analizi şu anda yapılamıyor. Lütfen daha sonra tekrar deneyiniz.</p>";
        }
    }
}