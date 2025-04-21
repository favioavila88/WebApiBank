using WebApiBank.DTOs;

namespace WebApiBank.Services
{
    public interface IClientService
    {
        Task<IEnumerable<ClientDTO>> GetAllAsync();
        Task<ClientDTO?> GetByIdAsync(int id);
        Task<ClientDTO> CreateAsync(ClientDTO clientDto);
        Task<ClientDTO?> UpdateAsync(int id, ClientDTO clientDto);
        Task<bool> DeleteAsync(int id);
    }
}
