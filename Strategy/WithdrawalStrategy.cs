using WebApiBank.Models;

public class WithdrawalStrategy : ITransactionStrategy
{
    public Task<Account> ExecuteAsync(Account account, decimal amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("Amount must be greater than 0 for a withdrawal.");
        }

        if (account.Balance < amount)
        {
            throw new InvalidOperationException("Insufficient funds for withdrawal.");
        }

        account.Balance -= amount;
        return Task.FromResult(account);
    }
}
