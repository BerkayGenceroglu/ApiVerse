using ApiVerse.Api.Abstract.BookAbstracts;
using ApiVerse.Api.Models.BookModels;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using System.Text.Json;
using System.Web;
using static ApiVerse.Api.Models.BookModels.ResultBookModel;

namespace ApiVerse.Api.Services.BookService
{
    public class BookService: IBookService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        public BookService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<List<ResultBookModel.BookItem>> SearchBooksAsync(string aramaMetni)
        {

            string encodedQuery = HttpUtility.UrlEncode(aramaMetni);
            string queryUrl = $"https://www.googleapis.com/books/v1/volumes?q={encodedQuery}&key={_configuration["GoogleBookApi:Key"]}";

            try
            {
                // JSON'ı doğrudan ResultBookModel (Root) olarak deserialize ediyoruz
                var response = await _httpClient.GetFromJsonAsync<ResultBookModel>(queryUrl);

                // Geriye sadece kitap listesini (Items) döndürüyoruz
                return response?.Items ?? new List<ResultBookModel.BookItem>();
            }
            catch (Exception ex)
            {
                // Loglama yapılabilir
                return new List<ResultBookModel.BookItem>();
            }
        }
    }
}
