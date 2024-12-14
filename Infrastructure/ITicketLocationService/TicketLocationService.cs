using System.Net;
using Dapper;
using Domain.Models;
using Infrastructure.ApiResponse;
using Infrastructure.DataContext;

namespace Infrastructure.ITicketLocationService;

public class TicketLocationService(DapperContext context): ITicketLocationService
{

    public Response<TicketLocation> GetById(int id)
    {
        var sql = "select * from ticketlocations where ticketlocationid = @Id";
        var location = context.Connection().QuerySingleOrDefault<TicketLocation>(sql, new { Id = id });
        return location == null
            ? new Response<TicketLocation>(HttpStatusCode.NotFound, "TicketLocation not found")
            : new Response<TicketLocation>(HttpStatusCode.OK, "TicketLocation already exists");
    }

    public Response<bool> Create(TicketLocation location)
    {
        var sql = "insert into ticketlocations (locationid) values (locationid=@locationid);";
        var created = context.Connection().Execute(sql, location);
        return created > 0
            ? new Response<bool>(HttpStatusCode.Created, "TicketLocation created successfully")
            : new Response<bool>(HttpStatusCode.BadRequest, "Failed to create location");
    }



    public Response<bool> Delete(int id)
    {
        var sql = "delete from ticketlocations where ticketlocationid = @Id";
        var location = GetById(id).Data;
        if (location == null)
        {
            return new Response<bool>(HttpStatusCode.NotFound, "TicketLocation not found");
        }
        var deleted = context.Connection().Execute(sql, new { Id = id });
        return deleted > 0
           ? new Response<bool>(HttpStatusCode.OK, "TicketLocation deleted successfully")
            : new Response<bool>(HttpStatusCode.NotFound, "TicketLocation not found");
    }
}