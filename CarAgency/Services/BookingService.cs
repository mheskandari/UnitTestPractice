using CarAgency.Entities;
using CarAgency.Repositories;

namespace CarAgency.Services
{
    public class BookingService : IBookingService
    {
        private ICarsAPI carsAPI;
        private ICarDatabase carDatabase;

        public BookingService(ICarsAPI carsAPI, ICarDatabase carDatabase)
        {
            this.carsAPI = carsAPI;
            this.carDatabase = carDatabase;
        }


        public List<Car> GetAllCars(CarsModel? carsModel)
        {
            var cars = carsAPI.getCars();

            var newCars = new List<Car>();
            foreach (var car in cars)
            {
                if (car.Id > 3)
                {
                    newCars.Add(car);
                }
            }
            var count = carDatabase.SaveCars(newCars);

            if (count == null)
            {
                throw new Exception("something happens in database!");
            }
            if (carsModel == null)
            {
                return cars;
            }
            return cars.Where(m => m.Model == carsModel).ToList();
        }
    }
}
