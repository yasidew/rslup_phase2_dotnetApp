using Microsoft.AspNetCore.Mvc;

[Route("api/flights") ]
[ApiController]

public class FlightController : ControllerBase
{

    [HttpGet]

    public IActionResult GetAllFlights()
    {
        return Ok("List of all flights");

    }

    [HttpGet("{id}")] // GET api/flights

    public IActionResult GetFlightById(int id) {

        return  Ok($"Flight details for ID {id}");
    }


   [HttpPost]
    public IActionResult CreateFlight([FromBody] FlightDto flightDto) 
    {
        
        var newFlight = new FlightDto
        {
            Id = GenerateUniqueId(), 
            DepartureCity = flightDto.DepartureCity,
            ArrivalCity = flightDto.ArrivalCity,
            Airline = flightDto.Airline
            
        };

        return CreatedAtAction(nameof(GetFlightById), new { id = newFlight.Id }, newFlight);
    }

    private int GenerateUniqueId()
    {
        return new Random().Next(1, 10000);
    }


    [HttpPut("{id}")]

    public IActionResult UpdateFlight(int id, [FromBody] FlightDto flightDto)
    {
        return Ok($"Flight with ID {id} has been updated");
    }

    [HttpDelete("{id}")]

    public IActionResult DeleteFlight(int id)
    {
        return Ok($"Flight with ID {id} has been deleted");
    }
}