using Domain.Models;
using Infrastructure.ApiResponse;

namespace Infrastructure.IPurchaseService;

public interface IPurchaseService
{
    Response<List<Purchase>> GetAll();
    Response<Purchase> GetById(int id);
    Response<bool> Create(Purchase purchase);

}