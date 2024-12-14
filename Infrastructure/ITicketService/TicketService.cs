using System.Net;
using Dapper;
using Domain.Models;
using Infrastructure.ApiResponse;
using Infrastructure.DataContext;

namespace Infrastructure.ITicketService;

public class TicketService(DapperContext context):ITicketService
{
    public Response<List<Ticket>> GetAll()
    {
        var sql = "select * from tickets;";
        var tickets = context.Connection().Query<Ticket>(sql).ToList();
        return new Response<List<Ticket>>(tickets);
    }

    public Response<Ticket> GetById(int id)
    {
        var sql = "select * from tickets where locationid = @Id";
        var location = context.Connection().QuerySingleOrDefault<Ticket>(sql, new { Id = id });
        return location == null
            ? new Response<Ticket>(HttpStatusCode.NotFound, "Ticket not found")
            : new Response<Ticket>(HttpStatusCode.OK, "Ticket already exists");
    }

    public Response<bool> Create(Ticket ticket)
    {
        var sql = "insert into tickets (type, title, price, evendatetime) values (type=@type, title=@title, price=@price, evendatetime=@evendatetime);";
        var created = context.Connection().Execute(sql, ticket);
        return created > 0
            ? new Response<bool>(HttpStatusCode.Created, "Ticket created successfully")
            : new Response<bool>(HttpStatusCode.BadRequest, "Failed to create ticket");
    }

    public Response<bool> Update(Ticket ticket)
    {
        var sql = "update tickets set type=@type, title=@title, price=@price, evendatetime=@evendatetime where ticketid=@TicketId;";
        var updated = context.Connection().Execute(sql, ticket);
        return updated > 0
            ? new Response<bool>(HttpStatusCode.OK, "Ticket updated successfully")
            : new Response<bool>(HttpStatusCode.NotFound, "Ticket not found");
    }

    public Response<bool> Delete(int id)
    {
        var sql = "delete from tickets where locationid = @Id";
        var ticket = GetById(id).Data;
        if (ticket == null)
        {
            return new Response<bool>(HttpStatusCode.NotFound, "Ticket not found");
        }
        var deleted = context.Connection().Execute(sql, new { Id = id });
        return deleted > 0
           ? new Response<bool>(HttpStatusCode.OK, "Ticket deleted successfully")
            : new Response<bool>(HttpStatusCode.NotFound, "Ticket not found");
    }
}