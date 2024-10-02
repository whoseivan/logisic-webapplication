namespace LogisticApp.Models
{
    public class Routes
    {
        public int Id { get; set; }
        public string? DeparturePoint { get; set; }
        public string? ArrivalPoint { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime ArrivalDate { get; set; }
        public decimal DistanceKm { get; set; }
        public decimal FuelConsumption { get; set; }
        public decimal Price { get; set; }

        // Связь с транзакциями
        public ICollection<Transaction>? Transactions { get; set; }
    }

}
