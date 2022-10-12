namespace CarAgency.Entities
{
    public class Car
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CarsModel Model { get; set; }
    }

    public enum CarsModel
    {
        BMW,
        RENOT,
        Mercedes
    }
}