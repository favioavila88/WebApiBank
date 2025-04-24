using WebApiBank.DTOs;
using WebApiBank.Models;

namespace WebApiBank.Factories
{
    public class TransactionFactory : ITransactionFactory
    {
        public Deposit CreateDepositEntity(TransactionDTO transactionDto)
        {
            return new Deposit
            {
                AccountId = transactionDto.AccountId,
                Amount = transactionDto.Amount,
                Date = DateTime.UtcNow
            };
        }

        public Withdrawal CreateWithdrawalEntity(TransactionDTO transactionDto)
        {
            return new Withdrawal
            {
                AccountId = transactionDto.AccountId,
                Amount = transactionDto.Amount,
                Date = DateTime.UtcNow
            };
        }
    }
}
