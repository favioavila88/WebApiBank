using WebApiBank.Services;

public class WithdrawalCommand : ICommand
{
    private readonly IAccountService _accountService;
    private readonly int _accountId;
    private readonly decimal _amount;

    public WithdrawalCommand(IAccountService accountService, int accountId, decimal amount)
    {
        _accountService = accountService;
        _accountId = accountId;
        _amount = amount;
    }

    public async Task ExecuteAsync()
    {
        await _accountService.WithdrawAsync(_accountId, _amount);
    }
}
