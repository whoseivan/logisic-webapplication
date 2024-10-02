namespace LogisticApp.Models
{
    public class Brand
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        // Связь с автомобилями
        public ICollection<Car>? Cars { get; set; }
    }

}
