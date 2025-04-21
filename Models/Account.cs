namespace WebApiBank.Models
{
    public class Account
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public decimal Balance { get; set; }

        // Navegación y transacciones
        public Client Client { get; set; } = null!;
        public ICollection<Deposit> Deposits { get; set; } = new List<Deposit>();
        public ICollection<Withdrawal> Withdrawals { get; set; } = new List<Withdrawal>();
    }
}
