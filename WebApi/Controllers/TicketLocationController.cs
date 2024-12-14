using Domain.Models;
using Infrastructure.ApiResponse;
using Infrastructure.ITicketLocationService;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]

public class TicketLocationController(ITicketLocationService ticketLocationService) : ControllerBase
{

    [HttpGet("GetCarById/{id}")]
    public Response<TicketLocation> GetCarById(int id)
    {
        return ticketLocationService.GetById(id);
    }

    [HttpPost("AddTicketLocation")]
    public Response<bool> Create(TicketLocation ticketLocation)
    {
        var response = ticketLocationService.Create(ticketLocation);
        return response;
    }
    

    [HttpDelete("DeleteTicketLocation")]
    public Response<bool> Delete(int id)
    {
        var response = ticketLocationService.Delete(id);
        return response;
    }
}