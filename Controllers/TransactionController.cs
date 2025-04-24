using Microsoft.AspNetCore.Mvc;
using WebApiBank.Commands;
using WebApiBank.Services;

[ApiController]
[Route("api/[controller]")]
public class TransactionsController : ControllerBase
{
    private readonly IAccountService _accountService;
    private readonly CommandHandler _commandHandler;

    public TransactionsController(IAccountService accountService, CommandHandler commandHandler)
    {
        _accountService = accountService;
        _commandHandler = commandHandler;
    }
    [HttpPost("deposit")]
    public async Task<IActionResult> Deposit(int accountId, decimal amount)
    {
        var command = new DepositCommand(_accountService, accountId, amount);
        _commandHandler.AddCommand(command);
        await _commandHandler.ExecuteCommands();  // Llamar al método asíncrono

        return Ok("Depósito procesado.");
    }

    [HttpPost("withdraw")]
    public async Task<IActionResult> Withdraw(int accountId, decimal amount)
    {
        var command = new WithdrawalCommand(_accountService, accountId, amount);
        _commandHandler.AddCommand(command);
        await _commandHandler.ExecuteCommands();  // Llamar al método asíncrono

        return Ok("Retiro procesado.");
    }

}
