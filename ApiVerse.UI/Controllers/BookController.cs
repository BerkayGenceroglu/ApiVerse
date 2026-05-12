using ApiVerse.Api.Models.BookModels;
using ApiVerse.UI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Threading.Tasks;

namespace ApiVerse.UI.Controllers
{
    public class BookController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        public BookController(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }

        public IActionResult BookPage()
        {
            return View(new BookSearchViewModel());

        }

        [HttpPost]
        public async Task<IActionResult> BookSearch(BookSearchViewModel model)
        {
            var client = _httpClientFactory.CreateClient();
            // API URL'sini kontrol et (api/Book/{query} şeklinde mi tanımlı?)
            var response = await client.GetAsync($"https://localhost:7239/api/Book/{Uri.EscapeDataString(model.Query)}");

            if (response.IsSuccessStatusCode)
            {
                var values = await response.Content.ReadAsStringAsync();

                // DÜZELTME: Deserialize edilen tipi List<ResultBookModel.BookItem> yapmalısın
                var books = System.Text.Json.JsonSerializer.Deserialize<List<ResultBookModel.BookItem>>(values, new System.Text.Json.JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                ViewBag.Books = books;
                // AI analizi yaparak tek bir kitap önerisi alıyoruz
                if (books != null && books.Count > 0)
                {
                    var aiAnalysis = await GetAiAnalysisBooks(books);
                    ViewBag.AiAnalysis = aiAnalysis;
                }
                else
                {
                    ViewBag.AiAnalysis = "Kitap bulunamadı, AI analizi yapılamıyor.";
                }
            }
            return View("BookPage", model);
        }

        private async Task<string> GetAiAnalysisBooks(List<ResultBookModel.BookItem> books)
        {
            var apiKey = _configuration["OpenAIApiKey:Key"];
            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");

            // Kitap listesine Yayınevi (Publisher) bilgisini ekledik
            var bookListText = string.Join("\n", books.Select(b =>
                $"- Başlık: {b.VolumeInfo.Title}, Yazar: {string.Join(", ", b.VolumeInfo.Authors ?? new List<string>())}, Yayınevi: {b.VolumeInfo.Publisher ?? "Belirtilmemiş"}, Açıklama: {b.VolumeInfo.Description}"));

            var prompt = $@"
                Aşağıda birden fazla kitap bulunmaktadır.
                Görevin: Bu kitapları analiz ederek, okuyucu için en uygun TEK bir kitabı seçmek.

                Kurallar:
                - SADECE 1 kitap seç.
                - Çok uzun yazma (maksimum 5 cümle).
                - Seçtiğin kitabın yayınevi bilgisini mutlaka belirt.

                Cevap formatı (Bu formata sadık kal):
                Seçilen Kitap: <kitap adı>
                Yazar: <yazar adı>
                Yayınevi: <yayınevi adı>
                Neden: <kısa ve güçlü açıklama>

                Kitaplar:
         {bookListText}";

            var requestBody = new
            {
                model = "gpt-4",
                messages = new[]
                {
            new { role = "system", content = "Sen profesyonel bir kitap eleştirmenisin." },
            new { role = "user", content = prompt }
        },
                temperature = 0.7
            };

            try
            {
                var response = await client.PostAsJsonAsync("https://api.openai.com/v1/chat/completions", requestBody);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<JsonElement>();
                    return result.GetProperty("choices")[0].GetProperty("message").GetProperty("content").GetString();
                }
                return "AI analizi şu an yapılamıyor.";
            }
            catch (Exception ex)
            {
                return $"Hata oluştu: {ex.Message}";
            }
        }
    }
}
