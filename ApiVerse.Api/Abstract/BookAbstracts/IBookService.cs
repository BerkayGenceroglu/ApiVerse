using ApiVerse.Api.Models.BookModels;

namespace ApiVerse.Api.Abstract.BookAbstracts
{
    public interface IBookService
    {
        Task<List<ResultBookModel.BookItem>> SearchBooksAsync(string aramaMetni);
    }
}
