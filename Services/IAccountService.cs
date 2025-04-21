using WebApiBank.DTOs;

namespace WebApiBank.Services
{
    public interface IAccountService
    {
        Task<IEnumerable<AccountDTO>> GetAllAsync();
        Task<AccountDTO?> GetByIdAsync(int id);
        Task<AccountDTO> CreateAsync(AccountDTO accountDto);
        Task<AccountDTO?> UpdateAsync(int id, AccountDTO accountDto);
        Task<bool> DeleteAsync(int id);
    }
}
