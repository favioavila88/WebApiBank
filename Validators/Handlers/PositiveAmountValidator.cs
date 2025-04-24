public class PositiveAmountValidator : TransactionHandlerBase
{
    public override async Task HandleAsync(TransactionContext context)
    {
        if (context.Amount <= 0)
            throw new InvalidOperationException("El monto debe ser mayor a cero.");

        if (Next != null)
            await Next.HandleAsync(context);
    }
}
