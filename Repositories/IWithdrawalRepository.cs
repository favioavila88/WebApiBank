using WebApiBank.Models;

namespace WebApiBank.Repositories
{
    public interface IWithdrawalRepository
    {
        Task<Withdrawal> AddAsync(Withdrawal withdrawal);
    }
}
