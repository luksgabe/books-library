using MediatR;

namespace BooksLibrary.Domain.Interfaces.SeedWork
{
    public interface IQuery<out TResult> : IRequest<TResult>
    {

    }
}
