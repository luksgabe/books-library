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

        public async Task<PageResult<Book>> GetBooks(int size, int page, string searchParam)
        {
            var books = await _context.Books
                .Include(i => i.Image)
                .Where(b => !string.IsNullOrEmpty(searchParam) ? (b.Title.Contains(searchParam) 
                || b.Description!.Contains(searchParam)
                || b.Category.Contains(searchParam)) : true)
                .ToListAsync();

            books = books.Select(s =>
            {
                var description = s.Description?.Length > 100 ? $"{s.Description.Substring(0, 100)}..." : s.Description;
                var result = new Book(s.Title, s.Author, description, s.Category, s.Link);
                result.SetImage(s.Image!);
                return result;
            }).ToList();

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
