using BooksLibrary.Domain.Interfaces.SeedWork;
using MediatR;

namespace BooksLibrary.Infra.CrossCutting.Bus
{
    public class InMemoryBus : IMediatorHandler
    {
        private readonly IMediator _mediator;

        public InMemoryBus(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<TResponse> SendQuery<TResponse>(IRequest<TResponse> query)
        {
            return await _mediator.Send(query);
        }
    }
}
