using Microsoft.AspNetCore.Mvc;

using MediatR;

using GoodReads.Core.Results;
using GoodReads.API.Extensions;
using GoodReads.Application.Books.GetBook;
using GoodReads.Application.Books.GetBooks;
using GoodReads.Application.Books.CreateBook;
using GoodReads.Application.Books.DeleteBook;
using GoodReads.Application.Books.UpdateBooks;
using GoodReads.Application.Books.GetBookWithRatings;

namespace GoodReads.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BooksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetBooksQuery query)
        {
            var result = await _mediator.Send(query);

            return result.Match(
            onSuccess: Ok,
            onFailure: this.GetResult);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetBookQuery(id);

            var result = await _mediator.Send(query);

            return result.Match(
            onSuccess: Ok,
            onFailure: this.GetResult);
        }

        [HttpGet("{id}/ratings")]
        public async Task<IActionResult> GetByIdWithRatings(int id)
        {
            var query = new GetBookWithRatingsQuery(id);

            var result = await _mediator.Send(query);

            return result.Match(
            onSuccess: Ok,
            onFailure: this.GetResult);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateBookCommand command)
        {
            var result = await _mediator.Send(command);

            return result.Match(
            onSuccess: value => CreatedAtAction(nameof(GetById), new { id = value }, command),
            onFailure: this.GetResult);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateBookInputModel inputModel)
        {
            var command =
                new UpdateBookCommand(id, inputModel.Title, inputModel.Description, inputModel.Isbn,
                                      inputModel.Author, inputModel.Publisher, inputModel.Genre,
                                      inputModel.PublicationYear, inputModel.PrintLength, inputModel.CoverImage, inputModel.Active);

            var result = await _mediator.Send(command);

            return result.Match(
            onSuccess: NoContent,
            onFailure: this.GetResult);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteBookCommand(id);

            var result = await _mediator.Send(command);

            return result.Match(
            onSuccess: NoContent,
            onFailure: this.GetResult);
        }
    }
}