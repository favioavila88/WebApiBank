namespace WebApiBank.Models
{
    public class Withdrawal
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }

        public Account Account { get; set; } = null!;
    }
}
