using Domain.Models;
using Infrastructure.ApiResponse;
using Infrastructure.ITicketService;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]

public class TicketController(ITicketService ticketService) : ControllerBase
{
    [HttpGet("GetAllTickets")]
    public Response<List<Ticket>> GetAll()
    {
        var response = ticketService.GetAll();
        return response;
    }
    [HttpGet("GetCarById/{id}")]
    public Response<Ticket> GetCarById(int id)
    {
        return ticketService.GetById(id);
    }

    [HttpPost("AddTicket")]
    public Response<bool> Create(Ticket ticket)
    {
        var response = ticketService.Create(ticket);
        return response;
    }

    [HttpPut("UpdateTicket")]
    public Response<bool> Update(Ticket ticket)
    {
        var response = ticketService.Update(ticket);
        return response;
    }

    [HttpDelete("DeleteTicket")]
    public Response<bool> Delete(int id)
    {
        var response = ticketService.Delete(id);
        return response;
    }
}