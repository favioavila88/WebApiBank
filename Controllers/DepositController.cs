using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;
using WebApiBank.DTOs;
using WebApiBank.Services;

namespace WebApiBank.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepositController : ControllerBase
    {
        private readonly IDepositService _depositService;

        public DepositController(IDepositService depositService)
        {
            _depositService = depositService;
        }

        // Realiza un depósito en una cuenta
        [HttpPost]
        public async Task<IActionResult> CreateDeposit([FromBody] DepositDTO depositDto)
        {
            if (depositDto.Amount <= 0)
                return BadRequest("Deposit amount must be greater than 0.");

            try
            {
                var createdDeposit = await _depositService.CreateAsync(depositDto);
                return CreatedAtAction(nameof(CreateDeposit), new { id = createdDeposit.Id }, createdDeposit);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }
    }
}

