using WebApiBank.Data;
using WebApiBank.Models;

namespace WebApiBank.Repositories
{
    public class DepositRepository : IDepositRepository
    {
        private readonly BankContext _context;

        public DepositRepository(BankContext context)
        {
            _context = context;
        }

        public async Task<Deposit> AddAsync(Deposit deposit)
        {
            _context.Deposits.Add(deposit);
            await _context.SaveChangesAsync();
            return deposit;
        }
    }
}
