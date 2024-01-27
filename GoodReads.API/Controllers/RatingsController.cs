using Microsoft.AspNetCore.Mvc;

using MediatR;

using GoodReads.API.Extensions;
using GoodReads.Core.Results;
using GoodReads.Application.Ratings.CreateRating;

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

    [HttpGet]
    public IEnumerable<string> Get()
    {
        return new string[] { "value1", "value2" };
    }

    [HttpGet("{id}")]
    public string GetById(int id)
    {
        return "value";
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateRatingCommand command)
    {
        var result = await _mediator.Send(command);

        return result.Match(
        onSuccess: value => CreatedAtAction(nameof(GetById), new { id = value }, command),
        onFailure: this.GetResult);
    }

    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}