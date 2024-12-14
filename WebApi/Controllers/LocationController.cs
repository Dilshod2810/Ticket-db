using Domain.Models;
using Infrastructure.ApiResponse;
using Infrastructure.ILocationService;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]

public class LocationController(ILocationService locationService) : ControllerBase
{
    [HttpGet("GetAllLocations")]
    public Response<List<Location>> GetAll()
    {
        var response = locationService.GetAll();
        return response;
    }
    [HttpGet("GetCarById/{id}")]
    public Response<Location> GetCarById(int id)
    {
        return locationService.GetById(id);
    }

    [HttpPost("AddLocation")]
    public Response<bool> Create(Location location)
    {
        var response = locationService.Create(location);
        return response;
    }
    [HttpPut("UpdateLocation")]
    public Response<bool> Update(Location location)
    {
        var response = locationService.Update(location);
        return response;
    }

    [HttpDelete("DeleteLocation")]
    public Response<bool> Delete(int id)
    {
        var response = locationService.Delete(id);
        return response;
    }

}