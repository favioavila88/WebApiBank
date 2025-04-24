using WebApiBank.DTOs;
using WebApiBank.Repositories;

public class TransactionService : ITransactionService
{
    private readonly IAccountRepository _accountRepository;

    public TransactionService(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }

    public async Task<AccountDTO> ExecuteTransactionAsync(int accountId, decimal amount, ITransactionStrategy strategy)
    {
        var account = await _accountRepository.GetByIdAsync(accountId);
        if (account == null)
            throw new NotFoundException($"Account with ID {accountId} not found.");

        var updatedAccount = await strategy.ExecuteAsync(account, amount);
        await _accountRepository.UpdateAsync(updatedAccount);

        return new AccountDTO
        {
            Id = updatedAccount.Id,
            ClientId = updatedAccount.ClientId,
            Balance = updatedAccount.Balance
        };
    }
}
