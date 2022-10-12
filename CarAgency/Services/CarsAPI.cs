using CarAgency.Entities;

namespace CarAgency.Services
{
    public interface ICarsAPI
    {
        List<Car> getCars();
    }

    public class CarsAPI : ICarsAPI
    {
        public List<Car> getCars()
        {
            return new List<Car> { new Car {Model=CarsModel.Mercedes } };
        }
    }
}