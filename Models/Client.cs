namespace WebApiBank.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        // Relación uno a muchos
        public ICollection<Account> Accounts { get; set; } = new List<Account>();
    }
}
