using WebApiBank.Data;
using WebApiBank.Models;

namespace WebApiBank.Repositories
{
    public class WithdrawalRepository : IWithdrawalRepository
    {
        private readonly BankContext _context;

        public WithdrawalRepository(BankContext context)
        {
            _context = context;
        }

        public async Task<Withdrawal> AddAsync(Withdrawal withdrawal)
        {
            _context.Withdrawals.Add(withdrawal);
            await _context.SaveChangesAsync();
            return withdrawal;
        }
    }
}
