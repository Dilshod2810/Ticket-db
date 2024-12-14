using Domain.Models;
using Infrastructure.ApiResponse;

namespace Infrastructure.ITicketLocationService;

public interface ITicketLocationService
{
    Response<TicketLocation> GetById(int id);
    Response<bool> Create(TicketLocation ticketLocation);
    Response<bool> Delete(int id);
}