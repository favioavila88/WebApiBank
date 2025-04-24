using WebApiBank.Models;

public class DepositStrategy : ITransactionStrategy
{
    public Task<Account> ExecuteAsync(Account account, decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Amount must be greater than 0 for a deposit.");

        account.Balance += amount;
        return Task.FromResult(account);
    }
}
