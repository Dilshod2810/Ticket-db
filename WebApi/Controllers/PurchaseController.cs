using Domain.Models;
using Infrastructure.ApiResponse;
using Infrastructure.IPurchaseService;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]

public class PurchaseController(IPurchaseService purchaseService) : ControllerBase
{
    [HttpGet("GetAllPurchases")]
    public Response<List<Purchase>> GetAll()
    {
        var response = purchaseService.GetAll();
        return response;
    }
    [HttpGet("GetCarById/{id}")]
    public Response<Purchase> GetCarById(int id)
    {
        return purchaseService.GetById(id);
    }

    [HttpPost("AddPurchase")]
    public Response<bool> Create(Purchase purchase)
    {
        var response = purchaseService.Create(purchase);
        return response;
    }


}