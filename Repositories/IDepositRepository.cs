using WebApiBank.Models;

namespace WebApiBank.Repositories
{
    public interface IDepositRepository
    {
        Task<Deposit> AddAsync(Deposit deposit);
    }
}
