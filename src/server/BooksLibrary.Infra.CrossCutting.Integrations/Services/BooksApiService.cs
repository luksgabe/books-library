using BooksLibrary.Application.DataTransferObjects;
using BooksLibrary.Application.Interfaces;
using BooksLibrary.Domain.Entities;
using BooksLibrary.Domain.Interfaces.Repository;
using BooksLibrary.Domain.Interfaces.SeedWork;
using Google.Apis.Books.v1;
using Google.Apis.Books.v1.Data;
using Google.Apis.Services;
using Microsoft.Extensions.Logging;

namespace BooksLibrary.Infra.CrossCutting.Integrations.Options
{
    public class BooksApiService : IBooksApiService
    {
        private readonly BooksService _bookService;
        private readonly IBookRepository _bookRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<BooksApiService> _logger;

        public BooksApiService(GoogleApiSettings settings, IUnitOfWork unitOfWork, IBookRepository bookRepository, ILogger<BooksApiService> logger)
        {
            _bookService = new BooksService(new BaseClientService.Initializer()
            {
                ApiKey = settings.Key,
                ApplicationName = settings.AppName,
            });
            _bookRepository = bookRepository;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task ProccessBooksAsync()
        {
            try
            {
                _logger.LogInformation("Getting books to process...");
                IEnumerable<Book> books = await GetBooks();
                if(books.Any())
                {
                    await _bookRepository.AddRangeAsync(books);
                    await _unitOfWork.CommitAsync();

                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error processing books");
            }
            
        }

        private async Task<IEnumerable<Book>> GetBooks()
        {
            var list = new List<Book>();

            string[] genres = { "science fiction", "fantasy", "mystery", "romance", "thriller", "history", "biography", "cooking", "travel" };

            Random random = new Random();
            int randomIndex = random.Next(genres.Length);
            string randomGenre = genres[randomIndex];

            var request = _bookService.Volumes.List($"subject:{randomGenre}");
            var response = request.Execute();

            foreach (var item in response.Items)
            {
                var book = new Book(item.VolumeInfo.Title,
                    item.VolumeInfo.Authors[0],
                    item.VolumeInfo.Description,
                    item.VolumeInfo.Categories != null ? item.VolumeInfo.Categories[0] : string.Empty,
                    item.VolumeInfo.InfoLink);

                if(item.VolumeInfo.ImageLinks != null)
                    book.SetImage(new BookImage(item.VolumeInfo.ImageLinks.Thumbnail, item.VolumeInfo.ImageLinks.SmallThumbnail));

                list.Add(book);
            }

            var booksExist = await _bookRepository.GetBooksByTitles(list.Select(b => b.Title).ToList());
            
            list = list.Where(b => !booksExist.Any(be => be.Title == b.Title)).ToList();

            return list;
        }
    }
}
