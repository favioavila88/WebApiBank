public class SufficientFundsValidator : TransactionHandlerBase
{
    private readonly IAccountService _accountService;

    public SufficientFundsValidator(IAccountService accountService)
    {
        _accountService = accountService;
    }

    public override async Task HandleAsync(TransactionContext context)
    {
        var account = await _accountService.GetByIdAsync(context.AccountId);
        context.Account = account;

        if (context.OperationType == "Withdraw" && account.Balance < context.Amount)
            throw new InvalidOperationException("Fondos insuficientes.");

        if (Next != null)
            await Next.HandleAsync(context);
    }
}
