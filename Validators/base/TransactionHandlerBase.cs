public abstract class TransactionHandlerBase : ITransactionHandler
{
    protected ITransactionHandler? Next;

    public void SetNext(ITransactionHandler next)
    {
        Next = next;
    }

    public abstract Task HandleAsync(TransactionContext context);
}
