using WebApiBank.DTOs;
using WebApiBank.Models;
using WebApiBank.Repositories;

namespace WebApiBank.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _repository;

        public AccountService(IAccountRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<AccountDTO>> GetAllAsync()
        {
            var accounts = await _repository.GetAllAsync();
            return accounts.Select(a => new AccountDTO
            {
                Id = a.Id,
                ClientId = a.ClientId,
                Balance = a.Balance
            });
        }

        public async Task<AccountDTO?> GetByIdAsync(int id)
        {
            var account = await _repository.GetByIdAsync(id);
            if (account == null) return null;

            return new AccountDTO
            {
                Id = account.Id,
                ClientId = account.ClientId,
                Balance = account.Balance
            };
        }

        public async Task<AccountDTO> CreateAsync(AccountDTO accountDto)
        {
            var account = new Account
            {
                ClientId = accountDto.ClientId,
                Balance = accountDto.Balance
            };

            var created = await _repository.AddAsync(account);
            return new AccountDTO
            {
                Id = created.Id,
                ClientId = created.ClientId,
                Balance = created.Balance
            };
        }

        public async Task<AccountDTO?> UpdateAsync(int id, AccountDTO accountDto)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null) return null;

            existing.ClientId = accountDto.ClientId;
            existing.Balance = accountDto.Balance;

            await _repository.UpdateAsync(existing);

            return new AccountDTO
            {
                Id = existing.Id,
                ClientId = existing.ClientId,
                Balance = existing.Balance
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null) return false;

            await _repository.DeleteAsync(id);
            return true;
        }
    }
}
