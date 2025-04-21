namespace WebApiBank.DTOs
{
    public class DepositDTO
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
    }
}
