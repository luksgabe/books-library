using BooksLibrary.Application.DataTransferObjects;

namespace BooksLibrary.Application.Common.Interfaces.UseCases
{
    public interface IBooksApiUseCase
    {
        Task<IEnumerable<BooksDTO>> GetBooks();
    }
}
