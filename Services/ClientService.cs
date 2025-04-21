using WebApiBank.DTOs;
using WebApiBank.Models;
using WebApiBank.Repositories;

namespace WebApiBank.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _repository;

        public ClientService(IClientRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ClientDTO>> GetAllAsync()
        {
            var clients = await _repository.GetAllAsync();
            return clients.Select(c => new ClientDTO { Id = c.Id, Name = c.Name });
        }

        public async Task<ClientDTO?> GetByIdAsync(int id)
        {
            var client = await _repository.GetByIdAsync(id);
            if (client == null) return null;
            return new ClientDTO { Id = client.Id, Name = client.Name };
        }

        public async Task<ClientDTO> CreateAsync(ClientDTO clientDto)
        {
            var client = new Client { Name = clientDto.Name };
            var created = await _repository.AddAsync(client);
            return new ClientDTO { Id = created.Id, Name = created.Name };
        }

        public async Task<ClientDTO?> UpdateAsync(int id, ClientDTO clientDto)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null) return null;

            existing.Name = clientDto.Name;
            await _repository.UpdateAsync(existing);

            return new ClientDTO { Id = existing.Id, Name = existing.Name };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null) return false;

            await _repository.DeleteAsync(id);
            return true;
        }
    }
}
