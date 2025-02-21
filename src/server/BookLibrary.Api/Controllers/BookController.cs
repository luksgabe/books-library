

using BookLibrary.Api.Models;
using BooksLibrary.Application.Book.Queries;
using BooksLibrary.Application.DataTransferObjects;
using BooksLibrary.Domain.Interfaces.SeedWork;
using BooksLibrary.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BookLibrary.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController(IMediatorHandler _mediator) : ApiController
    {

        /// <summary>
        /// Return a book paged list.
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(PageResult<BookDto>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Get([FromQuery] GetBooksRequest request)
        {
            var result = await _mediator.SendQuery(new GetBooksQuery(request.Size, request.Page, request.SearchParam));
            return GetCustomResponse(result);
        }
    }
}
