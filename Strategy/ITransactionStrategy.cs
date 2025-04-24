using WebApiBank.Models;

public interface ITransactionStrategy
{
    Task<Account> ExecuteAsync(Account account, decimal amount);
}
