namespace LogisticApp.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public int RouteId { get; set; }
        public int CarId { get; set; }
        public int DriverId { get; set; }
        public int LogisticianId { get; set; }
        public int ClientId { get; set; }
        public DateTime TransactionDate { get; set; }

        // Связь с маршрутами, автомобилями, водителями, логистами и клиентами
        public Routes? Route { get; set; }
        public Car? Car { get; set; }
        public Driver? Driver { get; set; }
        public Logistician? Logistician { get; set; }
        public Clients? Client { get; set; }
    }

}
