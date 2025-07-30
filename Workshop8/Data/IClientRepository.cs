using Workshop8.Models;

namespace Workshop8.Data
{
    public interface IClientRepository
    {
        Task<IEnumerable<Cliente>> GetAllClientsAsync(int PageNumber, int PageSize);

        Task AddClientAsync(Cliente c);

        Task UpdateClientAsync(Cliente c);

        Task DeleteClientAsync(int id);
        Task<int> GetTotalClientCountAsync();
    }
}
