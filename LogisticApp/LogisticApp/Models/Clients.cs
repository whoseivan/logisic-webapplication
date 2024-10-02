namespace LogisticApp.Models
{
    public class Clients
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string? LastName { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }

        // Связь с компанией
        public Company? Company { get; set; }
        // Связь с транзакциями
        public ICollection<Transaction>? Transactions { get; set; }
    }

}
