namespace LogisticApp.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? City { get; set; }
        public string? Address { get; set; }

        // Связь с клиентами
        public ICollection<Clients>? Clients { get; set; }
    }

}
