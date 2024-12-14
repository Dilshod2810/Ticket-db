using System.Net;
using Dapper;
using Domain.Models;
using Infrastructure.ApiResponse;
using Infrastructure.DataContext;

namespace Infrastructure.ICustomerService;

public class CustomerService(DapperContext context):ICustomerService
{
    public Response<List<Customer>> GetAll()
    {
        var sql = "select * from customers;";
        var customers = context.Connection().Query<Customer>(sql).ToList();
        return new Response<List<Customer>>(customers);
    }

    public Response<Customer> GetById(int id)
    {
        var sql = "select * from customers where customerid = @Id";
        var customer = context.Connection().QuerySingleOrDefault<Customer>(sql, new { Id = id });
        return customer == null
            ? new Response<Customer>(HttpStatusCode.NotFound, "Customer not found")
            : new Response<Customer>(HttpStatusCode.OK, "Customer already exists");
    }

    public Response<bool> Create(Customer customer)
    {
        var sql = "insert into customers (fullname, email, phone) values (fullname=@FullName, email=@Email, phone=@Phone);";
        var rowsAffected = context.Connection().Execute(sql, customer);
        return rowsAffected > 0
            ? new Response<bool>(HttpStatusCode.Created, "Customer created successfully")
            : new Response<bool>(HttpStatusCode.BadRequest, "Failed to create customer");
    }

    public Response<bool> Update(Customer customer)
    {
        var sql = "update customers set fullname=@FullName, email=@Email, phone=@Phone where customerid=@CustomerId;";
        var rowsAffected = context.Connection().Execute(sql, customer);
        return rowsAffected > 0
            ? new Response<bool>(HttpStatusCode.OK, "Customer updated successfully")
            : new Response<bool>(HttpStatusCode.NotFound, "Customer not found");
    }

    public Response<bool> Delete(int id)
    {
        var sql = "delete from customers where customerid = @Id";
        var customer = GetById(id).Data;
        if (customer == null)
        {
            return new Response<bool>(HttpStatusCode.NotFound, "Customer not found");
        }
        var deleted = context.Connection().Execute(sql, new { Id = id });
        return deleted > 0
           ? new Response<bool>(HttpStatusCode.OK, "Customer deleted successfully")
            : new Response<bool>(HttpStatusCode.NotFound, "Customer not found");
    }
}