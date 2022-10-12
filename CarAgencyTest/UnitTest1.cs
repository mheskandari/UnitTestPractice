using CarAgency.Entities;
using CarAgency.Repositories;
using CarAgency.Services;
using Moq;

namespace CarAgencyTest
{
    [TestClass]
    public class GetAllCarsTest
    {
        private readonly Mock<ICarsAPI> carsAPIMock;
        private BookingService bookingService;
        private readonly List<Car> cars;
        private readonly Mock<ICarDatabase> mockCarDatabase;

        public GetAllCarsTest()
        {
            carsAPIMock = new Mock<ICarsAPI>();
            mockCarDatabase = new Mock<ICarDatabase>();
            bookingService = new BookingService(carsAPIMock.Object, mockCarDatabase.Object);

            cars = new List<Car>(){
                    new Car{
                        Id=1,Model=CarAgency.Entities.CarsModel.BMW,Name="116i"
                    },new Car{
                        Id=2,Model=CarAgency.Entities.CarsModel.BMW,Name="116i"
                    },new Car{
                        Id=3,Model=CarAgency.Entities.CarsModel.BMW,Name="116i"
                    },new Car{
                        Id=4,Model=CarAgency.Entities.CarsModel.Mercedes,Name="Benz"
                    },
                };
        }

        [TestMethod]
        public void return_all_when_there_isnt_filter()
        {
            carsAPIMock.Setup(m => m.getCars()).Returns(cars);
            mockCarDatabase.Setup(m => m.SaveCars(It.IsAny<List<Car>>())).Returns(0);

            var result = bookingService.GetAllCars(null);
            Assert.AreEqual(cars.Count, result.Count);
        }

        [TestMethod]
        public void return_all_bmw_model()
        {
            carsAPIMock.Setup(m => m.getCars()).Returns(cars);
            mockCarDatabase.Setup(m => m.SaveCars(It.IsAny<List<Car>>())).Returns(1);

            var result = bookingService.GetAllCars(CarsModel.BMW);
            Assert.AreEqual(cars.Count(m => m.Model == CarsModel.BMW), result.Count);
        }


        [TestMethod]
        public void return_exception_when_cant_store_in_db()
        {
            carsAPIMock.Setup(m => m.getCars()).Returns(cars);
            mockCarDatabase.Setup(m => m.SaveCars(It.IsAny<List<Car>>())).Returns((int?)null);

            var result = () => bookingService.GetAllCars(CarsModel.BMW);
            Assert.ThrowsException<Exception>(result);
        }


        [TestMethod]
        public void return_exception_when_exception_happens()
        {
            carsAPIMock.Setup(m => m.getCars()).Throws(new Exception());
            var result = () => bookingService.GetAllCars(CarsModel.BMW);
            Assert.ThrowsException<Exception>(result);
        }
    }
}