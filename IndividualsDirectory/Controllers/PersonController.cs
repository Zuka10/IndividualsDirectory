using IndividualsDirectory.Application.Person.Command.Create;
using IndividualsDirectory.Application.Person.Query.GetAll;
using IndividualsDirectory.Application.Person.Query.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IndividualsDirectory.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PersonController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpGet]
    public async Task<IActionResult> GetPersons()
    {
        var result = await _mediator.Send(new GetAllPersonQuery());
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPerson(int id)
    {
        var result = await _mediator.Send(new GetPersonByIdQuery { Id = id });
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreatePerson([FromForm] CreatePersonCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }
}