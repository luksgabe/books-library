using Azure.Core;
using BooksLibrary.Domain.Entities;
using BooksLibrary.Domain.Interfaces.Repository;
using BooksLibrary.Domain.Models;
using BooksLibrary.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace BooksLibrary.Infra.Data.Repository
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<PageResult<Book>> GetBooks(int size, int page)
        {
            var books = await _context.Books.Include(i => i.Image).ToListAsync();
                
            return new PageResult<Book>
            {
                CurrentPage = page,
                PageSize = size,
                TotalItems = books.Count,
                Items = books.Skip((page - 1) * size).Take(size).OrderBy(b => b.Title),
                TotalPages = (int)Math.Ceiling(books.Count / (double)size)
            };
        }

        public async Task<IEnumerable<Book>> GetBooksByTitles(List<string> titles)
        {
            var books = await _context.Books
                .Where(b => titles.Contains(b.Title))
                .ToListAsync();
            return books;
        }

        public Task<Book> GetBySubject(string subject)
        {
            throw new NotImplementedException();
        }
    }
}
