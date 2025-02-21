
using BooksLibrary.Application.DataTransferObjects;
using BooksLibrary.Domain.Interfaces.SeedWork;
using BooksLibrary.Domain.Models;

namespace BooksLibrary.Application.Book.Queries
{
    public class GetBooksQuery : IQuery<PageResult<BookDto>>
    {
        public string SearchParam { get; private set; }
        public int Size { get; private set; }
        public int Page { get; private set; }

        public GetBooksQuery(int size, int page, string searchParam)
        {
            Size = size;
            Page = page;
            SearchParam = searchParam;
        }
    }
}
