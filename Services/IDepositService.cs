using WebApiBank.DTOs;

namespace WebApiBank.Services
{
    public interface IDepositService
    {
        Task<DepositDTO> CreateAsync(DepositDTO depositDto);
    }
}
