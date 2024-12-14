using System.Net;
using Dapper;
using Domain.Models;
using Infrastructure.ApiResponse;
using Infrastructure.DataContext;

namespace Infrastructure.IPurchaseService;

public class PurchaseService(DapperContext context):IPurchaseService
{
    public Response<List<Purchase>> GetAll()
    {
        var sql = "select * from purchases;";
        var purchases = context.Connection().Query<Purchase>(sql).ToList();
        return new Response<List<Purchase>>(purchases);
    }

    public Response<Purchase> GetById(int id)
    {
        var sql = "select * from purchases where locationid = @Id";
        var location = context.Connection().QuerySingleOrDefault<Purchase>(sql, new { Id = id });
        return location == null
            ? new Response<Purchase>(HttpStatusCode.NotFound, "Purchase not found")
            : new Response<Purchase>(HttpStatusCode.OK, "Purchase already exists");
    }

    public Response<bool> Create(Purchase location)
    {
        var sql = "insert into purchases (ticketid, customerid, purchasedatetime, quantity, totalprice) values (ticketid=@City, customerid=@Address, purchasedatetime=@Purchasetype, quantity=@quantity, totalprice=@totalprice);";
        var created = context.Connection().Execute(sql, location);
        return created > 0
            ? new Response<bool>(HttpStatusCode.Created, "Purchase created successfully")
            : new Response<bool>(HttpStatusCode.BadRequest, "Failed to create location");
    }


}