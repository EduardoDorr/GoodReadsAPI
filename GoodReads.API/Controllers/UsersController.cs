using Microsoft.AspNetCore.Mvc;

using MediatR;

using GoodReads.Core.Results;
using GoodReads.API.Extensions;
using GoodReads.Application.Users.GetUser;
using GoodReads.Application.Users.GetUsers;
using GoodReads.Application.Users.CreateUser;
using GoodReads.Application.Users.UpdateUser;
using GoodReads.Application.Users.DeleteUser;
using GoodReads.Application.Users.GetUserWithRatings;
using GoodReads.Application.Reports.GetBooksReadyByUserInPeriod;

namespace GoodReads.API.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IMediator _mediator;

    public UsersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] GetUsersQuery query)
    {
        var result = await _mediator.Send(query);

        return result.Match(
            onSuccess: Ok,
            onFailure: this.GetResult);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var query = new GetUserQuery(id);

        var result = await _mediator.Send(query);

        return result.Match(
            onSuccess: Ok,
            onFailure: this.GetResult);
    }

    [HttpGet("{id}/ratings")]
    public async Task<IActionResult> GetByIdWithRatings(int id)
    {
        var query = new GetUserWithRatingsQuery(id);

        var result = await _mediator.Send(query);

        return result.Match(
            onSuccess: Ok,
            onFailure: this.GetResult);
    }

    [HttpGet("{id}/books-read")]
    public async Task<IActionResult> GetByIdWithRatings(int id, DateTime startDate, DateTime finishDate)
    {
        var query = new GetBooksReadByUserInPeriodQuery(id, startDate, finishDate);

        var result = await _mediator.Send(query);

        return result.Match(
            onSuccess: Ok,
            onFailure: this.GetResult);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateUserCommand command)
    {
        var result = await _mediator.Send(command);

        return result.Match(
            onSuccess: value => CreatedAtAction(nameof(GetById), new { id = value }, command),
            onFailure: this.GetResult);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateUserInputModel inputmodel)
    {
        var command = new UpdateUserCommand(id, inputmodel.Name, inputmodel.Email, inputmodel.Active);

        var result = await _mediator.Send(command);

        return result.Match(
            onSuccess: NoContent,
            onFailure: this.GetResult);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var command = new DeleteUserCommand(id);

        var result = await _mediator.Send(command);

        return result.Match(
            onSuccess: NoContent,
            onFailure: this.GetResult);
    }
}
