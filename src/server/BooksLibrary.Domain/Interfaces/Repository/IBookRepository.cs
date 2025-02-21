using BooksLibrary.Domain.Entities;
using BooksLibrary.Domain.Models;

namespace BooksLibrary.Domain.Interfaces.Repository
{
    public interface IBookRepository : IRepository<Book>
    {
        Task<Book> GetBySubject(string subject);
        Task<IEnumerable<Book>> GetBooksByTitles(List<string> titles);
        Task<PageResult<Book>> GetBooks(int size, int page);
    }
}
