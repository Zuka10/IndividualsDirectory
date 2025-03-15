using IndividualsDirectory.Application.City.Command;
using IndividualsDirectory.Application.City.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IndividualsDirectory.Controllers;

[ApiController]
[Route("[controller]")]
public class CityController : ControllerBase
{
    private readonly IMediator _mediator;

    public CityController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetCities()
    {
        var result = await _mediator.Send(new GetAllCityQuery());
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCity(int id)
    {
        var result = await _mediator.Send(new GetCityByIdQuery { Id = id });
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCity(CreateCityCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }
}