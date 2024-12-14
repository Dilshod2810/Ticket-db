using System.Net;
using Dapper;
using Domain.Models;
using Infrastructure.ApiResponse;
using Infrastructure.DataContext;

namespace Infrastructure.ILocationService;

public class LocationService(DapperContext context):ILocationService
{

    public Response<List<Location>> GetAll()
    {
        var sql = "select * from locations;";
        var locations = context.Connection().Query<Location>(sql).ToList();
        return new Response<List<Location>>(locations);
    }

    public Response<Location> GetById(int id)
    {
        var sql = "select * from locations where locationid = @Id";
        var location = context.Connection().QuerySingleOrDefault<Location>(sql, new { Id = id });
        return location == null
            ? new Response<Location>(HttpStatusCode.NotFound, "Location not found")
            : new Response<Location>(HttpStatusCode.OK, "Location already exists");
    }

    public Response<bool> Create(Location location)
    {
        var sql = "insert into locations (city, address, locationtype) values (city=@City, address=@Address, locationtype=@Locationtype);";
        var created = context.Connection().Execute(sql, location);
        return created > 0
            ? new Response<bool>(HttpStatusCode.Created, "Location created successfully")
            : new Response<bool>(HttpStatusCode.BadRequest, "Failed to create location");
    }

    public Response<bool> Update(Location location)
    {
        var sql = "update locations set city=@City, address=@Address, locationtype=@Locationtype where locationid=@LocationId;";
        var updated = context.Connection().Execute(sql, location);
        return updated > 0
            ? new Response<bool>(HttpStatusCode.OK, "Location updated successfully")
            : new Response<bool>(HttpStatusCode.NotFound, "Location not found");
    }

    public Response<bool> Delete(int id)
    {
        var sql = "delete from locations where locationid = @Id";
        var location = GetById(id).Data;
        if (location == null)
        {
            return new Response<bool>(HttpStatusCode.NotFound, "Location not found");
        }
        var deleted = context.Connection().Execute(sql, new { Id = id });
        return deleted > 0
           ? new Response<bool>(HttpStatusCode.OK, "Location deleted successfully")
            : new Response<bool>(HttpStatusCode.NotFound, "Location not found");
    }
}
