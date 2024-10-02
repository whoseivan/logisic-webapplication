namespace LogisticApp.Models
{
    public class Driver
    {
        public int id {  get; set; }
        public string? lastName { get; set; }
        public string? firstName { get; set; }
        public string? middleName { get; set; }
        public DateTime birthDate { get; set; }
        public string? passport { get; set; }
        public string? phoneNumber { get; set; }
        public string? address { get; set; }
        public string? email { get; set; }

        // Связь с транзакциями
        public ICollection<Transaction>? Transactions { get; set; }

    }
}
