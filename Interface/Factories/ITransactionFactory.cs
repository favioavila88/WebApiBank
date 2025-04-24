using WebApiBank.DTOs;
using WebApiBank.Models;

namespace WebApiBank.Factories
{
    public interface ITransactionFactory
    {
        Deposit CreateDepositEntity(TransactionDTO transactionDto);
        Withdrawal CreateWithdrawalEntity(TransactionDTO transactionDto);
    }
}
