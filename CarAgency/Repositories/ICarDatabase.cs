using CarAgency.Entities;

namespace CarAgency.Repositories
{
    public interface ICarDatabase
    {
        int? SaveCars(List<Car> cars);
    }
}