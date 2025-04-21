using WebApiBank.DTOs;
using WebApiBank.Models;
using WebApiBank.Repositories;

namespace WebApiBank.Services
{
    public class DepositService : IDepositService
    {
        private readonly IDepositRepository _depositRepository;
        private readonly IAccountRepository _accountRepository;

        public DepositService(IDepositRepository depositRepository, IAccountRepository accountRepository)
        {
            _depositRepository = depositRepository;
            _accountRepository = accountRepository;
        }

        public async Task<DepositDTO> CreateAsync(DepositDTO depositDto)
        {
            var account = await _accountRepository.GetByIdAsync(depositDto.AccountId);
            if (account == null) throw new Exception("Account not found");

            // Actualizar saldo
            account.Balance += depositDto.Amount;
            await _accountRepository.UpdateAsync(account);

            // Registrar depósito
            var deposit = new Deposit
            {
                AccountId = depositDto.AccountId,
                Amount = depositDto.Amount,
                Date = depositDto.Date
            };

            var created = await _depositRepository.AddAsync(deposit);

            return new DepositDTO
            {
                Id = created.Id,
                AccountId = created.AccountId,
                Amount = created.Amount,
                Date = created.Date
            };
        }
    }
}
