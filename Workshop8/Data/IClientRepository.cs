using System.Collections.Generic;
using System.Threading.Tasks;
using Workshop8.Models;

namespace Workshop8.Data
{
    public interface IClientRepository
    {
        Task<IEnumerable<Cliente>> GetAllClientsAsync();
        Task AddClientAsync(Cliente c);
        Task UpdateClientAsync(Cliente c);
        Task DeleteClientAsync(int id);
    }
}
