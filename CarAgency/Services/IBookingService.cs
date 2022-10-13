using CarAgency.Entities;

namespace CarAgency.Services
{
    public interface IBookingService
    {
        List<Car> GetAllCars(CarsModel? carsModel);
    }
}