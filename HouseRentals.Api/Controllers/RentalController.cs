﻿namespace HouseRentals.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RentalController : ControllerBase
{
    private readonly IRentalService _rentalService;

    public RentalController(IRentalService rentalService)
        => _rentalService = rentalService;

    [HttpGet]
    public async Task<IActionResult> GetAllAsync([FromQuery] RentalFilter filter)
    {
        var rentals = await _rentalService.GetAllAsync(filter);
        return Ok(rentals);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync(long id)
    {
        var rental = await _rentalService.GetAsync(id);
        return Ok(rental);
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] RentalInsertDto rentalDto)
    {
        var rental = await _rentalService.CreateAsync(rentalDto);
        return Ok(rental);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(long id, [FromBody] RentalUpdateDto rentalDto)
    {
        var rental = await _rentalService.UpdateAsync(id, rentalDto);
        return Ok(rental);
    }

    [HttpPut("rent")]
    public async Task<IActionResult> PutRentAsync([FromQuery] long id, [FromQuery] decimal discount)
    {
        var rental = await _rentalService.RentAsync(id, discount);
        return Ok(rental);
    }

    [HttpPut("unrent/{id}")]
    public async Task<IActionResult> PutUnRentAsync(long id)
    {
        var rental = await _rentalService.UnRentAsync(id);
        return Ok(rental);
    }
}
