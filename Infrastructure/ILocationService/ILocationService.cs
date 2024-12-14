using Domain.Models;
using Infrastructure.ApiResponse;

namespace Infrastructure.ILocationService;

public interface ILocationService
{
    Response<List<Location>> GetAll();
    Response<Location> GetById(int id);
    Response<bool> Create(Location location);
    Response<bool> Update(Location location);
    Response<bool> Delete(int id);
}