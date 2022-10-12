using CarAgency.Entities;

namespace CarAgency.Repositories
{
    public class CarDatabase : ICarDatabase
    {
        public CarDatabase()
        {

        }

        public int? SaveCars(List<Car> cars)
        {
            return cars.Count();
        }
    }
}
