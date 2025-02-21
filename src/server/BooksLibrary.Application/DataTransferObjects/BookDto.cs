namespace BooksLibrary.Application.DataTransferObjects
{
    public record BookDto(string Title, string Author, string Description, string Category, string Link, BookImageDto? Image);
}
