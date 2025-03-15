using IndividualsDirectory.Application.Person.Command.AddRelated;
using IndividualsDirectory.Application.Person.Command.Create;
using IndividualsDirectory.Application.Person.Command.Delete;
using IndividualsDirectory.Application.Person.Command.RemoveRelated;
using IndividualsDirectory.Application.Person.Command.Update;
using IndividualsDirectory.Application.Person.Query.GetAll;
using IndividualsDirectory.Application.Person.Query.GetById;
using IndividualsDirectory.Application.Person.Query.Search;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IndividualsDirectory.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PersonController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpGet("search")]
    public async Task<IActionResult> Search(string searchTerm, int pageNumber = 1, int pageSize = 10)
    {
        var result = await _mediator.Send(new SearchPersonQuery { SearchTerm = searchTerm, PageNumber = pageNumber, PageSize = pageSize });
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new GetAllPersonQuery());
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var result = await _mediator.Send(new GetPersonByIdQuery { Id = id });
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromForm] CreatePersonCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPost("/AddRelatedPerson")]
    public async Task<IActionResult> AddRelated([FromForm] AddRelatedPersonCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpDelete("/RemoveRelatedPerson")]
    public async Task<IActionResult> RemoveRelated([FromForm] RemoveRelatedPersonCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromForm] UpdatePersonCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _mediator.Send(new DeletePersonCommand { Id = id });
        return Ok(result);
    }
}