﻿using IndividualsDirectory.Application.Person.Command.AddRelated;
using IndividualsDirectory.Application.Person.Command.Create;
using IndividualsDirectory.Application.Person.Command.Delete;
using IndividualsDirectory.Application.Person.Command.RemoveRelated;
using IndividualsDirectory.Application.Person.Command.Update;
using IndividualsDirectory.Application.Person.Query.GetAll;
using IndividualsDirectory.Application.Person.Query.GetById;
using IndividualsDirectory.Application.Person.Query.RelatedReport;
using IndividualsDirectory.Application.Person.Query.Search;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IndividualsDirectory.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PersonController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpGet("report")]
    public async Task<IActionResult> GetIndividualsReport()
    {
        var result = await _mediator.Send(new GetRelatedIndividualsReportQuery());
        return Ok(result);
    }

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
        await _mediator.Send(command);
        return Ok("Created successfully");
    }

    [HttpPost("/AddRelatedPerson")]
    public async Task<IActionResult> AddRelated([FromForm] AddRelatedPersonCommand command)
    {
        await _mediator.Send(command);
        return Ok("Added successfully");
    }

    [HttpDelete("/RemoveRelatedPerson")]
    public async Task<IActionResult> RemoveRelated([FromForm] RemoveRelatedPersonCommand command)
    {
        await _mediator.Send(command);
        return Ok("Removed successfully");
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromForm] UpdatePersonCommand command)
    {
        await _mediator.Send(command);
        return Ok("Updated successfully");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _mediator.Send(new DeletePersonCommand { Id = id });
        return Ok("Deleted successfuly");
    }
}