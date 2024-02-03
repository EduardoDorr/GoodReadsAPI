using Microsoft.AspNetCore.Mvc;

using MediatR;

using GoodReads.Core.Results;
using GoodReads.API.Extensions;
using GoodReads.Application.ExternalBooksApi.GetBookByIsbn;
using GoodReads.Application.ExternalBooksApi.GetBooksByTitle;

namespace GoodReads.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class GoogleBooksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GoogleBooksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("isbn/{isbn}")]
        public async Task<IActionResult> GetBooksByIsbn(string isbn)
        {
            var request = new GetBookByIsbnRequest(isbn);

            var result = await _mediator.Send(request);

            return result.Match(
            onSuccess: Ok,
            onFailure: this.GetResult);
        }

        [HttpGet("title/{title}")]
        public async Task<IActionResult> GetBooksByTitle(string title)
        {
            var request = new GetBooksByTitleRequest(title);

            var result = await _mediator.Send(request);

            return result.Match(
            onSuccess: Ok,
            onFailure: this.GetResult);
        }
    }
}
