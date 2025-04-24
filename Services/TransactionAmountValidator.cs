
namespace WebApiBank.Services
{
    public sealed class TransactionAmountValidator
    {
        private static readonly TransactionAmountValidator _instance = new TransactionAmountValidator();

        public static TransactionAmountValidator Instance => _instance;

        private TransactionAmountValidator() { }

        public void ValidateDeposit(decimal amount)
        {
            if (amount <= 0)
                throw new Exception("El monto del dep�sito debe ser mayor a cero.");

            if (amount > 10000)
                throw new Exception("El monto excede el l�mite permitido para dep�sitos.");
        }

        public void ValidateWithdrawal(decimal balance, decimal amount)
        {
            if (amount <= 0)
                throw new Exception("El monto a retirar debe ser mayor a cero.");

            if (amount > balance)
                throw new Exception("Fondos insuficientes en la cuenta.");
        }
    }
}
