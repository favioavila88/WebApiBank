using WebApiBank.DTOs;
using WebApiBank.Models;
using WebApiBank.Repositories;

namespace WebApiBank.Services
{
    public class WithdrawalService : IWithdrawalService
    {
        private readonly IWithdrawalRepository _withdrawalRepository;
        private readonly IAccountRepository _accountRepository;

        public WithdrawalService(IWithdrawalRepository withdrawalRepository, IAccountRepository accountRepository)
        {
            _withdrawalRepository = withdrawalRepository;
            _accountRepository = accountRepository;
        }

        public async Task<WithdrawalDTO> CreateAsync(WithdrawalDTO withdrawalDto)
        {
            var account = await _accountRepository.GetByIdAsync(withdrawalDto.AccountId);
            if (account == null) throw new Exception("Account not found");

            if (account.Balance < withdrawalDto.Amount)
                throw new Exception("Insufficient funds");

            // Actualizar saldo
            account.Balance -= withdrawalDto.Amount;
            await _accountRepository.UpdateAsync(account);

            // Registrar retiro
            var withdrawal = new Withdrawal
            {
                AccountId = withdrawalDto.AccountId,
                Amount = withdrawalDto.Amount,
                Date = withdrawalDto.Date
            };

            var created = await _withdrawalRepository.AddAsync(withdrawal);

            return new WithdrawalDTO
            {
                Id = created.Id,
                AccountId = created.AccountId,
                Amount = created.Amount,
                Date = created.Date
            };
        }
    }
}
