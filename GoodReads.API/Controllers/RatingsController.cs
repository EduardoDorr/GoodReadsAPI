using Microsoft.AspNetCore.Mvc;

using MediatR;

using GoodReads.Core.Results;
using GoodReads.API.Extensions;
using GoodReads.Application.Ratings.CreateRating;
using GoodReads.Application.Ratings.UpdateRating;
using GoodReads.Application.Ratings.DeleteRating;

namespace GoodReads.API.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class RatingsController : ControllerBase
{
    private readonly IMediator _mediator;

    public RatingsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateRatingCommand command)
    {
        var result = await _mediator.Send(command);

        return result.Match(
        onSuccess: value => CreatedAtAction(null, command),
        onFailure: this.GetResult);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateRatingInputModel inputModel)
    {
        var command =
                new UpdateRatingCommand(id, inputModel.Grade, inputModel.Description,
                                        inputModel.StartDate, inputModel.FinishDate, inputModel.Active);

        var result = await _mediator.Send(command);

        return result.Match(
        onSuccess: NoContent,
        onFailure: this.GetResult);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var command =
                new DeleteRatingCommand(id);

        var result = await _mediator.Send(command);

        return result.Match(
        onSuccess: NoContent,
        onFailure: this.GetResult);
    }
}