using WebApiBank.DTOs;

namespace WebApiBank.Services
{
    public interface IWithdrawalService
    {
        Task<WithdrawalDTO> CreateAsync(WithdrawalDTO withdrawalDto);
    }
}
