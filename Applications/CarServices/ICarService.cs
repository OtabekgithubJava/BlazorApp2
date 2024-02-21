using BlazorApp2.Models;

namespace BlazorApp2.Applications.CarServices;

public interface ICarService
{
    public Task<string> CreateCarAsync(Car model);
    public Task<Car> UpdateCarAsync(int id, Car model);
    public Task<bool> DeleteCarAsync(int id);
    public Task<List<Car>> GetAllCarsAsync();
    public Task<Car> GetCarByIdAsync(int id);

}