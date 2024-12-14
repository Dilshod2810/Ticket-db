using Domain.Models;
using Infrastructure.ApiResponse;

namespace Infrastructure.ICustomerService;

public interface ICustomerService
{
    Response<List<Customer>> GetAll();
    Response<Customer> GetById(int id);
    Response<bool> Create(Customer customer);
    Response<bool> Update(Customer customer);
    Response<bool> Delete(int id);
}