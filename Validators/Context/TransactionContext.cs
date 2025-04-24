using WebApiBank.DTOs;

public class TransactionContext
{
    public int AccountId { get; set; }
    public string OperationType { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    public AccountDTO? Account { get; set; } 
}
