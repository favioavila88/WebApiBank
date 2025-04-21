using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;
using WebApiBank.DTOs;
using WebApiBank.Services;

namespace WebApiBank.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WithdrawalController : ControllerBase
    {
        private readonly IWithdrawalService _withdrawalService;

        public WithdrawalController(IWithdrawalService withdrawalService)
        {
            _withdrawalService = withdrawalService;
        }

        // Realiza un retiro en una cuenta
        [HttpPost]
        public async Task<IActionResult> CreateWithdrawal([FromBody] WithdrawalDTO withdrawalDto)
        {
            if (withdrawalDto.Amount <= 0)
                return BadRequest("Withdrawal amount must be greater than 0.");

            try
            {
                var createdWithdrawal = await _withdrawalService.CreateAsync(withdrawalDto);
                return CreatedAtAction(nameof(CreateWithdrawal), new { id = createdWithdrawal.Id }, createdWithdrawal);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }
    }
}
