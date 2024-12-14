using Domain.Models;
using Infrastructure.ApiResponse;
using Infrastructure.ICustomerService;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomerController(ICustomerService customerService) : ControllerBase
{
    [HttpGet("GetAllCustomers")]
    public Response<List<Customer>> GetAll()
    {
        var response = customerService.GetAll();
        return response;
    }
    [HttpGet("GetCarById/{id}")]
    public Response<Customer> GetCarById(int id)
    {
        return customerService.GetById(id);
    }

    [HttpPost("AddCustomer")]
    public Response<bool> Create(Customer customer)
    {
        var response = customerService.Create(customer);
        return response;
    }

    [HttpPut("UpdateCustomer")]
    public Response<bool> Update(Customer customer)
    {
        var response = customerService.Update(customer);
        return response;
    }

    [HttpDelete("DeleteCustomer")]
    public Response<bool> Delete(int id)
    {
        var response = customerService.Delete(id);
        return response;
    }
}