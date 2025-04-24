using WebApiBank.DTOs;

public interface ITransactionService
{
    Task<AccountDTO> ExecuteTransactionAsync(int accountId, decimal amount, ITransactionStrategy strategy);
}
