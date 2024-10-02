namespace LogisticApp.Models
{
    public class Car
    {
        public int Id { get; set; }
        public int BrandId { get; set; }
        public string? Number { get; set; }
        public decimal FuelConsumption { get; set; }
        public int YearOfManufacture { get; set; }

        // Связь с брендом
        public Brand? Brand { get; set; }
    }

}
