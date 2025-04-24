using System.ComponentModel.DataAnnotations;

namespace WebApiBank.DTOs
{
    public class TransactionDTO
    {
        public int Id { get; set; }
        [Required]
        public int AccountId { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        [Required]
        public string Type { get; set; } = ""; 
    }
}
