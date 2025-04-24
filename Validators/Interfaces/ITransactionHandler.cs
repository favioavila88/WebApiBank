public interface ITransactionHandler
{
    Task HandleAsync(TransactionContext context);
    void SetNext(ITransactionHandler next);
}
