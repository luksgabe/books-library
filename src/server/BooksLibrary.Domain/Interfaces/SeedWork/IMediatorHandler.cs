using MediatR;


namespace BooksLibrary.Domain.Interfaces.SeedWork
{
    public interface IMediatorHandler
    {
        Task<TResponse> SendQuery<TResponse>(IRequest<TResponse> request);
    }
}
