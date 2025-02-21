using AutoMapper;
using BooksLibrary.Application.DataTransferObjects;
using BooksLibrary.Domain.Interfaces.Repository;
using BooksLibrary.Domain.Models;
using MediatR;

namespace BooksLibrary.Application.Book.Queries
{
    public class BookQueryHandler(IMapper _mapper, IBookRepository _bookRepository) : IRequestHandler<GetBooksQuery, PageResult<BookDto>>
    {
        public async Task<PageResult<BookDto>> Handle(GetBooksQuery request, CancellationToken cancellationToken)
        {
            var pagedBooks = await _bookRepository.GetBooks(request.Size, request.Page);
            return _mapper.Map<PageResult<BookDto>>(pagedBooks);
        }
    }
}
