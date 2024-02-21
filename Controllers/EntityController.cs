using BlazorApp2.Applications.CarServices;
using BlazorApp2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace BlazorApp2.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class EntityController : Controller
{
    private readonly ICarService _carService;

    public EntityController(ICarService carService)
    {
        _carService = carService;
    }

    [HttpPost]
    public async Task<string> CreateCar(Car model)
    {
        var results = await _carService.CreateCarAsync(model);
        return results;
    }
    
    [HttpGet]
    public async Task<List<Car>> GetAllCars()
    {
        var results = await _carService.GetAllCarsAsync();
        return results;
    }
    
    [HttpGet]
    public async Task<Car> GetAllCarsById(int id)
    {
        var results = await _carService.GetCarByIdAsync(id);
        return results;
    }
    
    [HttpPut]
    public async Task<Car> UpdateCarsById(int id, Car model)
    {
        var results = await _carService.UpdateCarAsync(id, model);
        return results;
    }
    
    [HttpDelete]
    public async Task<bool> DeleteCarsById(int id)
    {
        var results = await _carService.DeleteCarAsync(id);
        return results;
    }
    
}