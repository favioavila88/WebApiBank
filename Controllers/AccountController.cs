using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;
using WebApiBank.DTOs;
using WebApiBank.Services;

namespace WebApiBank.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        // Crea una cuenta para un cliente
        [HttpPost]
        public async Task<IActionResult> CreateAccount([FromBody] AccountDTO accountDto)
        {
            if (accountDto.ClientId <= 0)
                return BadRequest("Invalid client ID.");

            try
            {
                var account = await _accountService.CreateAsync(accountDto);
                return CreatedAtAction(nameof(CreateAccount), new { id = account.Id }, account);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        // Actualiza una cuenta existente
        [HttpPut("{accountId}")]
        public async Task<IActionResult> UpdateAccount(int accountId, [FromBody] AccountDTO accountDto)
        {
            if (accountDto == null || accountDto.ClientId <= 0)
                return BadRequest("Invalid account data.");

            try
            {
                var updatedAccount = await _accountService.UpdateAsync(accountId, accountDto);
                if (updatedAccount == null)
                    return NotFound("Account not found.");

                return Ok(updatedAccount);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        // Elimina una cuenta
        [HttpDelete("{accountId}")]
        public async Task<IActionResult> DeleteAccount(int accountId)
        {
            try
            {
                await _accountService.DeleteAsync(accountId);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }
    }
}
