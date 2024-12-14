using Domain.Models;
using Infrastructure.ApiResponse;

namespace Infrastructure.ITicketService;

public interface ITicketService
{
    Response<List<Ticket>> GetAll();
    Response<Ticket> GetById(int id);
    Response<bool> Create(Ticket ticket);
    Response<bool> Update(Ticket ticket);
    Response<bool> Delete(int id);
}