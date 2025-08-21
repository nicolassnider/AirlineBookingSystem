using AirlineBookingSystem.Flights.Application.Commands;
using AirlineBookingSystem.Flights.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AirlineBookingSystem.Flights.Api.Controllers;

[ApiController]
[Route("api/flights")]
public class FlightsController : ControllerBase
{
    private readonly IMediator _mediator;

    public FlightsController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpGet]
    public async Task<IActionResult> GetFlights()
    {
        var flights = await _mediator.Send(new GetAllFlightsQuery());
        return Ok(flights);
    }
    [HttpPost]
    public async Task<IActionResult> AddFlight([FromQuery] CreateFlightCommand command)
    {
        var id = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetFlights), new { id }, null);
    }
    [HttpDelete]
    public async Task<IActionResult> DeleteFlight([FromQuery] DeleteFlightCommand command)
    {
        await _mediator.Send(command);
        return NoContent();

    }
}
