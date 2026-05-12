using ApiVerse.Api.Models.ExchangeModels;
using ApiVerse.Api.Models.SocialMediaModels;
using ApiVerse.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace ApiVerse.UI.Controllers
{
    public class ExchangeController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public ExchangeController(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }

        public async Task<IActionResult> ExchangePage()
        {
            var client = _httpClientFactory.CreateClient();

            var goldTask = client.GetAsync("https://localhost:7239/api/Exchange/gold");
            var currencyTask = client.GetAsync("https://localhost:7239/api/Exchange/currency");
            var bitcoinTask = client.GetAsync("https://localhost:7239/api/Exchange/bitcoin");


            await Task.WhenAll(goldTask, currencyTask, bitcoinTask);

            var goldJson = await goldTask.Result.Content.ReadAsStringAsync();
            var currencyJson = await currencyTask.Result.Content.ReadAsStringAsync();
            var bitcoinJson = await bitcoinTask.Result.Content.ReadAsStringAsync();

            var Model = new ExchangeViewModel
            {
                ResultGoldViewModel= JsonConvert.DeserializeObject<ResultGoldİnfoViewModel>(goldJson)!,
                CurrencyRateViewModel= JsonConvert.DeserializeObject<CurrencyRateViewModel>(currencyJson)!,
                BitcoinValueViewModel = JsonConvert.DeserializeObject<BitcoinValueViewModel>(bitcoinJson)!,
            };
            Model.AiAnalysis =await GetAiMarketAnalysis(Model);
            return View(Model);
        }

        private async Task<string> GetAiMarketAnalysis(ExchangeViewModel model)
        {
            var apiKey = _configuration["OpenAIApiKey:Key"];
            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");

            // AI'ya gönderilecek prompt
            var prompt = $@"
                Aşağıdaki piyasa verilerini analiz et ve bir yatırımcı gözüyle profesyonel bir piyasa değerlendirme notu oluştur.

                📊 VERİLER:
                - Altın (Gram): Alış {model.ResultGoldViewModel.buy}, Değişim %{model.ResultGoldViewModel.percent}
                - Döviz: USD {model.CurrencyRateViewModel.USD} TL, EUR {model.CurrencyRateViewModel.EUR} TL
                - Bitcoin: {model.BitcoinValueViewModel.lastPrice}

                📌 GÖREV:
                - Bu verileri yorumla
                - Piyasanın genel yönü hakkında analiz yap (yükseliş / düşüş eğilimi)
                - Olası kısa vadeli ve orta vadeli beklentiyi tahmin et
                - Varlıklar arasında ilişki kur (örneğin dolar artarsa altın etkilenir gibi)
                - Yatırımcı dili kullan (profesyonel, analitik)

                ⚠️ ÖNEMLİ:
                - Kesin ifade kullanma (garanti, kesin yükselir gibi)
                - Ancak yüzeysel olmasın, detaylı analiz yap
                - En az 5-6 cümle yaz

                📌 SON CÜMLE:
                Mutlaka 'Yatırım tavsiyesi değildir.' ifadesi ile bitir.
                ";

            var requestBody = new
            {
                model = "gpt-4o", // veya gpt-4
                messages = new[] { new { role = "user", content = prompt } },
                temperature = 0.7
            };

            var response = await client.PostAsJsonAsync("https://api.openai.com/v1/chat/completions", requestBody);

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                dynamic result = JsonConvert.DeserializeObject(jsonResponse);
                return result.choices[0].message.content;
            }

            return "Piyasa analizi şu anda yapılamıyor. Lütfen daha sonra tekrar deneyiniz.";
        }
    }
}
