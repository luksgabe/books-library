using BooksLibrary.Application.Interfaces;
using Google.Apis.Books.v1;
using Google.Apis.Services;

namespace BooksLibrary.Infra.CrossCutting.Integrations.Options
{
    public class BooksApiService : IBooksApiService
    {
        private readonly BooksService _bookService;
        public BooksApiService(GoogleApiSettings settings)
        {
            _bookService = new BooksService(new BaseClientService.Initializer()
            {
                ApiKey = settings.Key,
                ApplicationName = settings.AppName,
            });
        }

        public async Task ProccessBooksAsync()
        {
            string[] genres = { "science fiction", "fantasy", "mystery", "romance", "thriller", "history", "biography", "cooking", "travel" };

            Random random = new Random();
            int randomIndex = random.Next(genres.Length);
            string randomGenre = genres[randomIndex];


            var request = _bookService.Volumes.List($"subject:{randomGenre}");
            var response = request.Execute();

            foreach (var item in response.Items)
            {
                Console.WriteLine("Title: " + item.VolumeInfo.Title);
                Console.WriteLine("Author: " + item.VolumeInfo.Authors[0]);
                Console.WriteLine("Description: " + item.VolumeInfo.Description);
                Console.WriteLine("Categories: " + item.VolumeInfo.Categories[0]);
            }

        }
    }
}
