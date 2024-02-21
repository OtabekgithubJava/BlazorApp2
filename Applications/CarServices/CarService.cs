using BlazorApp2.Infrastructure;
using BlazorApp2.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp2.Applications.CarServices;

public class CarService: ICarService
{
    private readonly ApplicationDBContext _content;

    public CarService(ApplicationDBContext content)
    {
        _content = content;
    }

    public async Task<string> CreateCarAsync(Car model)
    {
        await _content.Cars.AddAsync(model);
        await _content.SaveChangesAsync();

        return "Data Created";
    }

    public async Task<Car> UpdateCarAsync(int id, Car model)
    {
        var car = _content.Cars.FirstOrDefaultAsync(x => x.Id == id);

        if (car != null)
        {
            car.Result.Name = model.Name;
            car.Result.Brand = model.Brand;

            // _content.Update(car);   => To update all, not just a component of model like name or brand

            await _content.SaveChangesAsync();
            return model;
        }
        return null;
    }

    public async Task<bool> DeleteCarAsync(int id)
    {
        var car = _content.Cars.FirstOrDefaultAsync(x => x.Id == id);

        if (car != null)
        {
            _content.Remove(car);
            await _content.SaveChangesAsync();

            return true;
        }
        return false;
    }

    public Task<List<Car>> GetAllCarsAsync()
    {
        var car = _content.Cars.ToListAsync();

        return car;
    }

    public Task<Car> GetCarByIdAsync(int id)
    {
        var car = _content.Cars.FirstOrDefaultAsync(x => x.Id == id);

        if (car != null)
        {
            return car;
        }
        return null;
    }
}