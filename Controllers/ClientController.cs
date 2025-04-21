using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;
using WebApiBank.DTOs;
using WebApiBank.Services;

namespace WebApiBank.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        // Crea un nuevo cliente
        [HttpPost]
        public async Task<IActionResult> CreateClient([FromBody] ClientDTO clientDto)
        {
            if (clientDto == null)
                return BadRequest("Invalid client data.");

            try
            {
                var createdClient = await _clientService.CreateAsync(clientDto);
                return CreatedAtAction(nameof(CreateClient), new { id = createdClient.Id }, createdClient);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        // Actualiza un cliente existente
        [HttpPut("{clientId}")]
        public async Task<IActionResult> UpdateClient(int clientId, [FromBody] ClientDTO clientDto)
        {
            if (clientDto == null || clientId <= 0)
                return BadRequest("Invalid client data.");

            try
            {
                var updatedClient = await _clientService.UpdateAsync(clientId, clientDto);
                if (updatedClient == null)
                    return NotFound("Client not found.");

                return Ok(updatedClient);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        // Elimina un cliente
        [HttpDelete("{clientId}")]
        public async Task<IActionResult> DeleteClient(int clientId)
        {
            try
            {
                await _clientService.DeleteAsync(clientId);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }
    }
}
