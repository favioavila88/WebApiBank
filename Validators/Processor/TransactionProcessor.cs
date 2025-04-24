public class TransactionProcessor
{
    private readonly ITransactionHandler _handlerChain;

    public TransactionProcessor(IAccountService accountService)
    {
        var amountValidator = new PositiveAmountValidator();
        var fundsValidator = new SufficientFundsValidator(accountService);

        amountValidator.SetNext(fundsValidator);

        _handlerChain = amountValidator;
    }

    public async Task ProcessAsync(TransactionContext context)
    {
        await _handlerChain.HandleAsync(context);
    }
}
